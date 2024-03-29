﻿using System;
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
        public string title;
        public string[] text;
        public bool forRemoval = false;


        public event EventHandler button_maximizeClick;
        public event EventHandler panel_dragMouseDown;
        public event EventHandler panel_dragMouseMove;
        public event EventHandler panel_dragMouseUp;

        public NotePrefab()
        {
            InitializeComponent();
            
        }

        private void NotePrefab_Load(object sender, EventArgs e)
        {
            this.Tag = "minimized";
            tbox_title.Text = title;
            tbox_text.Lines = text;
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            forRemoval = checkBox1.Checked;
        }

        public void UpdateData()
        {
            title = tbox_title.Text;
            text = tbox_text.Lines;
        }

        public void UpdateText()
        {
            tbox_title.Text = title;
            tbox_text.Lines = text;
        }

        private void tbox_title_TextChanged(object sender, EventArgs e)
        {
            //UpdateData();
        }

        private void tbox_text_TextChanged(object sender, EventArgs e)
        {
            //UpdateData();
        }

        private void button_maximize_Click(object sender, EventArgs e)
        {
            button_maximizeClick?.Invoke(sender, e);
        }

        private void panel_drag_MouseDown(object sender, MouseEventArgs e)
        {
            panel_dragMouseDown?.Invoke(sender, e);
        }

        private void panel_drag_MouseMove(object sender, MouseEventArgs e)
        {
            panel_dragMouseMove?.Invoke(sender, e);
        }

        private void panel_drag_MouseUp(object sender, MouseEventArgs e)
        {
            panel_dragMouseUp?.Invoke(sender, e);
        }

        private void panel_drag_DragOver(object sender, DragEventArgs e)
        {
            
        }
    }
}
