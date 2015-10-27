namespace Image_Capture
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCapture = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.FolderBD_SShot = new System.Windows.Forms.FolderBrowserDialog();
            this.txtColorCodeR = new System.Windows.Forms.TextBox();
            this.label_R = new System.Windows.Forms.Label();
            this.label_G = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.txtColorCodeB = new System.Windows.Forms.TextBox();
            this.txtColorCodeG = new System.Windows.Forms.TextBox();
            this.txtColorCodeFF = new System.Windows.Forms.TextBox();
            this.label_FF = new System.Windows.Forms.Label();
            this.btnPickup = new System.Windows.Forms.Button();
            this.imgResultColor = new System.Windows.Forms.PictureBox();
            this.btnCaptureArea = new System.Windows.Forms.Button();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgResultColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.White;
            this.btnCapture.Location = new System.Drawing.Point(235, 4);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(89, 58);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "전체캡처";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.Location = new System.Drawing.Point(235, 63);
            this.btnFolderOpen.Name = "btnFolderOpen";
            this.btnFolderOpen.Size = new System.Drawing.Size(89, 29);
            this.btnFolderOpen.TabIndex = 2;
            this.btnFolderOpen.Text = "폴더열기";
            this.btnFolderOpen.UseVisualStyleBackColor = false;
            this.btnFolderOpen.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // txtColorCodeR
            // 
            this.txtColorCodeR.Location = new System.Drawing.Point(21, 158);
            this.txtColorCodeR.Name = "txtColorCodeR";
            this.txtColorCodeR.Size = new System.Drawing.Size(34, 21);
            this.txtColorCodeR.TabIndex = 11;
            // 
            // label_R
            // 
            this.label_R.AutoSize = true;
            this.label_R.Location = new System.Drawing.Point(6, 163);
            this.label_R.Name = "label_R";
            this.label_R.Size = new System.Drawing.Size(13, 12);
            this.label_R.TabIndex = 12;
            this.label_R.Text = "R";
            // 
            // label_G
            // 
            this.label_G.AutoSize = true;
            this.label_G.Location = new System.Drawing.Point(61, 163);
            this.label_G.Name = "label_G";
            this.label_G.Size = new System.Drawing.Size(14, 12);
            this.label_G.TabIndex = 12;
            this.label_G.Text = "G";
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Location = new System.Drawing.Point(120, 163);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(13, 12);
            this.label_B.TabIndex = 12;
            this.label_B.Text = "B";
            // 
            // txtColorCodeB
            // 
            this.txtColorCodeB.Location = new System.Drawing.Point(135, 158);
            this.txtColorCodeB.Name = "txtColorCodeB";
            this.txtColorCodeB.Size = new System.Drawing.Size(35, 21);
            this.txtColorCodeB.TabIndex = 13;
            // 
            // txtColorCodeG
            // 
            this.txtColorCodeG.Location = new System.Drawing.Point(77, 158);
            this.txtColorCodeG.Name = "txtColorCodeG";
            this.txtColorCodeG.Size = new System.Drawing.Size(35, 21);
            this.txtColorCodeG.TabIndex = 12;
            // 
            // txtColorCodeFF
            // 
            this.txtColorCodeFF.BackColor = System.Drawing.Color.White;
            this.txtColorCodeFF.Location = new System.Drawing.Point(249, 158);
            this.txtColorCodeFF.Name = "txtColorCodeFF";
            this.txtColorCodeFF.ReadOnly = true;
            this.txtColorCodeFF.Size = new System.Drawing.Size(73, 21);
            this.txtColorCodeFF.TabIndex = 14;
            // 
            // label_FF
            // 
            this.label_FF.AutoSize = true;
            this.label_FF.Location = new System.Drawing.Point(236, 162);
            this.label_FF.Name = "label_FF";
            this.label_FF.Size = new System.Drawing.Size(11, 12);
            this.label_FF.TabIndex = 14;
            this.label_FF.Text = "#";
            // 
            // btnPickup
            // 
            this.btnPickup.Location = new System.Drawing.Point(235, 93);
            this.btnPickup.Name = "btnPickup";
            this.btnPickup.Size = new System.Drawing.Size(89, 29);
            this.btnPickup.TabIndex = 15;
            this.btnPickup.Text = "색상추출";
            this.btnPickup.UseVisualStyleBackColor = false;
            this.btnPickup.Click += new System.EventHandler(this.btnSpoidColor_Click);
            // 
            // imgResultColor
            // 
            this.imgResultColor.BackColor = System.Drawing.Color.White;
            this.imgResultColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgResultColor.Location = new System.Drawing.Point(186, 157);
            this.imgResultColor.Name = "imgResultColor";
            this.imgResultColor.Size = new System.Drawing.Size(44, 22);
            this.imgResultColor.TabIndex = 16;
            this.imgResultColor.TabStop = false;
            // 
            // btnCaptureArea
            // 
            this.btnCaptureArea.Location = new System.Drawing.Point(235, 123);
            this.btnCaptureArea.Name = "btnCaptureArea";
            this.btnCaptureArea.Size = new System.Drawing.Size(89, 29);
            this.btnCaptureArea.TabIndex = 17;
            this.btnCaptureArea.Text = "영역캡처";
            this.btnCaptureArea.UseVisualStyleBackColor = false;
            this.btnCaptureArea.Click += new System.EventHandler(this.btnCaptureArea_Click);
            // 
            // imgPreview
            // 
            this.imgPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPreview.Location = new System.Drawing.Point(6, 4);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(223, 148);
            this.imgPreview.TabIndex = 18;
            this.imgPreview.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 190);
            this.Controls.Add(this.imgPreview);
            this.Controls.Add(this.btnCaptureArea);
            this.Controls.Add(this.imgResultColor);
            this.Controls.Add(this.btnPickup);
            this.Controls.Add(this.label_FF);
            this.Controls.Add(this.txtColorCodeFF);
            this.Controls.Add(this.label_B);
            this.Controls.Add(this.label_G);
            this.Controls.Add(this.label_R);
            this.Controls.Add(this.txtColorCodeG);
            this.Controls.Add(this.txtColorCodeB);
            this.Controls.Add(this.txtColorCodeR);
            this.Controls.Add(this.btnFolderOpen);
            this.Controls.Add(this.btnCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Image_Capture.Properties.Resources.MainIcon;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "프로그램명";
            this.Activated += new System.EventHandler(this.MainForm_activated);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgResultColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnFolderOpen;
        private System.Windows.Forms.FolderBrowserDialog FolderBD_SShot;
        private System.Windows.Forms.Label label_R;
        private System.Windows.Forms.Label label_G;
        private System.Windows.Forms.Label label_B;
        public System.Windows.Forms.TextBox txtColorCodeR;
        public System.Windows.Forms.TextBox txtColorCodeB;
        public System.Windows.Forms.TextBox txtColorCodeG;
        public System.Windows.Forms.TextBox txtColorCodeFF;
        private System.Windows.Forms.Label label_FF;
        private System.Windows.Forms.Button btnPickup;
        public System.Windows.Forms.PictureBox imgResultColor;
        private System.Windows.Forms.Button btnCaptureArea;
        public System.Windows.Forms.PictureBox imgPreview;

    }
}

