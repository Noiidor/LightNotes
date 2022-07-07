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
    public partial class NoteApp : Form
    {
        private DataTable dt;
        private uint highestId;
        private int noteIndex;
        private bool cornerPanelDragged;
        private bool topBorderPanelDragged;
        private string notesDataPath;
        private string folderPath;

        private Point formOffset;
        private Point noteOffset;
        private Point borderOffset;

        private Timer timer;

        private Point noteCenter;
        private int placeholderIndex;

        private int corruptIndex;
        private bool corruptTriggered;

        private enum noteState
        {
            Minimized,
            Maximized,
            Dragged

        }

        public NoteApp()
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
            CreateNotesFromTable(dt);
            dataGridView1.DataSource = dt;

            cornerPanel.Parent = this;
            cornerPanel.Location = new Point(this.Width - cornerPanel.Width , this.Height - cornerPanel.Height);
            cornerPanel.BringToFront();
        }





        #region DataManagment

        private void timer_Tick(object sender, EventArgs e)
        {
            SaveData();
        }


        private void SaveData()
        {
            foreach (NotePrefab note in notesLayoutPanel.Controls.OfType<NotePrefab>())
            {
                if (note.Tag.ToString().ToLower() == noteState.Minimized.ToString().ToLower())
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
                    dt.Rows[rowIndex][dt.Columns["Position"].Ordinal] = notesLayoutPanel.Controls.GetChildIndex(note);
                }
            }
            if (!File.Exists(notesDataPath))
            {
                var file = File.Create(notesDataPath);
                file.Close();
            }
            dt.WriteToCsvFile(notesDataPath);
        }

        #endregion

        #region NotesManagment

        private void Note_panel_dragMouseUp(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            Control note = panel.Parent;

            if (note.Tag.ToString().ToLower() == noteState.Dragged.ToString().ToLower())
            {

                notesLayoutPanel.Controls.RemoveAt(placeholderIndex);

                note.Parent = notesLayoutPanel;
                notesLayoutPanel.BorderStyle = BorderStyle.None;

                Dictionary<int, Vector2> noteCoordDict = new Dictionary<int, Vector2>();
                foreach (Control noteControl in notesLayoutPanel.Controls)
                {

                    Point noteControlCenter = noteControl.Location.Add(new Point(noteControl.Width / 2, noteControl.Height / 2));
                    noteCoordDict.Add(notesLayoutPanel.Controls.GetChildIndex(noteControl), noteControlCenter.ToVector2());
                }
                Dictionary<int, float> noteDistDict = new Dictionary<int, float>();
                foreach (KeyValuePair<int, Vector2> noteCoord in noteCoordDict)
                {
                    noteDistDict.Add(noteCoord.Key, Vector2.Distance(noteCoord.Value, noteCenter.ToVector2()));
                }
                KeyValuePair<int, float> noteNearest = noteDistDict.OrderBy(kvp => kvp.Value).First();

                int noteNearestIndex = noteNearest.Key;


                notesLayoutPanel.Controls.SetChildIndex(note, noteNearestIndex);
                note.Tag = noteState.Minimized;
            }

        }

        private void Note_panel_dragMouseMove(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            Control note = panel.Parent;

            if (note.Tag.ToString() == noteState.Dragged.ToString())
            {


                noteCenter = note.Location.Add(new Point(note.Width / 2, note.Height / 2));

                Point newPoint = MousePosition;
                newPoint.Offset(noteOffset);
                note.Location = newPoint;
            }
        }

        private void Note_panel_dragMouseDown(object sender, EventArgs e)
        {

            Panel panel = (Panel)sender;
            Control note = panel.Parent;

            if (note.Tag.ToString().ToLower() == noteState.Minimized.ToString().ToLower())
            {
                notesLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
                noteOffset = new Point();
                noteOffset.X = note.Location.X - MousePosition.X;
                noteOffset.Y = -note.PointToScreen(Point.Empty).Y + this.PointToClient(MousePosition).Y - note.PointToClient(MousePosition).Y * 2;

                Panel placeholder = new Panel();
                placeholder.Size = new Size(250, 250);
                placeholder.BorderStyle = BorderStyle.FixedSingle;
                notesLayoutPanel.Controls.Add(placeholder);
                placeholderIndex = notesLayoutPanel.Controls.GetChildIndex(note);
                notesLayoutPanel.Controls.SetChildIndex(placeholder, placeholderIndex);

                note.Parent = this;
                note.BringToFront();
                note.Tag = noteState.Dragged;
            }

        }

        private void Note_button_maximizeClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Control note = btn.Parent;
            NotePrefab prefab = (NotePrefab)note;
            if (note.Tag.ToString().ToLower() == noteState.Minimized.ToString().ToLower())
            {
                noteIndex = notesLayoutPanel.Controls.GetChildIndex(note);
                prefab.panel_drag.Visible = false;
                note.Size = new Size(this.Width, this.Height - topBorderPanel.Height);
                note.Parent = this;
                note.Location = new Point(0, topBorderPanel.Height);
                note.BringToFront();
                note.Tag = noteState.Maximized;
            }
            else
            {
                prefab.panel_drag.Visible = true;
                note.Size = new Size(250, 250);
                note.Parent = notesLayoutPanel;
                notesLayoutPanel.Controls.SetChildIndex(note, noteIndex);
                note.Tag = noteState.Minimized;
            }
        }

        private void CreateNote(uint id, string title, string[] text, int position)
        {
            NotePrefab note = new NotePrefab();
            note.id = id;
            note.title = title;
            note.text = text;
            Control noteControl = (Control)note;
            noteControl.Tag = noteState.Minimized;
            //note.Tag = noteState.Minimized;
            notesLayoutPanel.Controls.Add(note);
            notesLayoutPanel.Controls.SetChildIndex(note, position);
            note.button_maximizeClick += Note_button_maximizeClick;
            note.panel_dragMouseDown += Note_panel_dragMouseDown;
            note.panel_dragMouseMove += Note_panel_dragMouseMove;
            note.panel_dragMouseUp += Note_panel_dragMouseUp;
        }

        private void CreateNotesFromTable(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    corruptIndex = i;
                    DataRow row = dt.Rows[i];
                    uint id = Convert.ToUInt32(row.Field<string>("Id"));
                    string title = row.Field<string>("Title");
                    string[] text = row.Field<string>("Text").Split(',');
                    int position = Convert.ToInt32(row.Field<string>("Position"));
                    CreateNote(id, title, text, position);
                }
                catch
                {
                    if (corruptTriggered)
                    {
                        Pop_button_corruptClick(null, null);
                    }
                    else
                    {
                        FileCorruptionPopup pop = new FileCorruptionPopup();
                        pop.button_corruptClick += Pop_button_corruptClick;
                        pop.ShowDialog();
                    }
                    break;
                }

            }
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
            CreateNote(highestId, String.Empty, new string[] { }, 0);
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

        private void Pop_button_corruptClick(object sender, EventArgs e)
        {
            corruptTriggered = true;
            var lines = File.ReadAllLines(notesDataPath);
            var linesList = lines.ToList();
            linesList.RemoveAt(corruptIndex);
            dt.Rows[corruptIndex].Delete();
            File.WriteAllLines(notesDataPath, linesList);
            dt.WriteToCsvFile(notesDataPath);
            notesLayoutPanel.Controls.Clear();
            CreateNotesFromTable(dt);
            
        }

        #endregion
    }
}
