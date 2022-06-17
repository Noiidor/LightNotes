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
    public partial class NotePrefab : UserControl
    {
        public uint id;
        public bool forRemoval = false;
        public string title = "";
        public string text = "";

        public NotePrefab()
        {
            InitializeComponent();
        }

        private void NotePrefab_Load(object sender, EventArgs e)
        {
            tbox_title.Text = title;
            tbox_text.Text = text;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            forRemoval = checkBox1.Checked;
        }

        public void UpdateData()
        {
            title = tbox_title.Text;
            text = tbox_text.Text;
        }

        public void UpdateText()
        {
            tbox_title.Text = title;
            tbox_text.Text = text;
        }

        private void tbox_title_TextChanged(object sender, EventArgs e)
        {
            //UpdateData();
        }

        private void tbox_text_TextChanged(object sender, EventArgs e)
        {
            //UpdateData();
        }
    }
}
