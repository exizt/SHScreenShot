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
            this.btnScrCapture = new System.Windows.Forms.Button();
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.folderbrowserDialog_SShot = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectionCapture = new System.Windows.Forms.Button();
            this.picboxPreview = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAutoSave = new System.Windows.Forms.Label();
            this.currentSavePath = new System.Windows.Forms.Label();
            this.btnFolderChange = new System.Windows.Forms.Button();
            this.pnlSideNav = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlTopNav = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.btnMin = new System.Windows.Forms.Button();
            this.swcAutoSave = new Image_Capture.SwitchCheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSettingCancel = new System.Windows.Forms.Button();
            this.btnSettingSave = new System.Windows.Forms.Button();
            this.pnlDirOptions = new System.Windows.Forms.Panel();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.tboxDefaultPathOption = new System.Windows.Forms.TextBox();
            this.btnChangeDefaultPath = new System.Windows.Forms.Button();
            this.pnlFileNameOptions = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPrefix = new System.Windows.Forms.TextBox();
            this.pnlFnAddsetOptions = new System.Windows.Forms.Panel();
            this.rbAddsetPosEnd = new System.Windows.Forms.RadioButton();
            this.rbAddsetPosMiddle = new System.Windows.Forms.RadioButton();
            this.cboxAddsetTypes = new System.Windows.Forms.ComboBox();
            this.rbAddsetPosFront = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxSuffix = new System.Windows.Forms.TextBox();
            this.pnlImageTypeOptions = new System.Windows.Forms.Panel();
            this.rbImageExtPng = new System.Windows.Forms.RadioButton();
            this.rbImageExtJpg = new System.Windows.Forms.RadioButton();
            this.rbImageExtBmp = new System.Windows.Forms.RadioButton();
            this.rbImageExtGif = new System.Windows.Forms.RadioButton();
            this.lblImageType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlSideNav.SuspendLayout();
            this.pnlTopNav.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDirOptions.SuspendLayout();
            this.pnlFileNameOptions.SuspendLayout();
            this.pnlFnAddsetOptions.SuspendLayout();
            this.pnlImageTypeOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScrCapture
            // 
            this.btnScrCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnScrCapture.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnScrCapture.FlatAppearance.BorderSize = 0;
            this.btnScrCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrCapture.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnScrCapture.ForeColor = System.Drawing.Color.White;
            this.btnScrCapture.Image = global::Image_Capture.Properties.Resources.fullscreen_30px_wh;
            this.btnScrCapture.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnScrCapture.Location = new System.Drawing.Point(0, 0);
            this.btnScrCapture.Name = "btnScrCapture";
            this.btnScrCapture.Size = new System.Drawing.Size(110, 62);
            this.btnScrCapture.TabIndex = 1;
            this.btnScrCapture.Text = "화면캡쳐";
            this.btnScrCapture.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnScrCapture.UseVisualStyleBackColor = false;
            this.btnScrCapture.Click += new System.EventHandler(this.BtnFullCapture_Click);
            // 
            // btnFolderOpen
            // 
            this.btnFolderOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnFolderOpen.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFolderOpen.FlatAppearance.BorderSize = 0;
            this.btnFolderOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFolderOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderOpen.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFolderOpen.ForeColor = System.Drawing.Color.DimGray;
            this.btnFolderOpen.Location = new System.Drawing.Point(74, 308);
            this.btnFolderOpen.Name = "btnFolderOpen";
            this.btnFolderOpen.Size = new System.Drawing.Size(66, 23);
            this.btnFolderOpen.TabIndex = 2;
            this.btnFolderOpen.Text = "폴더열기";
            this.btnFolderOpen.UseVisualStyleBackColor = false;
            this.btnFolderOpen.Click += new System.EventHandler(this.BtnFolderOpen_Click);
            // 
            // btnSelectionCapture
            // 
            this.btnSelectionCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectionCapture.FlatAppearance.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.btnSelectionCapture.FlatAppearance.BorderSize = 0;
            this.btnSelectionCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectionCapture.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectionCapture.ForeColor = System.Drawing.Color.White;
            this.btnSelectionCapture.Image = global::Image_Capture.Properties.Resources.fullscreen_sect_30px_wh;
            this.btnSelectionCapture.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectionCapture.Location = new System.Drawing.Point(0, 77);
            this.btnSelectionCapture.Name = "btnSelectionCapture";
            this.btnSelectionCapture.Size = new System.Drawing.Size(110, 66);
            this.btnSelectionCapture.TabIndex = 17;
            this.btnSelectionCapture.Text = "영역캡처";
            this.btnSelectionCapture.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelectionCapture.UseVisualStyleBackColor = false;
            this.btnSelectionCapture.Click += new System.EventHandler(this.BtnSelectionCapture_Click);
            // 
            // picboxPreview
            // 
            this.picboxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxPreview.Location = new System.Drawing.Point(9, 9);
            this.picboxPreview.Name = "picboxPreview";
            this.picboxPreview.Size = new System.Drawing.Size(316, 272);
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
            // lblAutoSave
            // 
            this.lblAutoSave.AutoSize = true;
            this.lblAutoSave.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAutoSave.ForeColor = System.Drawing.Color.White;
            this.lblAutoSave.Location = new System.Drawing.Point(9, 33);
            this.lblAutoSave.Name = "lblAutoSave";
            this.lblAutoSave.Size = new System.Drawing.Size(55, 15);
            this.lblAutoSave.TabIndex = 25;
            this.lblAutoSave.Text = "자동저장";
            // 
            // currentSavePath
            // 
            this.currentSavePath.AutoSize = true;
            this.currentSavePath.Location = new System.Drawing.Point(12, 293);
            this.currentSavePath.Name = "currentSavePath";
            this.currentSavePath.Size = new System.Drawing.Size(145, 12);
            this.currentSavePath.TabIndex = 27;
            this.currentSavePath.Text = "[폴더경로가 들어갈 위치]";
            // 
            // btnFolderChange
            // 
            this.btnFolderChange.BackColor = System.Drawing.Color.Transparent;
            this.btnFolderChange.FlatAppearance.BorderSize = 0;
            this.btnFolderChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolderChange.ForeColor = System.Drawing.Color.DimGray;
            this.btnFolderChange.Location = new System.Drawing.Point(5, 308);
            this.btnFolderChange.Name = "btnFolderChange";
            this.btnFolderChange.Size = new System.Drawing.Size(63, 23);
            this.btnFolderChange.TabIndex = 29;
            this.btnFolderChange.Text = "폴더변경";
            this.btnFolderChange.UseVisualStyleBackColor = false;
            this.btnFolderChange.Click += new System.EventHandler(this.BtnFolderChange_Click);
            // 
            // pnlSideNav
            // 
            this.pnlSideNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlSideNav.Controls.Add(this.btnSettings);
            this.pnlSideNav.Controls.Add(this.btnScrCapture);
            this.pnlSideNav.Controls.Add(this.btnSelectionCapture);
            this.pnlSideNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideNav.Location = new System.Drawing.Point(0, 50);
            this.pnlSideNav.Name = "pnlSideNav";
            this.pnlSideNav.Size = new System.Drawing.Size(110, 427);
            this.pnlSideNav.TabIndex = 30;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::Image_Capture.Properties.Resources.sh_settings_30px;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSettings.Location = new System.Drawing.Point(0, 339);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(110, 61);
            this.btnSettings.TabIndex = 18;
            this.btnSettings.Text = "설정";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // pnlTopNav
            // 
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlTopNav.Controls.Add(this.pnlTopRight);
            this.pnlTopNav.Controls.Add(this.label1);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Size = new System.Drawing.Size(443, 50);
            this.pnlTopNav.TabIndex = 31;
            this.pnlTopNav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTopNav_MouseDown);
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.btnMin);
            this.pnlTopRight.Controls.Add(this.swcAutoSave);
            this.pnlTopRight.Controls.Add(this.btnClose);
            this.pnlTopRight.Controls.Add(this.lblAutoSave);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTopRight.Location = new System.Drawing.Point(329, 0);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(114, 50);
            this.pnlTopRight.TabIndex = 27;
            this.pnlTopRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTopRight_MouseDown);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("굴림", 12F);
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(46, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 23);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "_";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.BtnMin_Click);
            // 
            // swcAutoSave
            // 
            this.swcAutoSave.ForeColor = System.Drawing.Color.DodgerBlue;
            this.swcAutoSave.Location = new System.Drawing.Point(66, 28);
            this.swcAutoSave.Name = "swcAutoSave";
            this.swcAutoSave.Padding = new System.Windows.Forms.Padding(1);
            this.swcAutoSave.Size = new System.Drawing.Size(35, 21);
            this.swcAutoSave.TabIndex = 26;
            this.swcAutoSave.Text = "switchCheckBox1";
            this.swcAutoSave.UseVisualStyleBackColor = true;
            this.swcAutoSave.CheckedChanged += new System.EventHandler(this.SwitchQuickSaveMode_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(84, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✖";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SH 스크린샷";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.picboxPreview);
            this.pnlMain.Controls.Add(this.currentSavePath);
            this.pnlMain.Controls.Add(this.btnFolderChange);
            this.pnlMain.Controls.Add(this.btnFolderOpen);
            this.pnlMain.Location = new System.Drawing.Point(110, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(333, 427);
            this.pnlMain.TabIndex = 32;
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoScroll = true;
            this.pnlSettings.Controls.Add(this.panel1);
            this.pnlSettings.Controls.Add(this.pnlDirOptions);
            this.pnlSettings.Controls.Add(this.pnlFileNameOptions);
            this.pnlSettings.Controls.Add(this.pnlImageTypeOptions);
            this.pnlSettings.Location = new System.Drawing.Point(110, 50);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(334, 585);
            this.pnlSettings.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSettingCancel);
            this.panel1.Controls.Add(this.btnSettingSave);
            this.panel1.Location = new System.Drawing.Point(10, 353);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 47);
            this.panel1.TabIndex = 29;
            // 
            // btnSettingCancel
            // 
            this.btnSettingCancel.FlatAppearance.BorderSize = 0;
            this.btnSettingCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingCancel.Location = new System.Drawing.Point(175, 14);
            this.btnSettingCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettingCancel.Name = "btnSettingCancel";
            this.btnSettingCancel.Size = new System.Drawing.Size(39, 23);
            this.btnSettingCancel.TabIndex = 26;
            this.btnSettingCancel.Text = "취소";
            this.btnSettingCancel.UseVisualStyleBackColor = true;
            this.btnSettingCancel.Click += new System.EventHandler(this.BtnSettingCancel_Click);
            // 
            // btnSettingSave
            // 
            this.btnSettingSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSettingSave.FlatAppearance.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.btnSettingSave.FlatAppearance.BorderSize = 0;
            this.btnSettingSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSettingSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingSave.Location = new System.Drawing.Point(62, 14);
            this.btnSettingSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSettingSave.Name = "btnSettingSave";
            this.btnSettingSave.Size = new System.Drawing.Size(68, 23);
            this.btnSettingSave.TabIndex = 27;
            this.btnSettingSave.Text = "설정 저장";
            this.btnSettingSave.UseVisualStyleBackColor = false;
            this.btnSettingSave.Click += new System.EventHandler(this.BtnSettingSave_Click);
            // 
            // pnlDirOptions
            // 
            this.pnlDirOptions.Controls.Add(this.lblStep1);
            this.pnlDirOptions.Controls.Add(this.tboxDefaultPathOption);
            this.pnlDirOptions.Controls.Add(this.btnChangeDefaultPath);
            this.pnlDirOptions.Location = new System.Drawing.Point(10, 77);
            this.pnlDirOptions.Name = "pnlDirOptions";
            this.pnlDirOptions.Size = new System.Drawing.Size(334, 81);
            this.pnlDirOptions.TabIndex = 28;
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Location = new System.Drawing.Point(0, 0);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(93, 12);
            this.lblStep1.TabIndex = 0;
            this.lblStep1.Text = "디폴트 저장경로";
            // 
            // tboxDefaultPathOption
            // 
            this.tboxDefaultPathOption.Location = new System.Drawing.Point(10, 22);
            this.tboxDefaultPathOption.Name = "tboxDefaultPathOption";
            this.tboxDefaultPathOption.Size = new System.Drawing.Size(295, 21);
            this.tboxDefaultPathOption.TabIndex = 1;
            // 
            // btnChangeDefaultPath
            // 
            this.btnChangeDefaultPath.Location = new System.Drawing.Point(10, 47);
            this.btnChangeDefaultPath.Name = "btnChangeDefaultPath";
            this.btnChangeDefaultPath.Size = new System.Drawing.Size(75, 23);
            this.btnChangeDefaultPath.TabIndex = 2;
            this.btnChangeDefaultPath.Text = "폴더변경";
            this.btnChangeDefaultPath.UseVisualStyleBackColor = true;
            this.btnChangeDefaultPath.Click += new System.EventHandler(this.btnChangeDefaultPath_Click);
            // 
            // pnlFileNameOptions
            // 
            this.pnlFileNameOptions.Controls.Add(this.label3);
            this.pnlFileNameOptions.Controls.Add(this.label4);
            this.pnlFileNameOptions.Controls.Add(this.tboxPrefix);
            this.pnlFileNameOptions.Controls.Add(this.pnlFnAddsetOptions);
            this.pnlFileNameOptions.Controls.Add(this.label5);
            this.pnlFileNameOptions.Controls.Add(this.tboxSuffix);
            this.pnlFileNameOptions.Location = new System.Drawing.Point(10, 169);
            this.pnlFileNameOptions.Name = "pnlFileNameOptions";
            this.pnlFileNameOptions.Size = new System.Drawing.Size(334, 178);
            this.pnlFileNameOptions.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "저장될 파일명 규칙";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "앞문자열";
            // 
            // tboxPrefix
            // 
            this.tboxPrefix.Location = new System.Drawing.Point(81, 21);
            this.tboxPrefix.Name = "tboxPrefix";
            this.tboxPrefix.Size = new System.Drawing.Size(223, 21);
            this.tboxPrefix.TabIndex = 17;
            // 
            // pnlFnAddsetOptions
            // 
            this.pnlFnAddsetOptions.Controls.Add(this.rbAddsetPosEnd);
            this.pnlFnAddsetOptions.Controls.Add(this.rbAddsetPosMiddle);
            this.pnlFnAddsetOptions.Controls.Add(this.cboxAddsetTypes);
            this.pnlFnAddsetOptions.Controls.Add(this.rbAddsetPosFront);
            this.pnlFnAddsetOptions.Controls.Add(this.label7);
            this.pnlFnAddsetOptions.Controls.Add(this.label6);
            this.pnlFnAddsetOptions.Location = new System.Drawing.Point(7, 75);
            this.pnlFnAddsetOptions.Name = "pnlFnAddsetOptions";
            this.pnlFnAddsetOptions.Size = new System.Drawing.Size(313, 66);
            this.pnlFnAddsetOptions.TabIndex = 21;
            // 
            // rbAddsetPosEnd
            // 
            this.rbAddsetPosEnd.AutoSize = true;
            this.rbAddsetPosEnd.Location = new System.Drawing.Point(188, 33);
            this.rbAddsetPosEnd.Margin = new System.Windows.Forms.Padding(0);
            this.rbAddsetPosEnd.Name = "rbAddsetPosEnd";
            this.rbAddsetPosEnd.Size = new System.Drawing.Size(47, 16);
            this.rbAddsetPosEnd.TabIndex = 2;
            this.rbAddsetPosEnd.TabStop = true;
            this.rbAddsetPosEnd.Text = "맨뒤";
            this.rbAddsetPosEnd.UseVisualStyleBackColor = true;
            // 
            // rbAddsetPosMiddle
            // 
            this.rbAddsetPosMiddle.AutoSize = true;
            this.rbAddsetPosMiddle.Location = new System.Drawing.Point(135, 33);
            this.rbAddsetPosMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.rbAddsetPosMiddle.Name = "rbAddsetPosMiddle";
            this.rbAddsetPosMiddle.Size = new System.Drawing.Size(47, 16);
            this.rbAddsetPosMiddle.TabIndex = 1;
            this.rbAddsetPosMiddle.TabStop = true;
            this.rbAddsetPosMiddle.Text = "중간";
            this.rbAddsetPosMiddle.UseVisualStyleBackColor = true;
            // 
            // cboxAddsetTypes
            // 
            this.cboxAddsetTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAddsetTypes.FormattingEnabled = true;
            this.cboxAddsetTypes.Location = new System.Drawing.Point(75, 3);
            this.cboxAddsetTypes.Name = "cboxAddsetTypes";
            this.cboxAddsetTypes.Size = new System.Drawing.Size(222, 20);
            this.cboxAddsetTypes.TabIndex = 24;
            // 
            // rbAddsetPosFront
            // 
            this.rbAddsetPosFront.AutoSize = true;
            this.rbAddsetPosFront.Location = new System.Drawing.Point(81, 33);
            this.rbAddsetPosFront.Margin = new System.Windows.Forms.Padding(0);
            this.rbAddsetPosFront.Name = "rbAddsetPosFront";
            this.rbAddsetPosFront.Size = new System.Drawing.Size(47, 16);
            this.rbAddsetPosFront.TabIndex = 0;
            this.rbAddsetPosFront.TabStop = true;
            this.rbAddsetPosFront.Text = "맨앞";
            this.rbAddsetPosFront.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "추가셋 위치";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "추가셋 유형";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "뒤문자열";
            // 
            // tboxSuffix
            // 
            this.tboxSuffix.Location = new System.Drawing.Point(81, 49);
            this.tboxSuffix.Name = "tboxSuffix";
            this.tboxSuffix.Size = new System.Drawing.Size(223, 21);
            this.tboxSuffix.TabIndex = 19;
            // 
            // pnlImageTypeOptions
            // 
            this.pnlImageTypeOptions.Controls.Add(this.rbImageExtPng);
            this.pnlImageTypeOptions.Controls.Add(this.rbImageExtJpg);
            this.pnlImageTypeOptions.Controls.Add(this.rbImageExtBmp);
            this.pnlImageTypeOptions.Controls.Add(this.rbImageExtGif);
            this.pnlImageTypeOptions.Controls.Add(this.lblImageType);
            this.pnlImageTypeOptions.Location = new System.Drawing.Point(10, 17);
            this.pnlImageTypeOptions.Name = "pnlImageTypeOptions";
            this.pnlImageTypeOptions.Size = new System.Drawing.Size(334, 49);
            this.pnlImageTypeOptions.TabIndex = 24;
            // 
            // rbImageExtPng
            // 
            this.rbImageExtPng.AutoSize = true;
            this.rbImageExtPng.Location = new System.Drawing.Point(10, 21);
            this.rbImageExtPng.Name = "rbImageExtPng";
            this.rbImageExtPng.Size = new System.Drawing.Size(44, 16);
            this.rbImageExtPng.TabIndex = 11;
            this.rbImageExtPng.TabStop = true;
            this.rbImageExtPng.Text = "png";
            this.rbImageExtPng.UseVisualStyleBackColor = true;
            // 
            // rbImageExtJpg
            // 
            this.rbImageExtJpg.AutoSize = true;
            this.rbImageExtJpg.Location = new System.Drawing.Point(72, 21);
            this.rbImageExtJpg.Name = "rbImageExtJpg";
            this.rbImageExtJpg.Size = new System.Drawing.Size(40, 16);
            this.rbImageExtJpg.TabIndex = 13;
            this.rbImageExtJpg.TabStop = true;
            this.rbImageExtJpg.Text = "jpg";
            this.rbImageExtJpg.UseVisualStyleBackColor = true;
            // 
            // rbImageExtBmp
            // 
            this.rbImageExtBmp.AutoSize = true;
            this.rbImageExtBmp.Location = new System.Drawing.Point(132, 21);
            this.rbImageExtBmp.Name = "rbImageExtBmp";
            this.rbImageExtBmp.Size = new System.Drawing.Size(48, 16);
            this.rbImageExtBmp.TabIndex = 12;
            this.rbImageExtBmp.TabStop = true;
            this.rbImageExtBmp.Text = "bmp";
            this.rbImageExtBmp.UseVisualStyleBackColor = true;
            // 
            // rbImageExtGif
            // 
            this.rbImageExtGif.AutoSize = true;
            this.rbImageExtGif.Location = new System.Drawing.Point(195, 21);
            this.rbImageExtGif.Name = "rbImageExtGif";
            this.rbImageExtGif.Size = new System.Drawing.Size(36, 16);
            this.rbImageExtGif.TabIndex = 14;
            this.rbImageExtGif.TabStop = true;
            this.rbImageExtGif.Text = "gif";
            this.rbImageExtGif.UseVisualStyleBackColor = true;
            // 
            // lblImageType
            // 
            this.lblImageType.AutoSize = true;
            this.lblImageType.Location = new System.Drawing.Point(0, 0);
            this.lblImageType.Name = "lblImageType";
            this.lblImageType.Size = new System.Drawing.Size(105, 12);
            this.lblImageType.TabIndex = 6;
            this.lblImageType.Text = "이미지 디폴트유형";
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 477);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSideNav);
            this.Controls.Add(this.pnlTopNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::Image_Capture.Properties.Resources.MainIcon;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "SH스크린캡쳐";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlSideNav.ResumeLayout(false);
            this.pnlTopNav.ResumeLayout(false);
            this.pnlTopNav.PerformLayout();
            this.pnlTopRight.ResumeLayout(false);
            this.pnlTopRight.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDirOptions.ResumeLayout(false);
            this.pnlDirOptions.PerformLayout();
            this.pnlFileNameOptions.ResumeLayout(false);
            this.pnlFileNameOptions.PerformLayout();
            this.pnlFnAddsetOptions.ResumeLayout(false);
            this.pnlFnAddsetOptions.PerformLayout();
            this.pnlImageTypeOptions.ResumeLayout(false);
            this.pnlImageTypeOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnScrCapture;
        private System.Windows.Forms.Button btnFolderOpen;
        private System.Windows.Forms.Button btnSelectionCapture;
        public System.Windows.Forms.PictureBox picboxPreview;
        private System.Windows.Forms.FolderBrowserDialog folderbrowserDialog_SShot;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblAutoSave;
        private SwitchCheckBox swcAutoSave;
        private System.Windows.Forms.Label currentSavePath;
        private System.Windows.Forms.Button btnFolderChange;
        private System.Windows.Forms.Panel pnlSideNav;
        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlTopRight;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.RadioButton rbImageExtGif;
        private System.Windows.Forms.RadioButton rbImageExtJpg;
        private System.Windows.Forms.RadioButton rbImageExtBmp;
        private System.Windows.Forms.RadioButton rbImageExtPng;
        private System.Windows.Forms.Label lblImageType;
        private System.Windows.Forms.Button btnChangeDefaultPath;
        private System.Windows.Forms.TextBox tboxDefaultPathOption;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Panel pnlFnAddsetOptions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tboxSuffix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbAddsetPosEnd;
        private System.Windows.Forms.RadioButton rbAddsetPosMiddle;
        private System.Windows.Forms.RadioButton rbAddsetPosFront;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlImageTypeOptions;
        private System.Windows.Forms.Panel pnlFileNameOptions;
        private System.Windows.Forms.Button btnSettingSave;
        private System.Windows.Forms.Button btnSettingCancel;
        private System.Windows.Forms.Panel pnlDirOptions;
        private System.Windows.Forms.ComboBox cboxAddsetTypes;
        private System.Windows.Forms.Panel panel1;
    }
}

