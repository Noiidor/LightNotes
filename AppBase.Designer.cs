
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
            this.button_check = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_download = new System.Windows.Forms.Button();
            this.button_upload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cornerPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_sync = new System.Windows.Forms.Button();
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
            this.topBorderPanel.Controls.Add(this.button_check);
            this.topBorderPanel.Controls.Add(this.button_clear);
            this.topBorderPanel.Controls.Add(this.button_download);
            this.topBorderPanel.Controls.Add(this.button_upload);
            this.topBorderPanel.Controls.Add(this.label2);
            this.topBorderPanel.Controls.Add(this.label1);
            this.topBorderPanel.Name = "topBorderPanel";
            this.topBorderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseDown);
            this.topBorderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseMove);
            this.topBorderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseUp);
            // 
            // button_check
            // 
            resources.ApplyResources(this.button_check, "button_check");
            this.button_check.Name = "button_check";
            this.button_check.UseVisualStyleBackColor = true;
            this.button_check.Click += new System.EventHandler(this.button_check_Click);
            // 
            // button_clear
            // 
            resources.ApplyResources(this.button_clear, "button_clear");
            this.button_clear.Name = "button_clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_download
            // 
            resources.ApplyResources(this.button_download, "button_download");
            this.button_download.Name = "button_download";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // button_upload
            // 
            resources.ApplyResources(this.button_upload, "button_upload");
            this.button_upload.Name = "button_upload";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            this.panel1.Controls.Add(this.button_sync);
            this.panel1.Controls.Add(this.button_list);
            this.panel1.Controls.Add(this.button_notes);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // button_sync
            // 
            resources.ApplyResources(this.button_sync, "button_sync");
            this.button_sync.BackColor = System.Drawing.Color.Transparent;
            this.button_sync.BackgroundImage = global::LightNotes.Properties.Resources.minus;
            this.button_sync.FlatAppearance.BorderSize = 0;
            this.button_sync.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_sync.Name = "button_sync";
            this.button_sync.UseVisualStyleBackColor = false;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click_1);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_check;
        private System.Windows.Forms.Button button_sync;
    }
}

