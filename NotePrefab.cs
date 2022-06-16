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

        public NotePrefab()
        {
            InitializeComponent();
        }

        private void NotePrefab_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            forRemoval = checkBox1.Checked;
            tbox_title.Text = forRemoval.ToString();
        }
    }
}
