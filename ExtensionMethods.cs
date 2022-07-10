using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Resources;

using System.IO;
using System.Numerics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtentionMethods
{
    public static class DataTableExtensions
    {
        public static void WriteToCsvFile(this DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ";");
            }

            fileContent.Replace(";", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    fileContent.Append("\"" + column.ToString() + "\";");
                }

                fileContent.Replace(";", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            File.WriteAllText(filePath, fileContent.ToString());
        }

        public static void ConvertCSVtoDataTable(this DataTable dataTable, string strFilePath)
        {
            dataTable.Columns.Clear();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        try
                        {
                            dr[i] = rows[i].Replace("\"", "");
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            continue;
                        }

                    }
                    dataTable.Rows.Add(dr);
                }

            }

        }

        public static void FromDataGridView(this DataTable dt, DataGridView dg)
        {
            foreach (DataGridViewColumn col in dg.Columns)
            {
                if (!dt.Columns.Contains(col.Name))
                {
                    dt.Columns.Add(col.Name);
                }
                
            }
            //foreach (DataGridViewRow row in dg.Rows)
            //{
            //    DataRow dRow = dt.NewRow();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        dRow[cell.ColumnIndex] = cell.Value;
            //    }
            //    dt.Rows.Add(dRow);
            //}

            for (int i = 0; i < dg.Rows.Count-1; i++)
            {
                DataGridViewRow row = dg.Rows[i];
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
        }
    }

    public static class PointExtentions
    {
        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }

        public static Point Add(this Point a, Point b)
        {
            return Point.Add(a, (Size)b);
        }
    }
}
