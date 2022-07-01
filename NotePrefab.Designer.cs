
namespace LightNotes
{
    partial class NotePrefab
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
            this.tbox_text = new System.Windows.Forms.TextBox();
            this.tbox_title = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbox_text
            // 
            this.tbox_text.BackColor = System.Drawing.SystemColors.Info;
            this.tbox_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbox_text.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbox_text.Location = new System.Drawing.Point(3, 31);
            this.tbox_text.Multiline = true;
            this.tbox_text.Name = "tbox_text";
            this.tbox_text.Size = new System.Drawing.Size(244, 216);
            this.tbox_text.TabIndex = 5;
            this.tbox_text.TextChanged += new System.EventHandler(this.tbox_text_TextChanged);
            // 
            // tbox_title
            // 
            this.tbox_title.BackColor = System.Drawing.SystemColors.Info;
            this.tbox_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbox_title.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbox_title.Location = new System.Drawing.Point(5, 3);
            this.tbox_title.Name = "tbox_title";
            this.tbox_title.Size = new System.Drawing.Size(213, 24);
            this.tbox_title.TabIndex = 7;
            this.tbox_title.TextChanged += new System.EventHandler(this.tbox_title_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(232, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NotePrefab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbox_title);
            this.Controls.Add(this.tbox_text);
            this.Name = "NotePrefab";
            this.Size = new System.Drawing.Size(250, 291);
            this.Load += new System.EventHandler(this.NotePrefab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbox_text;
        private System.Windows.Forms.TextBox tbox_title;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
