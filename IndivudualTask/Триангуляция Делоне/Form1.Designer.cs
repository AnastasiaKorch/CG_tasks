namespace Триангуляция_Делоне
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
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
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.butt_clear = new System.Windows.Forms.Button();
            this.butt_triangulator = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(634, 537);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // butt_clear
            // 
            this.butt_clear.Location = new System.Drawing.Point(655, 54);
            this.butt_clear.Name = "butt_clear";
            this.butt_clear.Size = new System.Drawing.Size(117, 23);
            this.butt_clear.TabIndex = 10;
            this.butt_clear.Text = "Очистить";
            this.butt_clear.UseVisualStyleBackColor = true;
            this.butt_clear.Click += new System.EventHandler(this.butt_clear_Click);
            // 
            // butt_triangulator
            // 
            this.butt_triangulator.Location = new System.Drawing.Point(655, 12);
            this.butt_triangulator.Name = "butt_triangulator";
            this.butt_triangulator.Size = new System.Drawing.Size(117, 36);
            this.butt_triangulator.TabIndex = 29;
            this.butt_triangulator.Text = "Триангулировать";
            this.butt_triangulator.UseVisualStyleBackColor = true;
            this.butt_triangulator.Click += new System.EventHandler(this.butt_triangulator_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.butt_triangulator);
            this.Controls.Add(this.butt_clear);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Триангуляция Делоне";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button butt_clear;
		private System.Windows.Forms.Button butt_triangulator;

	}
}

