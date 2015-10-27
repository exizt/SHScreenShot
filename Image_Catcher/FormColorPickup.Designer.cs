namespace Image_Capture
{
    partial class FormColorPickup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.imgScreen = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // imgScreen
            // 
            this.imgScreen.BackColor = System.Drawing.Color.Turquoise;
            this.imgScreen.ErrorImage = null;
            this.imgScreen.ImageLocation = "0,0";
            this.imgScreen.InitialImage = null;
            this.imgScreen.Location = new System.Drawing.Point(0, 0);
            this.imgScreen.Name = "imgScreen";
            this.imgScreen.Size = new System.Drawing.Size(300, 300);
            this.imgScreen.TabIndex = 0;
            this.imgScreen.TabStop = false;
            this.imgScreen.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Turquoise;
            this.pictureBox1.Image = global::Image_Capture.Properties.Resources.Image3;
            this.pictureBox1.Location = new System.Drawing.Point(150, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormColorPickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imgScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormColorPickup";
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Turquoise;
            this.Load += new System.EventHandler(this.FormColorPickup_Load);
            this.Click += new System.EventHandler(this.FormColorPickup_Click);
            ((System.ComponentModel.ISupportInitialize)(this.imgScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox imgScreen;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}