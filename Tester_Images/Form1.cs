using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            tester1();
            tester2();
            tester3();
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

            pictureBox_Result.Image = bmpZoom;
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
        }
    }
}
