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
                table.Rows.Add(0, string.Empty, string.Empty);
            }
            else
            {
                uint highestId = Convert.ToUInt32(table.Compute("max([Id])", string.Empty));
                table.Rows.Add(highestId + 1, string.Empty, string.Empty);
                button_add.Text = highestId.ToString();
            }

            NotePrefab note = new NotePrefab();
            Controls.Add(note);
            note.Parent = flowLayoutPanel1;
            note.Location = Point.Add(flowLayoutPanel1.Location, (Size)new Point(20, 20));
            
            

            
            
        }
    }
}
