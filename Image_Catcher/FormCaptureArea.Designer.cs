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
            this.imgBackground.Name = "imgBackground";
            this.imgBackground.Size = new System.Drawing.Size(282, 263);
            this.imgBackground.TabIndex = 0;
            this.imgBackground.TabStop = false;
            // 
            // imgCaptureScreen
            // 
            this.imgCaptureScreen.BackColor = System.Drawing.Color.Turquoise;
            this.imgCaptureScreen.Location = new System.Drawing.Point(0, 0);
            this.imgCaptureScreen.Name = "imgCaptureScreen";
            this.imgCaptureScreen.Size = new System.Drawing.Size(207, 194);
            this.imgCaptureScreen.TabIndex = 1;
            this.imgCaptureScreen.TabStop = false;
            this.imgCaptureScreen.Click += new System.EventHandler(this.imgCaptureScreen_Click);
            // 
            // FormCaptureArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.imgCaptureScreen);
            this.Controls.Add(this.imgBackground);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCaptureArea";
            this.ShowIcon = false;
            this.Text = "FormCaptureArea";
            this.TransparencyKey = System.Drawing.Color.Turquoise;
            this.Load += new System.EventHandler(this.FormCaptureArea_Load);
            this.LocationChanged += new System.EventHandler(this.FormCaptureArea_LocationChanged);
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