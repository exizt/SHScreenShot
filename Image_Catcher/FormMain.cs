using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;//dll 임포트를 위한 녀석.
using System.Diagnostics;//debug용



namespace Image_Capture
{
    public partial class FormMain : Form
    {

        //프로그램 타이틀 지정.
        public static string cfgTitle = "Image Catcher - by e2xist";
        
        //=============================================================
        //스크린샷을 찍기 위한 임포트
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;
        //스크린샷을 찍기 위한 임포트 END
        //=============================================================
        string strFilePath="";
        public Image imgCaptureResult;
        Bitmap bitmapPreview;


        Graphics graphics;//그래픽 공간으로 사용할 곳. 임시적으로 사용하고, 메서드 내에서는 반드시 dispose 할 것.
        Bitmap bitmapPreviewImage;//미리보기 이미지 개체

        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
            this.Text = cfgTitle;
        }
        
        //=============================================================
        //이벤트 메서드들.
        /// <summary>
        /// 로드 되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //커서가 안 보이는 환경일 때, 커서를 복귀.
            Cursor current = Cursor.Current;
            if (current == null)
            {
                Cursor.Show();
            }
        }

        /// <summary>
        /// 스크린샷 메서드. 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapture_Click(object sender, EventArgs e)
        {
            //전체 스크린샷 이미지를 가져옴.
            Image _image = GetDesktopImage2();//스크린샷 이미지를 가져와서 저장시킬 곳에 넣어둠.

            //미리보기 이미지 지정
            imgPreview.Image = getImageResizeFromImage(_image, imgPreview.Size);//스크린샷 이미지를 미리보기로.

            //스크린샷 이미지를 저장함.
            SaveScreenShotFile(_image);//해당 파일을 저장.
        }

        /// <summary>
        /// 색상 추출 기능. 이벤트 메서드.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpoidColor_Click(object sender, EventArgs e)
        {
            //1. 커서를 숨긴다.
            //Cursor.Hide();

            //2. 커서의 좌표를 통하여 색상을 추출한다.
            FormColorPickup nForm = new FormColorPickup(this);
            nForm.Show();
        }

        /// <summary>
        /// 영역 캡처 기능. 이벤트 메서드.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptureArea_Click(object sender, EventArgs e)
        {
            FormCaptureArea nForm = new FormCaptureArea(this);
            nForm.Show();
        }


        /// <summary>
        /// 이벤트 메서드.클릭. 폴더 열기 버튼 클릭시 동작.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderOpen_Click(object sender, EventArgs e)
        {
            if (strFilePath != "")
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(strFilePath));
            else
                System.Diagnostics.Process.Start("explorer.exe", HFilePath.Auto_Dir());

        }
        //=============================================================


        public void imgCapture_Save()
        {
            //해당 파일을 저장.
            SaveScreenShotFile(imgCaptureResult);

        }






        /**
         * @method 사진파일을 저장하는 메서드
         * @remark Messagebox 호출 후 저장위치 선택해서 저장
         * @arguments Image Type
         */
        public void SaveScreenShotFile(Image _image)
        {
            if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strFilePath = HFilePath.PathDialog();//저장위치 선택/
                HFilePath.Save(strFilePath, _image);//파일저장
            }
        }

 
        


        //
        /// <summary>
        /// SH.메서드.스크린샷 이미지를 가져오기 위한 메서드
        /// </summary>
        /// <returns></returns>
        public Bitmap GetDesktopImage2()
        {
            Size screen = Screen.PrimaryScreen.Bounds.Size;
            //------------------------------------------------------
            // 설명 : 이미지 가져오기. 정의한 메서드(private) 
            // 인수 : 전체스크린에서의 시작점좌표, 이미지에 넣을 좌표, 이미지에 넣을 크기
            return getImageCopyFromScreen(new Point(0, 0),new Point(0, 0),screen);//그려진 비트맵을 객체에 넣는다.
            //------------------------------------------------------
        }


        //-------------------------------------------------------
 

        /// <summary>
        /// 마우스 커서를 기점으로 스크린샷을 찍는다.
        /// 스크린샷을 기준으로 미리보기 이미지를 만든다.
        /// 기존의 getImageCopyFromScreen 메서드를 대체한다.
        /// </summary>
        /// <param name="_pointStart">시작점좌표</param>
        /// <param name="_sizeImage">이미지크기</param>
        public void drawImageFromScreenPoint(Point _pointStart, Size _sizeImage)
        {
            graphics = Graphics.FromImage(bitmapPreviewImage);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            graphics.CopyFromScreen(_pointStart, new Point(0, 0), _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
            graphics.Dispose();//리소스 해제
            return;
        }


        public void ImgPreview_Spoid_Draw()
        {
            imgPreview.Image = global::Image_Capture.Properties.Resources.Image3;

        }
        public void ImgPreview_Spoid_Remove()
        {

        }

        /// <summary>
        /// 미리보기 이미지 에 이미지를 지정
        /// </summary>
        /// <param name="_image">지정할 이미지</param>
        public void setImgPreview_Image(Image _image)
        {
            imgPreview.Image = _image;
        }


        public void setImgPreview_BackgroundImage(Image _image)
        {
            imgPreview.BackgroundImage = _image;
        }


        /// <summary>
        /// 색상을 추출하는 메서드
        /// </summary>
        /// <returns></returns>
        public Color getColorPixelPickup()
        {
            bitmapPreview = new Bitmap(imgPreview.Image);
            return bitmapPreview.GetPixel(imgPreview.Width / 2, imgPreview.Height / 2);
        }




        public Bitmap getImageResizeFromImage(Image _image, Size _szImage)
        {
            Bitmap bit = new Bitmap(_szImage.Width, _szImage.Height);//임시 비트맵 생성
            Graphics grp = Graphics.FromImage(bit);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grp.DrawImage(_image,0,0,_szImage.Width,_szImage.Height);
            grp.Dispose();
            return bit;
        }


        public Bitmap getImageResizeFromImage2(Image _image, Size _szImage)
        {
            Bitmap bit = new Bitmap(_szImage.Width, _szImage.Height);//임시 비트맵 생성
            Graphics grp = Graphics.FromImage(bit);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            //grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grp.DrawImage(_image, 0, 0, _szImage.Width, _szImage.Height);
            grp.Dispose();
            return bit;
        }
        private void debug(string msg)
        {
            Debug.WriteLine(msg);
        }

        private void MainForm_activated(object sender, EventArgs e)
        {
            //debug("[]MainForm_activated");
            //Cursor.Show();
        }

        /**
        * --------------------------------------------
        * 폐기예정인 것들은 젤 아래로 모아두기.
        */
        /// <summary>
        /// ! Deprecated. 폐기 될 듯
        /// </summary>
        /// <returns></returns>
        public Color GetPixelColor_ImgPreview()
        {
            //Image _image = imgPreview.Image;
            Point _point = new Point(imgPreview.Width / 2, imgPreview.Height / 2);
            return GetPixelColor(imgPreview.Image, _point);
        }

        /// <summary>
        /// ! Deprecated. 폐기될 듯
        /// </summary>
        /// <param name="_image"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Color GetPixelColor(Image _image, Point pt)
        {
            Bitmap bit = new Bitmap(_image);
            return bit.GetPixel(pt.X, pt.Y);
        }

        /// <summary>
        /// ! Deprecated.
        /// 지정한 크기 만큼 스크린샷 메서드.
        /// </summary>
        /// <param name="ptScreen">시작할좌표</param>
        /// <param name="ptDraw">이미지에 넣을 좌표</param>
        /// <param name="szImage">이미지에 넣을 크기</param>
        /// <returns></returns>
        public Bitmap getImageCopyFromScreen(Point ptScreen, Point ptDraw, Size szImage)
        {
            Bitmap bit = new Bitmap(szImage.Width, szImage.Height);//임시 비트맵 생성
            Graphics grp = Graphics.FromImage(bit);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            grp.CopyFromScreen(ptScreen, ptDraw, szImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.

            grp.Dispose();
            return bit;
        }
    }
}
