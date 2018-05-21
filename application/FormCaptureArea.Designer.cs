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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCaptureScreen)).BeginInit();
            this.headerPanel.SuspendLayout();
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
            this.picboxCaptureScreen.Location = new System.Drawing.Point(12, 30);
            this.picboxCaptureScreen.Name = "picboxCaptureScreen";
            this.picboxCaptureScreen.Size = new System.Drawing.Size(207, 194);
            this.picboxCaptureScreen.TabIndex = 1;
            this.picboxCaptureScreen.TabStop = false;
            this.picboxCaptureScreen.Click += new System.EventHandler(this.ImgCaptureScreen_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.btnClose);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(597, 24);
            this.headerPanel.TabIndex = 2;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(566, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // FormCaptureArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.picboxCaptureScreen);
            this.Controls.Add(this.picboxBackground);
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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