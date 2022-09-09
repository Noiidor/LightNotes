
namespace LightNotes
{
    partial class ListControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button_add_tab = new System.Windows.Forms.Button();
            this.button_delete_tab = new System.Windows.Forms.Button();
            this.button_rename_tab = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_load = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(25, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 725);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
            // 
            // button_add_tab
            // 
            this.button_add_tab.BackColor = System.Drawing.Color.PeachPuff;
            this.button_add_tab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_add_tab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_add_tab.FlatAppearance.BorderSize = 0;
            this.button_add_tab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add_tab.Location = new System.Drawing.Point(1, 0);
            this.button_add_tab.Name = "button_add_tab";
            this.button_add_tab.Size = new System.Drawing.Size(24, 23);
            this.button_add_tab.TabIndex = 5;
            this.button_add_tab.Text = "+";
            this.button_add_tab.UseVisualStyleBackColor = false;
            this.button_add_tab.Click += new System.EventHandler(this.button_add_tab_Click);
            // 
            // button_delete_tab
            // 
            this.button_delete_tab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_delete_tab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_delete_tab.FlatAppearance.BorderSize = 0;
            this.button_delete_tab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete_tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_delete_tab.Location = new System.Drawing.Point(1, 26);
            this.button_delete_tab.Name = "button_delete_tab";
            this.button_delete_tab.Size = new System.Drawing.Size(24, 23);
            this.button_delete_tab.TabIndex = 6;
            this.button_delete_tab.Text = "-";
            this.button_delete_tab.UseVisualStyleBackColor = true;
            this.button_delete_tab.Click += new System.EventHandler(this.button_delete_tab_Click);
            // 
            // button_rename_tab
            // 
            this.button_rename_tab.Location = new System.Drawing.Point(0, 55);
            this.button_rename_tab.Name = "button_rename_tab";
            this.button_rename_tab.Size = new System.Drawing.Size(27, 23);
            this.button_rename_tab.TabIndex = 7;
            this.button_rename_tab.Text = "R";
            this.button_rename_tab.UseVisualStyleBackColor = true;
            this.button_rename_tab.Visible = false;
            this.button_rename_tab.Click += new System.EventHandler(this.button_rename_tab_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(0, 84);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(27, 23);
            this.button_save.TabIndex = 8;
            this.button_save.Text = "S";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Visible = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(0, 113);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(27, 23);
            this.button_load.TabIndex = 10;
            this.button_load.Text = "L";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Visible = false;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(25, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 724);
            this.panel1.TabIndex = 11;
            // 
            // ListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_rename_tab);
            this.Controls.Add(this.button_delete_tab);
            this.Controls.Add(this.button_add_tab);
            this.Controls.Add(this.tabControl1);
            this.Name = "ListControl";
            this.Size = new System.Drawing.Size(785, 725);
            this.Load += new System.EventHandler(this.ListControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button_add_tab;
        private System.Windows.Forms.Button button_delete_tab;
        private System.Windows.Forms.Button button_rename_tab;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Panel panel1;
    }
}
