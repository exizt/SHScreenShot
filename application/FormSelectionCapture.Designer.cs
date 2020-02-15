namespace Image_Capture
{
    partial class FormSelectionCapture
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picboxCaptureArea = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCaptureArea)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnCapture);
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(5, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(1);
            this.pnlHeader.Size = new System.Drawing.Size(587, 24);
            this.pnlHeader.TabIndex = 2;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelHeader_MouseDown);
            // 
            // btnCapture
            // 
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCapture.Location = new System.Drawing.Point(0, 0);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(107, 23);
            this.btnCapture.TabIndex = 5;
            this.btnCapture.Text = "영역 캡쳐 (저장)";
            this.btnCapture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHeader.Location = new System.Drawing.Point(151, 6);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(57, 12);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "영역 캡쳐";
            this.lblHeader.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(61)))), ((int)(((byte)(81)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(555, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // picboxCaptureArea
            // 
            this.picboxCaptureArea.BackColor = System.Drawing.Color.LimeGreen;
            this.picboxCaptureArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxCaptureArea.Location = new System.Drawing.Point(5, 24);
            this.picboxCaptureArea.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.picboxCaptureArea.Name = "picboxCaptureArea";
            this.picboxCaptureArea.Size = new System.Drawing.Size(587, 503);
            this.picboxCaptureArea.TabIndex = 1;
            this.picboxCaptureArea.TabStop = false;
            // 
            // FormSelectionCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(152)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(597, 537);
            this.Controls.Add(this.picboxCaptureArea);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectionCapture";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.ShowIcon = false;
            this.Text = "영역 캡쳐";
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.Load += new System.EventHandler(this.FormCaptureArea_Load);
            this.ResizeEnd += new System.EventHandler(this.FormCaptureArea_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCaptureArea_KeyDown);
            this.Move += new System.EventHandler(this.FormCaptureArea_Move);
            this.Resize += new System.EventHandler(this.FormCaptureArea_Resize);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCaptureArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picboxCaptureArea;
        private System.Windows.Forms.Button btnCapture;
    }
}