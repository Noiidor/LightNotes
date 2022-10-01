using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Windows.Forms;
using System.IO;
using ExtentionMethods;

namespace LightNotes
{
    public partial class AppBase : Form
    {
        private bool cornerPanelDragged;
        private bool topBorderPanelDragged;
        public string notesDataPath;
        public string listDataPath;
        public string folderPath;
        private bool synchronized;
        private string tokenFolderPath;

        private Point formOffset;
        private Point borderOffset;

        private System.Windows.Forms.Timer timer;

        private enum noteState
        {
            Minimized,
            Maximized,
            Dragged
        }

        public AppBase()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparams = base.CreateParams;
                handleparams.ExStyle |= 0x02000000;
                return handleparams;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

#if DEBUG
            //folderPath = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\LightNotesTest").FullName;
            folderPath = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LightNotesTest").FullName;
#else
            //folderPath = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\LightNotes").FullName;
            folderPath = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LightNotes").FullName;
#endif
            notesDataPath = folderPath + @"\notes.csv";

            tokenFolderPath = folderPath + @"\" + "token";
            string tokenFilePath = tokenFolderPath + @"\" + "Google.Apis.Auth.OAuth2.Responses.TokenResponse-user";

            if (File.Exists(tokenFilePath))
            {
                var pp = await DriveSynchronization.Authorize(folderPath).Result;

                synchronized = pp != null;
                
                if (synchronized)
                {
                    await DriveSynchronization.CheckOutdated(folderPath);
                    button_sync.BackgroundImage = Properties.Resources.check;
                }
                
            }
            
            

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 30000;
            //timer.Start();


            if (!File.Exists(notesDataPath))
            {
                File.WriteAllText(notesDataPath, Properties.Resources.data);
            }
            if (File.ReadAllLines(notesDataPath).Length == 0 || (File.ReadAllLines(notesDataPath)[0] != Properties.Resources.data) )
            {
                
                string[] lines = File.ReadAllLines(notesDataPath);
                lines[0] = Properties.Resources.data;
                File.WriteAllLines(notesDataPath, lines);
            }

            cornerPanel.Parent = this;
            cornerPanel.Location = new Point(this.Width - cornerPanel.Width , this.Height - cornerPanel.Height);
            cornerPanel.BringToFront();
            button_close.BringToFront();
            button_minimaze.BringToFront();

            CreateNoteControl();

        }





        #region DataManagment

        private void timer_Tick(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            Control noteControl = Controls.Find("NoteControl", true).FirstOrDefault();
            if (noteControl != null)
            {
                NoteControl noteApp = (NoteControl)noteControl;
                noteApp.SaveNotes();
            }
            Control listControl = Controls.Find("ListControl", true).FirstOrDefault();
            if (listControl != null)
            {
                ListControl listCont = (ListControl)listControl;
                listCont.SaveLists();
            }

            if (synchronized)
            {
                DriveSynchronization.UpdateOnDrive(folderPath);
            }

        }

        private async void button_sync_Click_1(object sender, EventArgs e)
        {
            if (!synchronized)
            {
                var pp = await DriveSynchronization.Authorize(folderPath);

                synchronized = pp != null;
                
                if (synchronized)
                {
                    panel_controls.Controls.Clear();
                    
                    await DriveSynchronization.CheckOutdated(folderPath);

                    CreateNoteControl();

                    button_sync.BackgroundImage = Properties.Resources.check;
                }
                
            }
            else
            {
                DriveSynchronization.Deathorize();
                Directory.Delete(tokenFolderPath, true);
                synchronized = false;
                button_sync.BackgroundImage = Properties.Resources.minus;
            }
            
        }


        #endregion


        #region WindowManagment

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveData();
            Application.Exit();
        }

        private void button_minimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topBorderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                topBorderPanelDragged = true;
                Point startPosition = this.PointToScreen(new Point( e.X, e.Y));
                formOffset = new Point();
                formOffset.X = this.Location.X - startPosition.X;
                formOffset.Y = this.Location.Y - startPosition.Y;
            }
            else
            {
                topBorderPanelDragged = false;
            }
        }

        private void topBorderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (topBorderPanelDragged)
            {
                Point newPoint = topBorderPanel.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(formOffset);
                this.Location = newPoint;
            }
        }

        private void topBorderPanel_MouseUp(object sender, MouseEventArgs e)
        {
            topBorderPanelDragged = false;
        }


        private void cornerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                borderOffset = new Point();
                borderOffset.X = cornerPanel.Location.X - MousePosition.X + cornerPanel.Width;
                borderOffset.Y = cornerPanel.Location.Y - MousePosition.Y + cornerPanel.Height;
                cornerPanelDragged = true;
            }
            else
            {
                cornerPanelDragged = false;
            }
        }

        private void cornerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (cornerPanelDragged)
            {
                Point newPoint = MousePosition;
                newPoint.Offset(borderOffset);
                this.Width = newPoint.X;
                this.Height = newPoint.Y;
                this.Update();
            }
            
        }

        private void cornerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            cornerPanelDragged = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void cornerPanel_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(panel1.BackColor);
            e.Graphics.FillPolygon(brush, new Point[] {
                new Point(cornerPanel.Height, 0),
                new Point(cornerPanel.Height, cornerPanel.Width),
                new Point(0, cornerPanel.Width)
            });
        }

        #endregion


        #region Controls

        private void button_notes_Click(object sender, EventArgs e)
        {
            foreach (Control cont in panel_controls.Controls)
            {
                cont.Visible = false;
            }
            if (panel_controls.Controls.OfType<NoteControl>().Count() == 0)
            {
                NoteControl noteControl = new NoteControl();
                noteControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
                panel_controls.Controls.Add(noteControl);
            }
            else
            {
                panel_controls.Controls.OfType<NoteControl>().First().Visible = true;
            }
           
            
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            foreach (Control cont in panel_controls.Controls)
            {
                cont.Visible = false;
            }
            if (panel_controls.Controls.OfType<ListControl>().Count() == 0)
            {
                ListControl listControl = new ListControl();
                listControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
                panel_controls.Controls.Add(listControl);
            }
            else
            {
                panel_controls.Controls.OfType<ListControl>().First().Visible = true;
            }
            
        }

        private void CreateNoteControl()
        {
            NoteControl noteControl = new NoteControl();
            noteControl.Tag = "usercontrol";
            noteControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
            panel_controls.Controls.Add(noteControl);
            noteControl.BringToFront();
        }

        #endregion

        private void button_sync_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            DriveSynchronization.Authorize(folderPath);
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            DriveSynchronization.UpdateOnDrive(folderPath);
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            DriveSynchronization.DownloadAllFromDrive(folderPath);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            DriveSynchronization.ClearDrive();
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = DriveSynchronization.CheckDrive();
        }

        private void button_date_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button_md_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
