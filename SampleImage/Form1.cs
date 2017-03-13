using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tester_Images
{
    public partial class Form1 : Form
    {
        Bitmap bitmapBefore;
        public Form1()
        {
            InitializeComponent();
            bitmapBefore = Properties.Resources.tester;
            pictureBox_Before.Image = Properties.Resources.tester;

            //tester1();
            //tester2();
            //tester3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tester1();
            tester2();
            tester3();
        }
        

        /// <summary>
        /// DrawImage 를 이용한 방법.
        /// 깔끔한 확대는 실패.(흐릿함)
        /// </summary>
        void tester1()
        {
            Bitmap bmp = bitmapBefore;
            Bitmap bmpZoom = new Bitmap(bmp.Width, bmp.Height);

            int new4W = bmp.Width / 4;
            int new4H = bmp.Height / 4;
            int new2W = bmp.Width / 2;
            int new2H = bmp.Height / 2;

            Rectangle srcRect = new Rectangle(0, 0, new2W, new2H);
            Rectangle dstRect = new Rectangle(0, 0, bmpZoom.Width, bmpZoom.Height);

            Graphics g = Graphics.FromImage(bmpZoom);
            g.DrawImage(bmp, dstRect, srcRect, GraphicsUnit.Pixel);

            pictureBox_Result1.Image = bmpZoom;
        }

        void tester2()
        {
            int zoomFactor = 2;
            Size newSize = new Size((int)(bitmapBefore.Width * zoomFactor), (int)(bitmapBefore.Height * zoomFactor));
            Bitmap bmp = new Bitmap(bitmapBefore, newSize);
            pictureBox_Result2.Image = bmp;
        }

        void tester3()
        {
            Bitmap bmp = bitmapBefore;
            Bitmap bmpZoom = new Bitmap(bmp.Width, bmp.Height);

            int new4W = bmp.Width / 4;
            int new4H = bmp.Height / 4;
            int new2W = bmp.Width / 2;
            int new2H = bmp.Height / 2;

            Rectangle srcRect = new Rectangle(0, 0, new2W, new2H);
            Rectangle dstRect = new Rectangle(0, 0, bmpZoom.Width, bmpZoom.Height);

            Graphics g = Graphics.FromImage(bmpZoom);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//이것이 가장 퀄리티가 높다고 함.
            //g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;//샘플로 추가
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.DrawImage(bmp, dstRect, srcRect, GraphicsUnit.Pixel);

            pictureBox_Result3.Image = bmpZoom;

            /*
            Default
            Low
            High


            NearestNeighbor
            Bilinear
            HighQualityBilinear
            Bicubic
            HighQualityBicubic
            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clearPictures();
            label_title.Text = "Interpolation Mode Test + 확대 테스트";
            test_interpolationMode(pictureBox_Result1, InterpolationMode.Default, true);
            label1.Text = "Default";
            test_interpolationMode(pictureBox_Result2, InterpolationMode.Low, true);
            label2.Text = "Low";
            test_interpolationMode(pictureBox_Result3, InterpolationMode.High, true);
            label3.Text = "High";
            test_interpolationMode(pictureBox_Result4, InterpolationMode.NearestNeighbor, true);
            label4.Text = "NearestNeighbor";
            test_interpolationMode(pictureBox_Result5, InterpolationMode.Bilinear, true);
            label5.Text = "Bilinear";
            test_interpolationMode(pictureBox_Result6, InterpolationMode.Bicubic, true);
            label6.Text = "Bicubic";
            test_interpolationMode(pictureBox_Result7, InterpolationMode.HighQualityBilinear, true);
            label7.Text = "HighQualityBilinear";
            test_interpolationMode(pictureBox_Result8, InterpolationMode.HighQualityBicubic, true);
            label8.Text = "HighQualityBicubic";
            //test_interpolationMode(pictureBox_Result8, InterpolationMode.Invalid);
            //label9.Text = "Invalid";
        }

        private void test_interpolationMode(PictureBox pic, InterpolationMode mode,bool isExpand)
        {
            Bitmap bmp = bitmapBefore;
            Bitmap bmpZoom = new Bitmap(bmp.Width, bmp.Height);

            int new4W = bmp.Width / 4;
            int new4H = bmp.Height / 4;
            int new2W = bmp.Width / 2;
            int new2H = bmp.Height / 2;

            Rectangle srcRect = new Rectangle(0, 0, new2W, new2H);
            Rectangle dstRect = new Rectangle(0, 0, bmpZoom.Width, bmpZoom.Height);

            Graphics g = Graphics.FromImage(bmpZoom);
            g.InterpolationMode = mode;

            if (isExpand) {
                g.DrawImage(bmp, dstRect, srcRect, GraphicsUnit.Pixel);
            } else
            {
                g.DrawImage(bmp, srcRect, dstRect, GraphicsUnit.Pixel);
            }

            pic.Image = bmpZoom;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label_title.Text = "Interpolation Mode Test + 확대 테스트";
            test_interpolationMode(pictureBox_Result1, InterpolationMode.Default, false);
            label1.Text = "Default";
            test_interpolationMode(pictureBox_Result2, InterpolationMode.Low, false);
            label2.Text = "Low";
            test_interpolationMode(pictureBox_Result3, InterpolationMode.High, false);
            label3.Text = "High";
            test_interpolationMode(pictureBox_Result4, InterpolationMode.NearestNeighbor, false);
            label4.Text = "NearestNeighbor";
            test_interpolationMode(pictureBox_Result5, InterpolationMode.Bilinear, false);
            label5.Text = "Bilinear";
            test_interpolationMode(pictureBox_Result6, InterpolationMode.Bicubic, false);
            label6.Text = "Bicubic";
            test_interpolationMode(pictureBox_Result7, InterpolationMode.HighQualityBilinear, false);
            label7.Text = "HighQualityBilinear";
            test_interpolationMode(pictureBox_Result8, InterpolationMode.HighQualityBicubic, false);
            label8.Text = "HighQualityBicubic";
            //test_interpolationMode(pictureBox_Result8, InterpolationMode.Invalid);
            //label9.Text = "Invalid";
        }
    }
}
