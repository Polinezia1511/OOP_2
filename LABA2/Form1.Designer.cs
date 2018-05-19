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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmb_choise = new System.Windows.Forms.ComboBox();
            this.btn_draw = new System.Windows.Forms.Button();
            this.open_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
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
            this.cmb_choise.BackColor = System.Drawing.SystemColors.Info;
            this.cmb_choise.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmb_choise.FormattingEnabled = true;
            this.cmb_choise.Items.AddRange(new object[] {
            "Эллипс",
            "Линия",
            "Прямоугольник",
            "Квадрат"});
            this.cmb_choise.Location = new System.Drawing.Point(12, 475);
            this.cmb_choise.Name = "cmb_choise";
            this.cmb_choise.Size = new System.Drawing.Size(147, 24);
            this.cmb_choise.TabIndex = 1;
            this.cmb_choise.SelectionChangeCommitted += new System.EventHandler(this.cmb_choise_SelectionChangeCommitted);
            // 
            // btn_draw
            // 
            this.btn_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btn_draw.Image = global::LABA2.Properties.Resources._36;
            this.btn_draw.Location = new System.Drawing.Point(165, 471);
            this.btn_draw.Name = "btn_draw";
            this.btn_draw.Size = new System.Drawing.Size(153, 28);
            this.btn_draw.TabIndex = 2;
            this.btn_draw.Text = "Нарисовать";
            this.btn_draw.UseVisualStyleBackColor = true;
            // 
            // open_btn
            // 
            this.open_btn.Location = new System.Drawing.Point(443, 492);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(89, 37);
            this.open_btn.TabIndex = 3;
            this.open_btn.Text = "Open";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(611, 491);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(82, 38);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(771, 541);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.open_btn);
            this.Controls.Add(this.btn_draw);
            this.Controls.Add(this.cmb_choise);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmb_choise;
        private System.Windows.Forms.Button btn_draw;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Button save_btn;
    }
}

