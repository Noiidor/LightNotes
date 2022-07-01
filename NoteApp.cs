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
        string dataFilePath;
        Point formOffset;
        Timer timer;

        public NoteApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataFilePath = Directory.GetCurrentDirectory() + @"\data.csv";
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 30000;
            timer.Start();

            dt = new DataTable();
            if (!File.Exists(dataFilePath))
            {
                File.WriteAllText(dataFilePath, Properties.Resources.data);
            }
            if (File.ReadAllLines(dataFilePath).Length == 0 || (File.ReadAllLines(dataFilePath)[0] != Properties.Resources.data) )
            {
                
                string[] lines = File.ReadAllLines(dataFilePath);
                lines[0] = Properties.Resources.data;
                File.WriteAllLines(dataFilePath, lines);
            }
            dt = ConvertCSVtoDataTable(dataFilePath);

            CreateNotesFromTable();
            dataGridView1.DataSource = dt;

            panel2.Parent = this;
            panel2.Location = new Point(this.Width - panel2.Width , this.Height - panel2.Height);

            
            
        }

        private void CreateNotesFromTable()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    DataRow row = dt.Rows[i];
                    NotePrefab note = new NotePrefab();
                    note.id = Convert.ToUInt32(row.Field<string>("Id"));
                    var a = row.Field<string>("Text");
                    label1.Text = a;
                    note.text = row.Field<string>("Text").Split(',');
                    note.title = row.Field<string>("Title");
                    flowLayoutPanel1.Controls.Add(note);
                }
                catch
                {
                    var lines = File.ReadAllLines(dataFilePath);
                    var linesList = lines.ToList();
                    linesList.RemoveAt(i);
                    dt.Rows[i ].Delete();
                    File.WriteAllLines(dataFilePath, linesList);
                    continue;
                }

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SaveData();
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


        private void SaveData()
        {
            foreach (NotePrefab note in flowLayoutPanel1.Controls)
            {
                note.UpdateData();
                string noteTitle = note.title;
                string[] noteText = note.text;
                var rowIndex = dt.Rows.IndexOf(dt.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                if (noteTitle != null)
                {
                    dt.Rows[rowIndex][dt.Columns["Title"].Ordinal] = noteTitle;
                }
                if (noteText != null)
                {
                    dt.Rows[rowIndex][dt.Columns["Text"].Ordinal] = string.Join(",", noteText);
                }
            }
            if (!File.Exists(dataFilePath))
            {
                var file = File.Create(dataFilePath);
                file.Close();
            }
            dt.WriteToCsvFile(dataFilePath);
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
                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        try
                        {
                            dr[i] = rows[i].Replace("\"", "");
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            continue;
                            //dr[i] = ";;";
                        }
                        
                    }
                    dt.Rows.Add(dr);
                }

            }


            return dt;

            //string[] Lines = Properties.Resources.data.Split('\n');
            //string[] Fields;
            //Fields = Lines[0].Split(new char[] { ';' });
            //int Cols = Fields.GetLength(0);
            //DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            //for (int i = 0; i < Cols; i++)
            //    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            //DataRow Row;
            //for (int i = 1; i < Lines.GetLength(0) ; i++)
            //{
            //    Fields = Lines[i].Split(new char[] { ';' });
            //    Row = dt.NewRow();
            //    for (int f = 0; f < Cols; f++)
            //        Row[f] = Fields[f];
            //    dt.Rows.Add(Row);
            //}
            //return dt;

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
                this.Width = Math.Min(Math.Max(panel2.PointToScreen(e.Location).X, 780), 2000);
                this.Height = Math.Min(Math.Max(panel2.PointToScreen(e.Location).Y, 750), 2000);
                this.Update();
            }
            
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            cornerPanelDragged = false;
        }

        
        public void NoteClicked(Object sender, EventArgs e)
        {
            label1.Text = sender.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
