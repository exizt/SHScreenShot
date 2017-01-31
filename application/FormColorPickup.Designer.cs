namespace Image_Capture
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
            this.timerPickupColor = new System.Windows.Forms.Timer(this.components);
            this.pictureAreaPickupColor = new System.Windows.Forms.PictureBox();
            this.spoidPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAreaPickupColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spoidPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPickupColor
            // 
            this.timerPickupColor.Interval = 1;
            this.timerPickupColor.Tick += new System.EventHandler(this.timerPickupColor_Tick);
            // 
            // pictureAreaPickupColor
            // 
            this.pictureAreaPickupColor.BackColor = System.Drawing.Color.Turquoise;
            this.pictureAreaPickupColor.ErrorImage = null;
            this.pictureAreaPickupColor.ImageLocation = "0,0";
            this.pictureAreaPickupColor.InitialImage = null;
            this.pictureAreaPickupColor.Location = new System.Drawing.Point(0, 0);
            this.pictureAreaPickupColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureAreaPickupColor.Name = "pictureAreaPickupColor";
            this.pictureAreaPickupColor.Size = new System.Drawing.Size(343, 375);
            this.pictureAreaPickupColor.TabIndex = 0;
            this.pictureAreaPickupColor.TabStop = false;
            this.pictureAreaPickupColor.Click += new System.EventHandler(this.pictureAreaPickupColor_Click);
            // 
            // spoidPicture
            // 
            this.spoidPicture.BackColor = System.Drawing.Color.Turquoise;
            this.spoidPicture.Image = global::SHColorPicker.Properties.Resources.Image3;
            this.spoidPicture.Location = new System.Drawing.Point(171, 168);
            this.spoidPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spoidPicture.Name = "spoidPicture";
            this.spoidPicture.Size = new System.Drawing.Size(18, 18);
            this.spoidPicture.TabIndex = 1;
            this.spoidPicture.TabStop = false;
            this.spoidPicture.WaitOnLoad = true;
            this.spoidPicture.Click += new System.EventHandler(this.spoidPicture_Click);
            // 
            // FormColorPickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 375);
            this.Controls.Add(this.spoidPicture);
            this.Controls.Add(this.pictureAreaPickupColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormColorPickup";
            this.Text = "ColorPickUp";
            this.TransparencyKey = System.Drawing.Color.Turquoise;
            this.Load += new System.EventHandler(this.FormColorPickup_Load);
            this.Click += new System.EventHandler(this.FormColorPickup_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAreaPickupColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spoidPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPickupColor;
        private System.Windows.Forms.PictureBox pictureAreaPickupColor;
        private System.Windows.Forms.PictureBox spoidPicture;
    }
}