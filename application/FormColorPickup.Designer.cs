namespace SHColorPicker
{
    partial class FormColorPickup
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
            this.timerPick = new System.Windows.Forms.Timer(this.components);
            this.picSection = new System.Windows.Forms.PictureBox();
            this.picSpoidIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpoidIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPick
            // 
            this.timerPick.Interval = 1;
            this.timerPick.Tick += new System.EventHandler(this.timerPick_Tick);
            // 
            // picSection
            // 
            this.picSection.BackColor = System.Drawing.Color.Turquoise;
            this.picSection.ErrorImage = null;
            this.picSection.ImageLocation = "0,0";
            this.picSection.InitialImage = null;
            this.picSection.Location = new System.Drawing.Point(0, 0);
            this.picSection.Name = "picSection";
            this.picSection.Size = new System.Drawing.Size(300, 300);
            this.picSection.TabIndex = 0;
            this.picSection.TabStop = false;
            this.picSection.Click += new System.EventHandler(this.picArea_Click);
            // 
            // picSpoidIcon
            // 
            this.picSpoidIcon.BackColor = System.Drawing.Color.Turquoise;
            this.picSpoidIcon.Image = global::SHColorPicker.Properties.Resources.Image3;
            this.picSpoidIcon.Location = new System.Drawing.Point(150, 134);
            this.picSpoidIcon.Name = "picSpoidIcon";
            this.picSpoidIcon.Size = new System.Drawing.Size(16, 16);
            this.picSpoidIcon.TabIndex = 1;
            this.picSpoidIcon.TabStop = false;
            this.picSpoidIcon.WaitOnLoad = true;
            this.picSpoidIcon.Click += new System.EventHandler(this.picSpoid_Click);
            // 
            // FormColorPickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.picSpoidIcon);
            this.Controls.Add(this.picSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPickSpoid";
            this.Text = "Color Pick Spoid";
            this.TransparencyKey = System.Drawing.Color.Turquoise;
            this.Load += new System.EventHandler(this.FormColorPickup_Load);
            this.Click += new System.EventHandler(this.Form_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSpoidIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPick;
        private System.Windows.Forms.PictureBox picSection;
        private System.Windows.Forms.PictureBox picSpoidIcon;
    }
}