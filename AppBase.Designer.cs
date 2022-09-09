
namespace LightNotes
{
    partial class AppBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppBase));
            this.button_close = new System.Windows.Forms.Button();
            this.button_minimaze = new System.Windows.Forms.Button();
            this.topBorderPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cornerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_list = new System.Windows.Forms.Button();
            this.button_notes = new System.Windows.Forms.Button();
            this.panel_controls = new System.Windows.Forms.Panel();
            this.topBorderPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_close
            // 
            resources.ApplyResources(this.button_close, "button_close");
            this.button_close.BackColor = System.Drawing.Color.Bisque;
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.Name = "button_close";
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_minimaze
            // 
            resources.ApplyResources(this.button_minimaze, "button_minimaze");
            this.button_minimaze.BackColor = System.Drawing.Color.Bisque;
            this.button_minimaze.FlatAppearance.BorderSize = 0;
            this.button_minimaze.Name = "button_minimaze";
            this.button_minimaze.UseVisualStyleBackColor = false;
            this.button_minimaze.Click += new System.EventHandler(this.button_minimaze_Click);
            // 
            // topBorderPanel
            // 
            resources.ApplyResources(this.topBorderPanel, "topBorderPanel");
            this.topBorderPanel.BackColor = System.Drawing.Color.Bisque;
            this.topBorderPanel.Controls.Add(this.label1);
            this.topBorderPanel.Name = "topBorderPanel";
            this.topBorderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseDown);
            this.topBorderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseMove);
            this.topBorderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseUp);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Name = "label1";
            // 
            // cornerPanel
            // 
            resources.ApplyResources(this.cornerPanel, "cornerPanel");
            this.cornerPanel.BackColor = System.Drawing.Color.Transparent;
            this.cornerPanel.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.cornerPanel.Name = "cornerPanel";
            this.cornerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.cornerPanel_Paint);
            this.cornerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cornerPanel_MouseDown);
            this.cornerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cornerPanel_MouseMove);
            this.cornerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cornerPanel_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.button_list);
            this.panel1.Controls.Add(this.button_notes);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // button_list
            // 
            this.button_list.BackColor = System.Drawing.Color.LightSalmon;
            this.button_list.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.button_list, "button_list");
            this.button_list.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_list.Name = "button_list";
            this.button_list.UseVisualStyleBackColor = false;
            this.button_list.Click += new System.EventHandler(this.button_list_Click);
            // 
            // button_notes
            // 
            this.button_notes.BackColor = System.Drawing.Color.LightSalmon;
            this.button_notes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.button_notes, "button_notes");
            this.button_notes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_notes.Name = "button_notes";
            this.button_notes.UseVisualStyleBackColor = false;
            this.button_notes.Click += new System.EventHandler(this.button_notes_Click);
            // 
            // panel_controls
            // 
            resources.ApplyResources(this.panel_controls, "panel_controls");
            this.panel_controls.Name = "panel_controls";
            // 
            // AppBase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.panel_controls);
            this.Controls.Add(this.topBorderPanel);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cornerPanel);
            this.Controls.Add(this.button_minimaze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppBase";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.topBorderPanel.ResumeLayout(false);
            this.topBorderPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_minimaze;
        public System.Windows.Forms.Panel topBorderPanel;
        private System.Windows.Forms.Panel cornerPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_list;
        private System.Windows.Forms.Button button_notes;
        private System.Windows.Forms.Panel panel_controls;
    }
}

