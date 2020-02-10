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
            this.btnScrCapture = new System.Windows.Forms.Button();
            this.btnFolderOpen = new System.Windows.Forms.Button();
            this.folderbrowserDialog_SShot = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectionCapture = new System.Windows.Forms.Button();
            this.picboxPreview = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAutoSave = new System.Windows.Forms.Label();
            this.saveDirectoryPath = new System.Windows.Forms.Label();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFNOptDatePos = new System.Windows.Forms.Panel();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pnlFNOptDateType = new System.Windows.Forms.Panel();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStep1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnlSideNav.SuspendLayout();
            this.pnlTopNav.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlFNOptDatePos.SuspendLayout();
            this.pnlFNOptDateType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScrCapture
            // 
            this.btnScrCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnScrCapture.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnScrCapture.FlatAppearance.BorderSize = 0;
            this.btnScrCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScrCapture.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnScrCapture.ForeColor = System.Drawing.Color.White;
            this.btnScrCapture.Image = global::Image_Capture.Properties.Resources.fullscreen_43_wh;
            this.btnScrCapture.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnScrCapture.Location = new System.Drawing.Point(0, 0);
            this.btnScrCapture.Name = "btnScrCapture";
            this.btnScrCapture.Size = new System.Drawing.Size(110, 71);
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
            this.btnSelectionCapture.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSelectionCapture.ForeColor = System.Drawing.Color.White;
            this.btnSelectionCapture.Image = global::Image_Capture.Properties.Resources.fullscreen_43_wh;
            this.btnSelectionCapture.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectionCapture.Location = new System.Drawing.Point(0, 77);
            this.btnSelectionCapture.Name = "btnSelectionCapture";
            this.btnSelectionCapture.Size = new System.Drawing.Size(110, 74);
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
            this.lblAutoSave.ForeColor = System.Drawing.Color.White;
            this.lblAutoSave.Location = new System.Drawing.Point(9, 33);
            this.lblAutoSave.Name = "lblAutoSave";
            this.lblAutoSave.Size = new System.Drawing.Size(53, 12);
            this.lblAutoSave.TabIndex = 25;
            this.lblAutoSave.Text = "자동저장";
            // 
            // saveDirectoryPath
            // 
            this.saveDirectoryPath.AutoSize = true;
            this.saveDirectoryPath.Location = new System.Drawing.Point(12, 293);
            this.saveDirectoryPath.Name = "saveDirectoryPath";
            this.saveDirectoryPath.Size = new System.Drawing.Size(145, 12);
            this.saveDirectoryPath.TabIndex = 27;
            this.saveDirectoryPath.Text = "[폴더경로가 들어갈 위치]";
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
            this.btnSettings.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
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
            this.pnlTopNav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopNav_MouseDown);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "화면 캡쳐";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.picboxPreview);
            this.pnlMain.Controls.Add(this.saveDirectoryPath);
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
            this.pnlSettings.Controls.Add(this.panel2);
            this.pnlSettings.Controls.Add(this.panel1);
            this.pnlSettings.Controls.Add(this.textBox2);
            this.pnlSettings.Controls.Add(this.button3);
            this.pnlSettings.Controls.Add(this.button1);
            this.pnlSettings.Controls.Add(this.textBox1);
            this.pnlSettings.Controls.Add(this.lblStep1);
            this.pnlSettings.Location = new System.Drawing.Point(110, 50);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(334, 585);
            this.pnlSettings.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pnlFNOptDatePos);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.pnlFNOptDateType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Location = new System.Drawing.Point(0, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 178);
            this.panel2.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "저장될 파일명 규칙";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "앞문자";
            // 
            // pnlFNOptDatePos
            // 
            this.pnlFNOptDatePos.Controls.Add(this.radioButton8);
            this.pnlFNOptDatePos.Controls.Add(this.label7);
            this.pnlFNOptDatePos.Controls.Add(this.radioButton7);
            this.pnlFNOptDatePos.Controls.Add(this.radioButton6);
            this.pnlFNOptDatePos.Location = new System.Drawing.Point(0, 116);
            this.pnlFNOptDatePos.Name = "pnlFNOptDatePos";
            this.pnlFNOptDatePos.Size = new System.Drawing.Size(269, 34);
            this.pnlFNOptDatePos.TabIndex = 23;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(194, 6);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(47, 16);
            this.radioButton8.TabIndex = 2;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "맨뒤";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "추가셋 위치";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(141, 6);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(47, 16);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "중간";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(87, 6);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(0);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(47, 16);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "맨앞";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(44, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(129, 21);
            this.textBox3.TabIndex = 17;
            // 
            // pnlFNOptDateType
            // 
            this.pnlFNOptDateType.Controls.Add(this.radioButton5);
            this.pnlFNOptDateType.Controls.Add(this.label6);
            this.pnlFNOptDateType.Location = new System.Drawing.Point(0, 79);
            this.pnlFNOptDateType.Name = "pnlFNOptDateType";
            this.pnlFNOptDateType.Size = new System.Drawing.Size(269, 31);
            this.pnlFNOptDateType.TabIndex = 21;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(75, 4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(166, 16);
            this.radioButton5.TabIndex = 21;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "yyyymmdd.hhmmss.sss";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "추가셋 유형";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "뒤문자";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(44, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(129, 21);
            this.textBox4.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 67);
            this.panel1.TabIndex = 24;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 16);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "png";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(65, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(40, 16);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "jpg";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(125, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 16);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "bmp";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(188, 21);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(36, 16);
            this.radioButton4.TabIndex = 14;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "gif";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "저장될 이미지 기본 타입";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(241, 21);
            this.textBox2.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "미리지정 A";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "폴더변경";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 21);
            this.textBox1.TabIndex = 1;
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Location = new System.Drawing.Point(10, 29);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(53, 12);
            this.lblStep1.TabIndex = 0;
            this.lblStep1.Text = "저장경로";
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
            this.Text = "SH Screen Capture";
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
            this.pnlSettings.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFNOptDatePos.ResumeLayout(false);
            this.pnlFNOptDatePos.PerformLayout();
            this.pnlFNOptDateType.ResumeLayout(false);
            this.pnlFNOptDateType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label saveDirectoryPath;
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
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Panel pnlFNOptDateType;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFNOptDatePos;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

