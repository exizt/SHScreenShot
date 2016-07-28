namespace Image_Capture
{
    partial class FormCaptureArea
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
            this.imgBackground = new System.Windows.Forms.PictureBox();
            this.imgCaptureScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptureScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBackground
            // 
            this.imgBackground.Location = new System.Drawing.Point(0, 0);
            this.imgBackground.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgBackground.Name = "imgBackground";
            this.imgBackground.Size = new System.Drawing.Size(322, 329);
            this.imgBackground.TabIndex = 0;
            this.imgBackground.TabStop = false;
            // 
            // imgCaptureScreen
            // 
            this.imgCaptureScreen.BackColor = System.Drawing.Color.Turquoise;
            this.imgCaptureScreen.Location = new System.Drawing.Point(0, 0);
            this.imgCaptureScreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgCaptureScreen.Name = "imgCaptureScreen";
            this.imgCaptureScreen.Size = new System.Drawing.Size(237, 242);
            this.imgCaptureScreen.TabIndex = 1;
            this.imgCaptureScreen.TabStop = false;
            this.imgCaptureScreen.Click += new System.EventHandler(this.imgCaptureScreen_Click);
            // 
            // FormCaptureArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 328);
            this.Controls.Add(this.imgCaptureScreen);
            this.Controls.Add(this.imgBackground);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCaptureArea";
            this.ShowIcon = false;
            this.Text = "FormCaptureArea";
            this.TransparencyKey = System.Drawing.Color.Turquoise;
            this.Load += new System.EventHandler(this.FormCaptureArea_Load);
            this.Move += new System.EventHandler(this.FormCaptureArea_Move);
            this.Resize += new System.EventHandler(this.FormCaptureArea_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imgBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptureScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBackground;
        private System.Windows.Forms.PictureBox imgCaptureScreen;
    }
}