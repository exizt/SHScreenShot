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
            if (disposing && (resultImage != null))
            {
                resultImage.Dispose();
            }
            if (disposing && (previewImage != null))
            {
                previewImage.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnFullCapture = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.FolderBD_SShot = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCaptureArea = new System.Windows.Forms.Button();
            this.imgPreview = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFullCapture
            // 
            this.btnFullCapture.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFullCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullCapture.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFullCapture.ForeColor = System.Drawing.Color.White;
            this.btnFullCapture.Location = new System.Drawing.Point(25, 21);
            this.btnFullCapture.Name = "btnFullCapture";
            this.btnFullCapture.Size = new System.Drawing.Size(144, 39);
            this.btnFullCapture.TabIndex = 1;
            this.btnFullCapture.Text = "전체캡처";
            this.btnFullCapture.UseVisualStyleBackColor = false;
            this.btnFullCapture.Click += new System.EventHandler(this.btnFullCapture_Click);
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderOpen.Location = new System.Drawing.Point(350, 97);
            this.btnFolderOpen.Name = "btnFolderOpen";
            this.btnFolderOpen.Size = new System.Drawing.Size(108, 39);
            this.btnFolderOpen.TabIndex = 2;
            this.btnFolderOpen.Text = "저장된 폴더열기";
            this.btnFolderOpen.UseVisualStyleBackColor = false;
            this.btnFolderOpen.Click += new System.EventHandler(this.btnFolderOpen_Click);
            // 
            // btnCaptureArea
            // 
            this.btnCaptureArea.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCaptureArea.FlatAppearance.BorderSize = 0;
            this.btnCaptureArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureArea.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCaptureArea.ForeColor = System.Drawing.Color.White;
            this.btnCaptureArea.Location = new System.Drawing.Point(175, 21);
            this.btnCaptureArea.Name = "btnCaptureArea";
            this.btnCaptureArea.Size = new System.Drawing.Size(156, 39);
            this.btnCaptureArea.TabIndex = 17;
            this.btnCaptureArea.Text = "영역캡처";
            this.btnCaptureArea.UseVisualStyleBackColor = false;
            this.btnCaptureArea.Click += new System.EventHandler(this.btnCaptureArea_Click);
            // 
            // imgPreview
            // 
            this.imgPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPreview.Location = new System.Drawing.Point(25, 97);
            this.imgPreview.Name = "imgPreview";
            this.imgPreview.Size = new System.Drawing.Size(306, 191);
            this.imgPreview.TabIndex = 18;
            this.imgPreview.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "종료";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "미리보기";
            // 
            // btnAbout
            // 
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Location = new System.Drawing.Point(350, 142);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(108, 39);
            this.btnAbout.TabIndex = 20;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 319);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgPreview);
            this.Controls.Add(this.btnCaptureArea);
            this.Controls.Add(this.btnFolderOpen);
            this.Controls.Add(this.btnFullCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "SH Screen Capture";
            this.Activated += new System.EventHandler(this.MainForm_activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imgPreview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFullCapture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnFolderOpen;
        private System.Windows.Forms.FolderBrowserDialog FolderBD_SShot;
        private System.Windows.Forms.Button btnCaptureArea;
        public System.Windows.Forms.PictureBox imgPreview;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbout;
    }
}

