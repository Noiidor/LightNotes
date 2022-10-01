using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Net.Mime;
using System.IO;
using System.Web;
using MimeTypes;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace LightNotes
{

    class DriveSynchronization
    {
        private static string[] scopes = { DriveService.Scope.DriveAppdata };
        private static DriveService service;


        public async static Task<Task<UserCredential>> Authorize(string tokenPath)
        {
            //MemoryStream stream;
            //using (stream = new MemoryStream())
            //{
            //    StreamWriter sw = new StreamWriter(stream);
            //    sw.Write(Properties.Resources.client_secret);
            //    sw.Flush();

            //}

            try
            {
                MemoryStream stream =
                new MemoryStream(ASCIIEncoding.Default.GetBytes(Properties.Resources.client_secret));


                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(tokenPath + @"\token", true));

                service = new DriveService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = await credential,
                    ApplicationName = "DriveSynchronization"
                });

                return credential;
            }
            catch
            {
                return null;
            }

            //return true;
        }

        public static void Deathorize()
        {
            service.Dispose();
        }

        public static void UpdateOnDrive(string appFolderPath)
        {
            //ClearDrive();

            var driveFiles = GetDriveFiles("files(md5Checksum, name, id)");

            string[] driveFileNames = driveFiles.Select(file => file.Name).ToArray();
            string[] appFileNames = Directory.GetFiles(appFolderPath).Select(file => Path.GetFileName(file)).ToArray();

            foreach (string localFile in appFileNames)
            {
                
                int fileIndex = Array.IndexOf(driveFileNames, localFile);

                if (fileIndex > -1)
                {
                    if (driveFiles[fileIndex].Md5Checksum != GetMd5(appFolderPath + @"\" + localFile))
                    {
                        service.Files.Delete(driveFiles[fileIndex].Id).Execute();

                        UploadFile(localFile, appFolderPath);
                    }
                }
                else
                {
                    UploadFile(localFile, appFolderPath);
                }
            }
        }

        public static Task CheckOutdated(string appFolderPath)
        {
            var driveFiles = GetDriveFiles("files(md5Checksum, id, name)");

            string[] appDataFiles = Directory.GetFiles(appFolderPath).Select(file => Path.GetFileName(file)).ToArray();

            List<Task<Google.Apis.Download.IMediaDownloader>> tasks = new List<Task<Google.Apis.Download.IMediaDownloader>>();

            foreach (Google.Apis.Drive.v3.Data.File file in driveFiles)
            {
                if (appDataFiles.Contains(file.Name))
                {

                    string localM5 = GetMd5(appFolderPath + @"\" + appDataFiles[Array.IndexOf(appDataFiles, file.Name)]);
                    string driveM5 = file.Md5Checksum;
                    if (localM5 != driveM5)
                    {
                        tasks.Add(DownloadFile(file, appFolderPath));
                    }
                }
                else
                {
                    tasks.Add(DownloadFile(file, appFolderPath));
                }
            }

            return Task.WhenAll(tasks.ToArray());

        }

        public static async void DownloadAllFromDrive(string appFolderPath)
        {
            var asyncRes = await GetDriveFilesAsync();
            var driveFiles = asyncRes.Files;

            foreach (Google.Apis.Drive.v3.Data.File file in driveFiles)
            {
                DownloadFile(file, appFolderPath);
            }
        }

        public static async void ClearDrive()
        {
            
            var driveFiles = GetDriveFiles();
            for (int i = 0; i < driveFiles.Count; i++)
            {
                await service.Files.Delete(driveFiles[i].Id).ExecuteAsync();
            }
        }

        public static string CheckDrive()
        {
            var driveFiles = GetDriveFiles();
            return driveFiles.Count.ToString();
        }

        

        #region DriveOperations

        private static async Task<Google.Apis.Download.IMediaDownloader> DownloadFile(Google.Apis.Drive.v3.Data.File file, string downloadPath)
        {
            MemoryStream stream = new MemoryStream();
            var downloadReq = service.Files.Get(file.Id);
            downloadReq.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Completed:
                        {
                            SaveStream(stream, downloadPath + @"\" + file.Name); //Save the file 
                            stream.Close();
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            break;
                        }
                }
            };

            

            await downloadReq.DownloadAsync(stream);
            return downloadReq.MediaDownloader;
        }

        private static void UploadFile(string fileName, string appFolderPath)
        {
            string mimeType = MimeTypeMap.GetMimeType(appFolderPath + @"\" + fileName);

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileName,
                MimeType = mimeType,
                Parents = new string[] { "appDataFolder" }
            };

            FileStream fileStream = new FileStream(appFolderPath + @"\" + fileName, FileMode.Open, FileAccess.Read);

            var fileReq = service.Files.Create(fileMetadata, fileStream, mimeType);

            fileReq.UploadAsync().Wait();
            fileStream.Close();
        }
        

        private static IList<Google.Apis.Drive.v3.Data.File> GetDriveFiles(string fields)
        {
            var driveReq = service.Files.List();
            driveReq.Spaces = "appDataFolder";
            driveReq.Fields = fields;
            return driveReq.Execute().Files;
        }

        private static IList<Google.Apis.Drive.v3.Data.File> GetDriveFiles()
        {
            var driveReq = service.Files.List();
            driveReq.Spaces = "appDataFolder";
            return driveReq.Execute().Files;
        }

        private async static Task<FileList> GetDriveFilesAsync(string fields)
        {
            var driveReq = service.Files.List();
            driveReq.Spaces = "appDataFolder";
            driveReq.Fields = fields;
            
            return await driveReq.ExecuteAsync();
        }

        private async static Task<FileList> GetDriveFilesAsync()
        {
            var driveReq = service.Files.List();
            driveReq.Spaces = "appDataFolder";

            return await driveReq.ExecuteAsync();
        }

        #endregion

        #region LocalOperations

        private static string GetMd5(string fileFullPath)
        {
            FileStream fileStream = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);

            var hash = MD5.Create().ComputeHash(fileStream);
            fileStream.Close();
            string Md5Checksum = BitConverter.ToString(hash).Replace("-", "").ToLower();

            return Md5Checksum;
        }

        private static void SaveStream(MemoryStream stream, string saveTo)
        {
            using (FileStream file = new FileStream(saveTo, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }

        #endregion

    }
}
