
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
            this.button_delete = new System.Windows.Forms.Button();
            this.tbox_text = new System.Windows.Forms.TextBox();
            this.tbox_title = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_delete
            // 
            this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_delete.Location = new System.Drawing.Point(223, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(24, 30);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "X";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // tbox_text
            // 
            this.tbox_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbox_text.Location = new System.Drawing.Point(3, 40);
            this.tbox_text.Multiline = true;
            this.tbox_text.Name = "tbox_text";
            this.tbox_text.Size = new System.Drawing.Size(244, 207);
            this.tbox_text.TabIndex = 5;
            this.tbox_text.Text = "Text";
            // 
            // tbox_title
            // 
            this.tbox_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbox_title.Location = new System.Drawing.Point(4, 4);
            this.tbox_title.Name = "tbox_title";
            this.tbox_title.Size = new System.Drawing.Size(213, 30);
            this.tbox_title.TabIndex = 7;
            this.tbox_title.Text = "Title";
            // 
            // NotePrefab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbox_title);
            this.Controls.Add(this.tbox_text);
            this.Controls.Add(this.button_delete);
            this.Name = "NotePrefab";
            this.Size = new System.Drawing.Size(250, 250);
            this.Load += new System.EventHandler(this.NotePrefab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.TextBox tbox_text;
        private System.Windows.Forms.TextBox tbox_title;
    }
}
