
namespace LightNotes
{
    partial class NoteApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteApp));
            this.button_add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.notesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.button_minimaze = new System.Windows.Forms.Button();
            this.topBorderPanel = new System.Windows.Forms.Panel();
            this.cornerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.LightSalmon;
            this.button_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_add.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button_add, "button_add");
            this.button_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_add.Name = "button_add";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            // 
            // notesLayoutPanel
            // 
            resources.ApplyResources(this.notesLayoutPanel, "notesLayoutPanel");
            this.notesLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.notesLayoutPanel.Name = "notesLayoutPanel";
            // 
            // button_delete
            // 
            this.button_delete.BackColor = System.Drawing.Color.LightSalmon;
            this.button_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_delete.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.button_delete, "button_delete");
            this.button_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_delete.Name = "button_delete";
            this.button_delete.UseVisualStyleBackColor = false;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
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
            this.topBorderPanel.Name = "topBorderPanel";
            this.topBorderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseDown);
            this.topBorderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseMove);
            this.topBorderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBorderPanel_MouseUp);
            // 
            // cornerPanel
            // 
            resources.ApplyResources(this.cornerPanel, "cornerPanel");
            this.cornerPanel.BackColor = System.Drawing.Color.Bisque;
            this.cornerPanel.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.cornerPanel.Name = "cornerPanel";
            this.cornerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cornerPanel_MouseDown);
            this.cornerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cornerPanel_MouseMove);
            this.cornerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cornerPanel_MouseUp);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // NoteApp
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_minimaze);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topBorderPanel);
            this.Controls.Add(this.cornerPanel);
            this.Controls.Add(this.notesLayoutPanel);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoteApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel notesLayoutPanel;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_minimaze;
        private System.Windows.Forms.Panel topBorderPanel;
        private System.Windows.Forms.Panel cornerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

