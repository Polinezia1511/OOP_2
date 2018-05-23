namespace LABA2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmb_choise = new System.Windows.Forms.ComboBox();
            this.open_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.cmb_themes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(770, 449);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp_1);
            // 
            // cmb_choise
            // 
            this.cmb_choise.BackColor = System.Drawing.Color.LightBlue;
            this.cmb_choise.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmb_choise.FormattingEnabled = true;
            this.cmb_choise.Items.AddRange(new object[] {
            "Эллипс",
            "Линия",
            "Прямоугольник",
            "Квадрат"});
            this.cmb_choise.Location = new System.Drawing.Point(23, 484);
            this.cmb_choise.Name = "cmb_choise";
            this.cmb_choise.Size = new System.Drawing.Size(147, 24);
            this.cmb_choise.TabIndex = 1;
            this.cmb_choise.SelectionChangeCommitted += new System.EventHandler(this.cmb_choise_SelectionChangeCommitted);
            // 
            // open_btn
            // 
            this.open_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.open_btn.Location = new System.Drawing.Point(547, 477);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(89, 37);
            this.open_btn.TabIndex = 3;
            this.open_btn.Text = "Open";
            this.open_btn.UseVisualStyleBackColor = false;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save_btn.Location = new System.Drawing.Point(659, 476);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(89, 38);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clear_btn.Location = new System.Drawing.Point(420, 476);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(97, 39);
            this.clear_btn.TabIndex = 5;
            this.clear_btn.Text = "Clear";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // cmb_themes
            // 
            this.cmb_themes.BackColor = System.Drawing.Color.LightBlue;
            this.cmb_themes.FormattingEnabled = true;
            this.cmb_themes.Items.AddRange(new object[] {
            "Dark",
            "Light"});
            this.cmb_themes.Location = new System.Drawing.Point(207, 484);
            this.cmb_themes.Name = "cmb_themes";
            this.cmb_themes.Size = new System.Drawing.Size(147, 24);
            this.cmb_themes.TabIndex = 6;
            this.cmb_themes.SelectedIndexChanged += new System.EventHandler(this.cmb_themes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Themes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Figures";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(771, 541);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_themes);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.open_btn);
            this.Controls.Add(this.cmb_choise);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmb_choise;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.ComboBox cmb_themes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

