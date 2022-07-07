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
    public partial class FileCorruptionPopup : Form
    {

        public event EventHandler button_corruptClick;

        public FileCorruptionPopup()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
            Application.Exit();
        }

        private void button_corrupt_Click(object sender, EventArgs e)
        {
            button_corruptClick?.Invoke(sender, e);
            this.Close();
        }
    }
}
