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
            this.picboxBackground = new System.Windows.Forms.PictureBox();
            this.picboxCaptureScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCaptureScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxBackground
            // 
            this.picboxBackground.Location = new System.Drawing.Point(0, 0);
            this.picboxBackground.Name = "picboxBackground";
            this.picboxBackground.Size = new System.Drawing.Size(282, 263);
            this.picboxBackground.TabIndex = 0;
            this.picboxBackground.TabStop = false;
            // 
            // picboxCaptureScreen
            // 
            this.picboxCaptureScreen.BackColor = System.Drawing.Color.LimeGreen;
            this.picboxCaptureScreen.Location = new System.Drawing.Point(0, 0);
            this.picboxCaptureScreen.Name = "picboxCaptureScreen";
            this.picboxCaptureScreen.Size = new System.Drawing.Size(207, 194);
            this.picboxCaptureScreen.TabIndex = 1;
            this.picboxCaptureScreen.TabStop = false;
            this.picboxCaptureScreen.Click += new System.EventHandler(this.ImgCaptureScreen_Click);
            // 
            // FormCaptureArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.picboxCaptureScreen);
            this.Controls.Add(this.picboxBackground);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCaptureArea";
            this.ShowIcon = false;
            this.Text = "영역 캡쳐";
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.Load += new System.EventHandler(this.FormCaptureArea_Load);
            this.Move += new System.EventHandler(this.FormCaptureArea_Move);
            this.Resize += new System.EventHandler(this.FormCaptureArea_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picboxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCaptureScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxBackground;
        private System.Windows.Forms.PictureBox picboxCaptureScreen;
    }
}