namespace SHColorPicker
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
            if(disposing && (bitmapPreview != null))
            {
                bitmapPreview.Dispose();
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
            this.tboxColorCodeR = new System.Windows.Forms.TextBox();
            this.labelR = new System.Windows.Forms.Label();
            this.labelG = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.tboxColorCodeB = new System.Windows.Forms.TextBox();
            this.tboxColorCodeG = new System.Windows.Forms.TextBox();
            this.tboxColorCodeFF = new System.Windows.Forms.TextBox();
            this.labelFF = new System.Windows.Forms.Label();
            this.btnPickup = new System.Windows.Forms.Button();
            this.picboxResultColor = new System.Windows.Forms.PictureBox();
            this.picboxPreview = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colordialog1 = new System.Windows.Forms.ColorDialog();
            this.gboxResult = new System.Windows.Forms.GroupBox();
            this.tboxColorCodeRGB = new System.Windows.Forms.TextBox();
            this.labelRGB = new System.Windows.Forms.Label();
            this.btnColorPalette = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picboxResultColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.gboxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtColorCodeR
            // 
            this.tboxColorCodeR.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tboxColorCodeR.Location = new System.Drawing.Point(160, 20);
            this.tboxColorCodeR.MaxLength = 3;
            this.tboxColorCodeR.Name = "txtColorCodeR";
            this.tboxColorCodeR.Size = new System.Drawing.Size(44, 24);
            this.tboxColorCodeR.TabIndex = 11;
            this.tboxColorCodeR.TextChanged += new System.EventHandler(this.txtColorCode_TextChanged);
            this.tboxColorCodeR.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtColorCode_KeyUp);
            // 
            // label_R
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(141, 23);
            this.labelR.Name = "label_R";
            this.labelR.Size = new System.Drawing.Size(17, 15);
            this.labelR.TabIndex = 12;
            this.labelR.Text = "R";
            // 
            // label_G
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(140, 55);
            this.labelG.Name = "label_G";
            this.labelG.Size = new System.Drawing.Size(18, 15);
            this.labelG.TabIndex = 12;
            this.labelG.Text = "G";
            // 
            // label_B
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(141, 85);
            this.labelB.Name = "label_B";
            this.labelB.Size = new System.Drawing.Size(17, 15);
            this.labelB.TabIndex = 12;
            this.labelB.Text = "B";
            // 
            // txtColorCodeB
            // 
            this.tboxColorCodeB.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tboxColorCodeB.Location = new System.Drawing.Point(160, 82);
            this.tboxColorCodeB.MaxLength = 3;
            this.tboxColorCodeB.Name = "txtColorCodeB";
            this.tboxColorCodeB.Size = new System.Drawing.Size(44, 24);
            this.tboxColorCodeB.TabIndex = 13;
            this.tboxColorCodeB.TextChanged += new System.EventHandler(this.txtColorCode_TextChanged);
            this.tboxColorCodeB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtColorCode_KeyUp);
            // 
            // txtColorCodeG
            // 
            this.tboxColorCodeG.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tboxColorCodeG.Location = new System.Drawing.Point(160, 52);
            this.tboxColorCodeG.MaxLength = 3;
            this.tboxColorCodeG.Name = "txtColorCodeG";
            this.tboxColorCodeG.Size = new System.Drawing.Size(44, 24);
            this.tboxColorCodeG.TabIndex = 12;
            this.tboxColorCodeG.TextChanged += new System.EventHandler(this.txtColorCode_TextChanged);
            this.tboxColorCodeG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtColorCode_KeyUp);
            // 
            // txtColorCodeFF
            // 
            this.tboxColorCodeFF.BackColor = System.Drawing.Color.White;
            this.tboxColorCodeFF.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tboxColorCodeFF.Location = new System.Drawing.Point(13, 142);
            this.tboxColorCodeFF.MaxLength = 7;
            this.tboxColorCodeFF.Name = "txtColorCodeFF";
            this.tboxColorCodeFF.Size = new System.Drawing.Size(190, 24);
            this.tboxColorCodeFF.TabIndex = 14;
            this.tboxColorCodeFF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColorCodeFF_KeyPress);
            this.tboxColorCodeFF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtColorCodeFF_KeyUp);
            // 
            // label_FF
            // 
            this.labelFF.AutoSize = true;
            this.labelFF.Location = new System.Drawing.Point(11, 119);
            this.labelFF.Name = "label_FF";
            this.labelFF.Size = new System.Drawing.Size(41, 15);
            this.labelFF.TabIndex = 14;
            this.labelFF.Text = "#html";
            // 
            // btnPickup
            // 
            this.btnPickup.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPickup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPickup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(67)))), ((int)(((byte)(92)))));
            this.btnPickup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(67)))), ((int)(((byte)(92)))));
            this.btnPickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickup.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPickup.ForeColor = System.Drawing.Color.White;
            this.btnPickup.Location = new System.Drawing.Point(108, 217);
            this.btnPickup.Name = "btnPickup";
            this.btnPickup.Size = new System.Drawing.Size(152, 87);
            this.btnPickup.TabIndex = 15;
            this.btnPickup.Text = "색상추출";
            this.btnPickup.UseVisualStyleBackColor = false;
            this.btnPickup.Click += new System.EventHandler(this.btnSpoidColor_Click);
            // 
            // imgResultColor
            // 
            this.picboxResultColor.BackColor = System.Drawing.Color.White;
            this.picboxResultColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxResultColor.Location = new System.Drawing.Point(13, 20);
            this.picboxResultColor.Name = "imgResultColor";
            this.picboxResultColor.Size = new System.Drawing.Size(117, 87);
            this.picboxResultColor.TabIndex = 16;
            this.picboxResultColor.TabStop = false;
            // 
            // imgPreview
            // 
            this.picboxPreview.BackColor = System.Drawing.Color.White;
            this.picboxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxPreview.Location = new System.Drawing.Point(12, 12);
            this.picboxPreview.Name = "imgPreview";
            this.picboxPreview.Size = new System.Drawing.Size(247, 194);
            this.picboxPreview.TabIndex = 18;
            this.picboxPreview.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "바로가기";
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
            // groupBox1
            // 
            this.gboxResult.BackColor = System.Drawing.Color.Transparent;
            this.gboxResult.Controls.Add(this.tboxColorCodeRGB);
            this.gboxResult.Controls.Add(this.labelRGB);
            this.gboxResult.Controls.Add(this.picboxResultColor);
            this.gboxResult.Controls.Add(this.tboxColorCodeR);
            this.gboxResult.Controls.Add(this.tboxColorCodeB);
            this.gboxResult.Controls.Add(this.tboxColorCodeG);
            this.gboxResult.Controls.Add(this.labelR);
            this.gboxResult.Controls.Add(this.labelFF);
            this.gboxResult.Controls.Add(this.labelG);
            this.gboxResult.Controls.Add(this.tboxColorCodeFF);
            this.gboxResult.Controls.Add(this.labelB);
            this.gboxResult.Font = new System.Drawing.Font("돋움", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gboxResult.ForeColor = System.Drawing.Color.SlateBlue;
            this.gboxResult.Location = new System.Drawing.Point(269, 7);
            this.gboxResult.Name = "groupBox1";
            this.gboxResult.Size = new System.Drawing.Size(221, 297);
            this.gboxResult.TabIndex = 19;
            this.gboxResult.TabStop = false;
            this.gboxResult.Text = "결과";
            // 
            // txtColorCodeRGB
            // 
            this.tboxColorCodeRGB.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tboxColorCodeRGB.Location = new System.Drawing.Point(13, 202);
            this.tboxColorCodeRGB.MaxLength = 20;
            this.tboxColorCodeRGB.Name = "txtColorCodeRGB";
            this.tboxColorCodeRGB.Size = new System.Drawing.Size(191, 24);
            this.tboxColorCodeRGB.TabIndex = 18;
            this.tboxColorCodeRGB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtColorCodeRGB_KeyUp);
            // 
            // label_RGB
            // 
            this.labelRGB.AutoSize = true;
            this.labelRGB.Location = new System.Drawing.Point(12, 183);
            this.labelRGB.Name = "label_RGB";
            this.labelRGB.Size = new System.Drawing.Size(73, 15);
            this.labelRGB.TabIndex = 17;
            this.labelRGB.Text = "Web RGB";
            // 
            // btnColorPaletteDialog
            // 
            this.btnColorPalette.BackColor = System.Drawing.Color.SteelBlue;
            this.btnColorPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorPalette.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold);
            this.btnColorPalette.ForeColor = System.Drawing.Color.White;
            this.btnColorPalette.Location = new System.Drawing.Point(12, 217);
            this.btnColorPalette.Name = "btnColorPaletteDialog";
            this.btnColorPalette.Size = new System.Drawing.Size(89, 87);
            this.btnColorPalette.TabIndex = 20;
            this.btnColorPalette.Text = "선택";
            this.btnColorPalette.UseVisualStyleBackColor = false;
            this.btnColorPalette.Click += new System.EventHandler(this.btnColorPaletteDialog_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 320);
            this.Controls.Add(this.btnColorPalette);
            this.Controls.Add(this.gboxResult);
            this.Controls.Add(this.picboxPreview);
            this.Controls.Add(this.btnPickup);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::SHColorPicker.Properties.Resources.MainIcon;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "SH Color Picker";
            this.Activated += new System.EventHandler(this.MainForm_activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picboxResultColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPreview)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gboxResult.ResumeLayout(false);
            this.gboxResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelFF;
        private System.Windows.Forms.Label labelRGB;
        public System.Windows.Forms.TextBox tboxColorCodeR;
        public System.Windows.Forms.TextBox tboxColorCodeB;
        public System.Windows.Forms.TextBox tboxColorCodeG;
        public System.Windows.Forms.TextBox tboxColorCodeFF;
        private System.Windows.Forms.TextBox tboxColorCodeRGB;
        private System.Windows.Forms.Button btnPickup;
        private System.Windows.Forms.Button btnColorPalette;
        private System.Windows.Forms.GroupBox gboxResult;
        public System.Windows.Forms.PictureBox picboxResultColor;
        public System.Windows.Forms.PictureBox picboxPreview;
        private System.Windows.Forms.ColorDialog colordialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

