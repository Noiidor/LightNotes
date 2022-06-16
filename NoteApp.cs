using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightNotes
{

    

    public partial class NoteApp : Form
    {

        DataTable table;
        uint highestId;
        NotePrefab[] arr;

        bool isTopBorderPanelDragged;
        Point formOffset;

        public NoteApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            table = new DataTable();
            table.Columns.Add("Id", typeof(uint));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Text", typeof(string));
            dataGridView1.DataSource = table;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            
            if (table.Rows.Count == 0)
            {
                highestId = 0;
                table.Rows.Add(highestId, string.Empty, string.Empty);
            }
            else
            {
                highestId = Convert.ToUInt32(table.Compute("max([Id])", string.Empty)) + 1;
                table.Rows.Add(highestId, string.Empty, string.Empty);
            }

            NotePrefab note = new NotePrefab();
            flowLayoutPanel1.Controls.Add(note);
            note.id = highestId;
            //label1.Text = flowLayoutPanel1.Controls.ToString();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            NotePrefab[] noteArr = new NotePrefab[flowLayoutPanel1.Controls.Count];
            flowLayoutPanel1.Controls.CopyTo(noteArr, 0);

            foreach (NotePrefab note in noteArr)
            {
                if (note.forRemoval == true)
                {
                    var rowIndex = table.Rows.IndexOf(table.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                    table.Rows.RemoveAt(rowIndex);

                    flowLayoutPanel1.Controls.Remove(note);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveData();
        }


        private void SaveData()
        {
            foreach (NotePrefab note in flowLayoutPanel1.Controls)
            {
                string noteTitle = note.title;
                string noteText = note.text;
                var rowIndex = table.Rows.IndexOf(table.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                if (noteTitle != null)
                {
                    table.Rows[rowIndex][table.Columns["Title"].Ordinal] = noteTitle;
                }
                if (noteText != null)
                {
                    table.Rows[rowIndex][table.Columns["Text"].Ordinal] = noteText;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
