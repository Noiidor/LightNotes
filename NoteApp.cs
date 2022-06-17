using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LightNotes
{

    

    public partial class NoteApp : Form
    {
        DataTable dt;
        uint highestId;

        bool cornerPanelDragged;
        bool isTopBorderPanelDragged;
        Point formOffset;

        public NoteApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dt = new DataTable();
            dt = ConvertCSVtoDataTable(@"D:\C#\LightNotes\test.csv");
            CreateNotesFromTable();
            //dt.Columns.Add("Id", typeof(uint));
            //dt.Columns.Add("Title", typeof(string));
            //dt.Columns.Add("Text", typeof(string));
            dataGridView1.DataSource = dt;
            panel2.Parent = this;
            panel2.Location = new Point(this.Width - panel2.Width , this.Height - panel2.Height);
            
        }

        private void CreateNotesFromTable()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                NotePrefab note = new NotePrefab();
                note.id = Convert.ToUInt32(row.Field<string>("Id"));
                note.text = row.Field<string>("Text");
                note.title = row.Field<string>("Title");
                //note.UpdateText();
                //label3.Text = row.Field<string>("Text").Replace("\"", ""); 
                flowLayoutPanel1.Controls.Add(note);
            }
            //foreach (DataRow row in dt.Rows)
            //{
                
            //}
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            
            if (dt.Rows.Count == 0)
            {
                highestId = 0;
                dt.Rows.Add(highestId, string.Empty, string.Empty);
            }
            else
            {
                highestId = Convert.ToUInt32(dt.Compute("max([Id])", string.Empty)) + 1;
                dt.Rows.Add(highestId, string.Empty, string.Empty);
            }

            NotePrefab note = new NotePrefab();
            flowLayoutPanel1.Controls.Add(note);
            note.id = highestId;
            //label1.Text = flowLayoutPanel1.Controls.ToString();
            
        }


        private void button_delete_Click(object sender, EventArgs e)
        {
            NotePrefab[] noteArr = new NotePrefab[flowLayoutPanel1.Controls.Count];
            flowLayoutPanel1.Controls.CopyTo(noteArr, 0);

            foreach (NotePrefab note in noteArr)
            {
                if (note.forRemoval == true)
                {
                    var rowIndex = dt.Rows.IndexOf(dt.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                    dt.Rows.RemoveAt(rowIndex);

                    flowLayoutPanel1.Controls.Remove(note);
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        private void SaveData()
        {
            foreach (NotePrefab note in flowLayoutPanel1.Controls)
            {
                note.UpdateData();
                string noteTitle = note.title;
                string noteText = note.text;
                var rowIndex = dt.Rows.IndexOf(dt.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                if (noteTitle != null)
                {
                    dt.Rows[rowIndex][dt.Columns["Title"].Ordinal] = noteTitle;
                }
                if (noteText != null)
                {
                    dt.Rows[rowIndex][dt.Columns["Text"].Ordinal] = noteText;
                }
            }
            //StringBuilder sb = new StringBuilder();

            //IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
            //                                  Select(column => column.ColumnName);
            //sb.AppendLine(string.Join(",", columnNames));

            //foreach (DataRow row in dt.Rows)
            //{
            //    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
            //    sb.AppendLine(string.Join(",", fields));
            //}

            //File.WriteAllText("test.csv", sb.ToString());
            dt.WriteToCsvFile(@"D:\C#\LightNotes\test.csv");
        }


        private void button_close_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }

        private void button_minimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isTopBorderPanelDragged = true;
                Point startPosition = this.PointToScreen(new Point( e.X, e.Y));
                formOffset = new Point();
                formOffset.X = this.Location.X - startPosition.X;
                formOffset.Y = this.Location.Y - startPosition.Y;
            }
            else
            {
                isTopBorderPanelDragged = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isTopBorderPanelDragged)
            {
                Point newPoint = panel1.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(formOffset);
                this.Location = newPoint;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isTopBorderPanelDragged = false;
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i].Replace("\"", "");
                    }
                    dt.Rows.Add(dr);
                }

            }


            return dt;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cornerPanelDragged = true;
            }
            else
            {
                cornerPanelDragged = false;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (cornerPanelDragged)
            {
                this.Width = panel2.PointToScreen(e.Location).X;
                this.Height = panel2.PointToScreen(e.Location).Y;
                this.Update();
            }
            
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            cornerPanelDragged = false;
        }
    }
}
