using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Point formOffset;
        private Point borderOffset;

        private Timer timer;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            folderPath = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\LightNotes").FullName;
            notesDataPath = folderPath + @"\notes.csv";
            

            timer = new Timer();
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

            NoteControl noteControl = new NoteControl();
            noteControl.Tag = "usercontrol";
            //noteControl.Location = new Point(panel1.Width, topBorderPanel.Height);
            noteControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);

            panel_controls.Controls.Add(noteControl);
            
            //noteApp.Dock = DockStyle.Top;
            
        }





        #region DataManagment

        private void timer_Tick(object sender, EventArgs e)
        {
            SaveData();
        }


        private void SaveData()
        {
            Control noteControl = Controls.Find("NoteApp", true).First();
            NoteControl noteApp = (NoteControl)noteControl;
            DataTable notesDt = noteApp.dt;
            foreach (NotePrefab note in noteApp.notesLayoutPanel.Controls.OfType<NotePrefab>())
            {
                if (note.Tag.ToString().ToLower() == noteState.Minimized.ToString().ToLower())
                {

                    note.UpdateData();
                    string noteTitle = note.title;
                    string[] noteText = note.text;

                    var rowIndex = notesDt.Rows.IndexOf(notesDt.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                    if (noteTitle != null)
                    {
                        notesDt.Rows[rowIndex][notesDt.Columns["Title"].Ordinal] = noteTitle;
                    }
                    if (noteText != null)
                    {
                        notesDt.Rows[rowIndex][notesDt.Columns["Text"].Ordinal] = string.Join(",", noteText);
                    }
                    notesDt.Rows[rowIndex][notesDt.Columns["Position"].Ordinal] = noteApp.notesLayoutPanel.Controls.GetChildIndex(note);
                }
            }
            if (!File.Exists(notesDataPath))
            {
                var file = File.Create(notesDataPath);
                file.Close();
            }
            notesDt.WriteToCsvFile(notesDataPath);
        }

        #endregion


        #region WindowManagment

        private void button_close_Click(object sender, EventArgs e)
        {
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

        #endregion

        private void button_notes_Click(object sender, EventArgs e)
        {
            panel_controls.Controls.Clear();
            NoteControl noteControl = new NoteControl();
            noteControl.Tag = "usercontrol";
            //noteControl.Location = new Point(panel1.Width, topBorderPanel.Height);
            noteControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);

            panel_controls.Controls.Add(noteControl);
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            panel_controls.Controls.Clear();
            ListControl listControl = new ListControl();
            listControl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            panel_controls.Controls.Add(listControl);
        }
    }
}
