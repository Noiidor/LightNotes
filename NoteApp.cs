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
        int noteIndex;
        bool cornerPanelDragged;
        bool topBorderPanelDragged;
        string notesDataPath;
        string folderPath;
        Point formOffset;
        Timer timer;

        public NoteApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            folderPath = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\LightNotes").FullName;
            notesDataPath = folderPath + @"\notes.csv";
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 30000;
            timer.Start();

            dt = new DataTable();
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

            dt.ConvertCSVtoDataTable(notesDataPath);
            CreateNotesFromTable();
            dataGridView1.DataSource = dt;

            cornerPanel.Parent = this;
            cornerPanel.Location = new Point(this.Width - cornerPanel.Width , this.Height - cornerPanel.Height);
            cornerPanel.BringToFront();

            
            
        }

        private void CreateNote(uint id, string title, string[] text)
        {
            NotePrefab note = new NotePrefab();
            note.id = id;
            note.title = title;
            note.text = text;
            notesLayoutPanel.Controls.Add(note);
            note.button_maximizeClick += Note_button_maximizeClick;
        }

        private void CreateNotesFromTable()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    DataRow row = dt.Rows[i];
                    uint id = Convert.ToUInt32(row.Field<string>("Id"));
                    string title = row.Field<string>("Title");
                    string[] text = row.Field<string>("Text").Split(',');
                    CreateNote(id, title, text);
                }
                catch
                {
                    var lines = File.ReadAllLines(notesDataPath);
                    var linesList = lines.ToList();
                    linesList.RemoveAt(i);
                    dt.Rows[i].Delete();
                    File.WriteAllLines(notesDataPath, linesList);
                    continue;
                }

            }
        }

        private void Note_button_maximizeClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Control note = btn.Parent;
            if (note.Tag.ToString() == "minimized")
            {
                noteIndex = notesLayoutPanel.Controls.GetChildIndex(note);
                note.Size = new Size(this.Width, this.Height - topBorderPanel.Height);
                note.Parent = this;
                note.Location = new Point(0, topBorderPanel.Height);
                //note.Dock = DockStyle.Fill;
                note.BringToFront();
                //cornerPanel.BringToFront();
                //note.BringToFront();
                note.Tag = "maximized";
            }
            else
            {
                note.Size = new Size(250, 250);
                note.Parent = notesLayoutPanel;
                notesLayoutPanel.Controls.SetChildIndex(note, noteIndex);
                note.Tag = "minimized";
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
            CreateNote(highestId, String.Empty, new string[] { });
        }


        private void button_delete_Click(object sender, EventArgs e)
        {
            NotePrefab[] noteArr = new NotePrefab[notesLayoutPanel.Controls.Count];
            notesLayoutPanel.Controls.CopyTo(noteArr, 0);

            foreach (NotePrefab note in noteArr)
            {
                if (note.forRemoval)
                {
                    var rowIndex = dt.Rows.IndexOf(dt.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                    dt.Rows.RemoveAt(rowIndex);

                    notesLayoutPanel.Controls.Remove(note);
                }
            }
        }


        private void SaveData()
        {
            foreach (NotePrefab note in notesLayoutPanel.Controls)
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
            if (!File.Exists(notesDataPath))
            {
                var file = File.Create(notesDataPath);
                file.Close();
            }
            dt.WriteToCsvFile(notesDataPath);
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
                this.Width = cornerPanel.PointToScreen(e.Location).X;
                this.Height = cornerPanel.PointToScreen(e.Location).Y;
                this.Update();
            }
            
        }

        private void cornerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            cornerPanelDragged = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
