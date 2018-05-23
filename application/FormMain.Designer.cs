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
            if (disposing && (ScreenImageDrawer != null))
            {
                ScreenImageDrawer.Dispose();
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
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.folderbrowserDialog_SShot = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCaptureArea = new System.Windows.Forms.Button();
            this.picboxPreview = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPreviewTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveDirectoryPath = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.switchQuickSaveMode = new Image_Capture.SwitchCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFullCapture
            // 
            this.btnFullCapture.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFullCapture.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnFullCapture.FlatAppearance.BorderSize = 0;
            this.btnFullCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullCapture.Font = new System.Drawing.Font("돋움", 11F, System.Drawing.FontStyle.Bold);
            this.btnFullCapture.ForeColor = System.Drawing.Color.White;
            this.btnFullCapture.Location = new System.Drawing.Point(1, 1);
            this.btnFullCapture.Name = "btnFullCapture";
            this.btnFullCapture.Size = new System.Drawing.Size(109, 45);
            this.btnFullCapture.TabIndex = 1;
            this.btnFullCapture.Text = "스크린캡쳐";
            this.btnFullCapture.UseVisualStyleBackColor = false;
            this.btnFullCapture.Click += new System.EventHandler(this.BtnFullCapture_Click);
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.BackColor = System.Drawing.Color.DarkGray;
            this.btnFolderOpen.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFolderOpen.FlatAppearance.BorderSize = 0;
            this.btnFolderOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderOpen.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFolderOpen.ForeColor = System.Drawing.Color.White;
            this.btnFolderOpen.Location = new System.Drawing.Point(1, 90);
            this.btnFolderOpen.Name = "btnFolderOpen";
            this.btnFolderOpen.Size = new System.Drawing.Size(109, 43);
            this.btnFolderOpen.TabIndex = 2;
            this.btnFolderOpen.Text = "저장된 폴더열기";
            this.btnFolderOpen.UseVisualStyleBackColor = false;
            this.btnFolderOpen.Click += new System.EventHandler(this.BtnFolderOpen_Click);
            // 
            // btnCaptureArea
            // 
            this.btnCaptureArea.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCaptureArea.FlatAppearance.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.btnCaptureArea.FlatAppearance.BorderSize = 0;
            this.btnCaptureArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureArea.Font = new System.Drawing.Font("돋움", 11F, System.Drawing.FontStyle.Bold);
            this.btnCaptureArea.ForeColor = System.Drawing.Color.White;
            this.btnCaptureArea.Location = new System.Drawing.Point(1, 47);
            this.btnCaptureArea.Name = "btnCaptureArea";
            this.btnCaptureArea.Size = new System.Drawing.Size(109, 42);
            this.btnCaptureArea.TabIndex = 17;
            this.btnCaptureArea.Text = "영역캡처";
            this.btnCaptureArea.UseVisualStyleBackColor = false;
            this.btnCaptureArea.Click += new System.EventHandler(this.BtnCaptureArea_Click);
            // 
            // picboxPreview
            // 
            this.picboxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxPreview.Location = new System.Drawing.Point(112, 1);
            this.picboxPreview.Name = "picboxPreview";
            this.picboxPreview.Size = new System.Drawing.Size(206, 132);
            this.picboxPreview.TabIndex = 18;
            this.picboxPreview.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "스크린캡쳐";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // labelPreviewTitle
            // 
            this.labelPreviewTitle.AutoSize = true;
            this.labelPreviewTitle.Location = new System.Drawing.Point(265, 135);
            this.labelPreviewTitle.Name = "labelPreviewTitle";
            this.labelPreviewTitle.Size = new System.Drawing.Size(53, 12);
            this.labelPreviewTitle.TabIndex = 19;
            this.labelPreviewTitle.Text = "미리보기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "폴더 경로";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "퀵 세이브 모드";
            // 
            // saveDirectoryPath
            // 
            this.saveDirectoryPath.AutoSize = true;
            this.saveDirectoryPath.Location = new System.Drawing.Point(6, 226);
            this.saveDirectoryPath.Name = "saveDirectoryPath";
            this.saveDirectoryPath.Size = new System.Drawing.Size(145, 12);
            this.saveDirectoryPath.TabIndex = 27;
            this.saveDirectoryPath.Text = "[폴더경로가 들어갈 위치]";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(243, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "단축키";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnShortcutGuide_Click);
            // 
            // switchQuickSaveMode
            // 
            this.switchQuickSaveMode.ForeColor = System.Drawing.Color.DodgerBlue;
            this.switchQuickSaveMode.Location = new System.Drawing.Point(8, 166);
            this.switchQuickSaveMode.Name = "switchQuickSaveMode";
            this.switchQuickSaveMode.Padding = new System.Windows.Forms.Padding(1);
            this.switchQuickSaveMode.Size = new System.Drawing.Size(35, 21);
            this.switchQuickSaveMode.TabIndex = 26;
            this.switchQuickSaveMode.Text = "switchCheckBox1";
            this.switchQuickSaveMode.UseVisualStyleBackColor = true;
            this.switchQuickSaveMode.CheckedChanged += new System.EventHandler(this.SwitchQuickSaveMode_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(319, 253);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveDirectoryPath);
            this.Controls.Add(this.switchQuickSaveMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPreviewTitle);
            this.Controls.Add(this.picboxPreview);
            this.Controls.Add(this.btnCaptureArea);
            this.Controls.Add(this.btnFolderOpen);
            this.Controls.Add(this.btnFullCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Image_Capture.Properties.Resources.MainIcon;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "SH Screen Capture";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPreviewTitle;
        private System.Windows.Forms.Button btnFullCapture;
        private System.Windows.Forms.Button btnFolderOpen;
        private System.Windows.Forms.Button btnCaptureArea;
        public System.Windows.Forms.PictureBox picboxPreview;
        private System.Windows.Forms.FolderBrowserDialog folderbrowserDialog_SShot;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private SwitchCheckBox switchQuickSaveMode;
        private System.Windows.Forms.Label saveDirectoryPath;
        private System.Windows.Forms.Button button1;
    }
}

