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
            DataRowCollection itemColumns = table.Rows;

            foreach (NotePrefab note in noteArr)
            {
                //NotePrefab[] noteArr = new NotePrefab[flowLayoutPanel1.Controls.Count];
                //flowLayoutPanel1.Controls.CopyTo(noteArr, 0);
                if (note.forRemoval == true)
                {
                    var penis = table.Rows.IndexOf(table.Select("Id ='" + note.id.ToString() + "'", string.Empty)[0]);
                    table.Rows.RemoveAt(penis);

                    flowLayoutPanel1.Controls.Remove(note);
                    
                    label1.Text = penis.ToString();
                }
                //arr = noteArr;
                //dataGridView1.DataSource = noteArr;
            }
        }
    }
}
