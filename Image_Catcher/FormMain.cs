using System;
using System.Diagnostics;//debug용
using System.Drawing;
using System.Runtime.InteropServices;//dll 임포트를 위한 녀석.
using System.Windows.Forms;


namespace Image_Capture
{
    public partial class FormMain : Form
    {
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

        /// <summary>
        /// 프로그램 타이틀 지정.
        /// </summary>
        public static string cfgTitle = "Image Capture - by e2xist";

        /// <summary>
        /// 그래픽 공간으로 사용할 곳. 임시적으로 사용하고, 메서드 내에서는 반드시 dispose 할 것.
        /// </summary>
        Graphics graphics;

        /// <summary>
        /// point 0, 0
        /// </summary>
        Point ptZero = new Point(0, 0);
        ImageConverter converter = new ImageConverter();
        string strFilePath = "";

        /// <summary>
        /// 캡쳐된 결과 이미지. 이 이미지 객체를 저장한다.
        /// </summary>
        public Image imgCaptureResult;
        byte[] byteData;

        Bitmap bitmapPreview;//! deprecate

        /// <summary>
        /// 캡쳐된 결과 이미지. 이 이미지 객체를 저장한다.
        /// </summary>
        Bitmap bitmapResult;
        Size szResultImage = new Size(0,0);

        /// <summary>
        /// 미리보기 이미지 개체.
        /// </summary>
        Bitmap bitmapPreviewImage;//미리보기 이미지 개체. 인스턴스로 사용되는 개체.


        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
            this.Text = cfgTitle;

            //미리보기 이미지 객체 생성
            bitmapPreviewImage = new Bitmap(imgPreview.Size.Width, imgPreview.Size.Height);
            bitmapResult = new Bitmap(imgPreview.Size.Width, imgPreview.Size.Height);
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
            //Image _image = GetDesktopImage2();//스크린샷 이미지를 가져와서 저장시킬 곳에 넣어둠.
            screenshotFullScreen();

            //미리보기 이미지 지정
            //imgPreview.Image = getImageResizeFromImage(_image, imgPreview.Size);//스크린샷 이미지를 미리보기로.
            drawPreviewImageFromBytes();

            //스크린샷 이미지를 저장함.
           // SaveScreenShotFile(_image);//해당 파일을 저장.
            saveFile_ResultImageFromBytes();



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
        //close of 이벤트 메서드들
        //=============================================================

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg)
        {
            Debug.WriteLine(msg);
        }


        /// <summary>
        /// 스크린 이미지 생성 및 저장 메서드.
        /// byteDate[] 타입의 멤버변수에 저장을 한다.
        /// 기존의 getImageCopyFromScreen 메서드를 대체한다.
        /// 기존의 bitmap 리턴 타입에서 byte 타입으로 개선되었다.(메모리 회수가 더 쉽다)
        /// 가비지 컬렉션을 배려한 using 구문으로 대처하였다.
        /// </summary>
        /// <param name="_pointStart">시작점좌표</param>
        /// <param name="_sizeImage">이미지크기</param>
        public void getByteFromScreen(Point _pointStart, Size _sizeImage)
        {
            using (Bitmap b = new Bitmap(_sizeImage.Width, _sizeImage.Height))
            {
                //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                }
                //imgCaptureResult = (Image)b;
                byteData = (byte[])converter.ConvertTo(b, typeof(byte[]));
            }
        }

        /// <summary>
        /// 미리보기 화면의 이미지를 그린다.
        /// bitmapResult(Bitmap) 을 가져와서, 미리보기 사이즈에 맞춰서 bitmapPreviewImage 를 그린다.
        /// 영역캡처 에서 호출.
        /// </summary>
        public void drawPreviewImageFromBytes()
        {
            //비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            using (Graphics g = Graphics.FromImage(bitmapPreviewImage))
            {
                //결과 이미지와 미리보기 이미지의 사이즈가 다르므로 이것을 리사이징 하는 부분이다.
                g.DrawImage((Image)converter.ConvertFrom(byteData), 0, 0, bitmapPreviewImage.Width, bitmapPreviewImage.Height);

                //리사이징 하면서 이미지가 지저분하므로, 렌더링 처리를 한다.
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            }

            //미리보기 화면상에 지정
            imgPreview.Image = bitmapPreviewImage;
        }


        /// <summary>
        /// 스크린샷 찍은 결과를 imgCaptureResult 에 저장한다.(이미지 타입으로)
        /// 기존의 getImageCopyFromScreen 메서드를 대체한다.
        /// 이미지 사이즈가 계속 바뀌기 때문에... new Bitmap 을 안 할 방법이 없네..
        /// 영역캡처 에서 호출.
        /// </summary>
        /// <param name="_pointStart">시작점좌표</param>
        /// <param name="_sizeImage">이미지크기</param>
        public void drawBitmapFromScreen(Point _pointStart, Size _sizeImage)
        {
            //사이즈 변동이 없을 경우
            if(szResultImage.Equals(_sizeImage))
            {
                //bitmapResult = new Bitmap(_sizeImage.Width,_sizeImage.Height);

                //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
                using (Graphics g = Graphics.FromImage(bitmapResult))
                {
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                }

                imgCaptureResult = bitmapResult;
            }
            //사이즈 변동이 있을 경우
            else
            {

                szResultImage = _sizeImage;

                using (Bitmap b = new Bitmap(_sizeImage.Width, _sizeImage.Height))
                {
                    //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.CopyFromScreen(_pointStart, ptZero, _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    }
                    imgCaptureResult = b;
                }
            }
        }

 



        /// <summary>
        /// 미리보기 이미지를 그린다.
        /// bitmapResult(Bitmap) 을 가져와서, 미리보기 사이즈에 맞춰서 bitmapPreviewImage 를 그린다.
        /// 영역캡처 에서 호출.
        /// </summary>
        public void drawPreviewImage()
        {
            //비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            using (Graphics g = Graphics.FromImage(bitmapPreviewImage))
            {
                //graphics = Graphics.FromImage(bitmapPreviewImage);

                //결과 이미지와 미리보기 이미지의 사이즈가 다르므로 이것을 리사이징 하는 부분이다.
                g.DrawImage(bitmapResult, 0, 0, bitmapPreviewImage.Width, bitmapPreviewImage.Height);

                //리사이징 하면서 이미지가 지저분하므로, 렌더링 처리를 한다.
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            }

            //미리보기 화면상에 지정
            imgPreview.Image = bitmapPreviewImage;
        }

        /// <summary>
        /// 전체 스크린샷 메서드.
        /// 전체 스크린영역을 가져오고, 이 영역을 기준으로 스크린샷 이미지를 생성한다.
        /// </summary>
        public void screenshotFullScreen()
        {
            Size screen = Screen.PrimaryScreen.Bounds.Size;
            getByteFromScreen(ptZero, screen);
        }

        /// <summary>
        /// 미리보기 이미지 에 이미지를 지정.
        /// bitmapPreviewImage 를 화면상의 미리보기 이미지에 지정.
        /// 영역캡처에서 호출.
        /// </summary>
        public void setPreviewImage()
        {
            imgPreview.Image = bitmapPreviewImage;
        }

        /// <summary>
        /// 미리보기 이미지에 이미지 지정.
        /// 이미지 객체를 미리보기 Picturebox 에 넣는다.
        /// </summary>
        /// <param name="_image">미리보기에 넣을 이미지 객체</param>
        public void setPreviewImage(Image _image)
        {
            imgPreview.Image = _image;
        }

        public void imgCapture_Save()
        {
            //해당 파일을 저장.
            SaveFile_ResultImage(imgCaptureResult);

        }

        /// <summary>
        /// SaveScreenShotFile 메서드를 대체하기 위해 만듦.
        /// </summary>
        public void saveFile_ResultImage()
        {
            if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strFilePath = HFilePath.PathDialog();//저장위치 선택/
                HFilePath.Save(strFilePath, bitmapResult);//확장자도 선택할 수 있게 바꿔야겠다..
            }
        }


        /// <summary>
        /// SaveScreenShotFile 메서드를 대체하기 위해 만듦.
        /// </summary>
        public void saveFile_ResultImageFromBytes()
        {
            if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strFilePath = HFilePath.PathDialog();//저장위치 선택/
                HFilePath.Save(strFilePath, (Image)converter.ConvertFrom(byteData));//확장자도 선택할 수 있게 바꿔야겠다..
            }
        }

        /// <summary>
        /// 사진파일을 저장하는 메서드.
        /// Messagebox 호출 후 저장위치 선택해서 저장
        /// </summary>
        /// <param name="_image"></param>
        public void SaveFile_ResultImage(Image _image)
        {
            if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                strFilePath = HFilePath.PathDialog();//저장위치 선택/
                HFilePath.Save(strFilePath, _image);//파일저장
            }
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


        private void MainForm_activated(object sender, EventArgs e)
        {
            //debug("[]MainForm_activated");
            //Cursor.Show();
        }
        
        /**
        * --------------------------------------------
        * 폐기예정인 것들은 젤 아래로 모아두기.
        * --------------------------------------------
        */
        /// <summary>
        /// ! Deprecated.
        /// 폐기 될 듯
        /// </summary>
        /// <returns></returns>
        public Color GetPixelColor_ImgPreview()
        {
            //Image _image = imgPreview.Image;
            Point _point = new Point(imgPreview.Width / 2, imgPreview.Height / 2);
            return GetPixelColor(imgPreview.Image, _point);
        }

        /// <summary>
        /// ! Deprecated.
        /// 폐기될 듯
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

        /// <summary>
        /// ! Deprecated.
        /// 마우스 커서를 기점으로 스크린샷을 찍는다.
        /// 스크린샷을 기준으로 미리보기 이미지를 만든다.
        /// 기존의 getImageCopyFromScreen 메서드를 대체한다.
        /// </summary>
        /// <param name="_pointStart">시작점좌표</param>
        /// <param name="_sizeImage">이미지크기</param>
        public void drawImageFromScreenPoint(Point _pointStart, Size _sizeImage)
        {
            graphics = Graphics.FromImage(bitmapPreviewImage);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            graphics.CopyFromScreen(_pointStart, ptZero, _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
            graphics.Dispose();//리소스 해제
            return;
        }


        /// <summary>
        /// ! Deprecated. 메모리 누수가 있습니다.
        /// </summary>
        /// <param name="_pointStart">시작점좌표</param>
        /// <param name="_sizeImage">이미지크기</param>
        /// <returns></returns>
        public Bitmap getBitmapFromScreen(Point _pointStart, Size _sizeImage)
        {
            Bitmap bmp = new Bitmap(_sizeImage.Width, _sizeImage.Height);

            //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(_pointStart, ptZero, _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                g.Dispose();//리소스 해제
            }
            return bmp;
        }

        //
        /// <summary>
        /// ! deprecated
        /// SH.메서드.스크린샷 이미지를 가져오기 위한 메서드
        /// </summary>
        /// <returns></returns>
        public Bitmap GetDesktopImage2()
        {
            Size screen = Screen.PrimaryScreen.Bounds.Size;
            //------------------------------------------------------
            // 설명 : 이미지 가져오기. 정의한 메서드(private) 
            // 인수 : 전체스크린에서의 시작점좌표, 이미지에 넣을 좌표, 이미지에 넣을 크기
            return getImageCopyFromScreen(ptZero, ptZero, screen);//그려진 비트맵을 객체에 넣는다.
            //------------------------------------------------------
        }

        /// <summary>
        /// ! Deprecated
        /// </summary>
        /// <param name="_image"></param>
        /// <param name="_szImage"></param>
        /// <returns></returns>
        public Bitmap getImageResizeFromImage(Image _image, Size _szImage)
        {
            Bitmap bit = new Bitmap(_szImage.Width, _szImage.Height);//임시 비트맵 생성
            Graphics grp = Graphics.FromImage(bit);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grp.DrawImage(_image, 0, 0, _szImage.Width, _szImage.Height);
            grp.Dispose();
            return bit;
        }

        /// <summary>
        /// ! Deprecated
        /// </summary>
        /// <param name="_image"></param>
        /// <param name="_szImage"></param>
        /// <returns></returns>
        public Bitmap getImageResizeFromImage2(Image _image, Size _szImage)
        {
            Bitmap bit = new Bitmap(_szImage.Width, _szImage.Height);//임시 비트맵 생성
            Graphics grp = Graphics.FromImage(bit);//임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
            //grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grp.DrawImage(_image, 0, 0, _szImage.Width, _szImage.Height);
            grp.Dispose();
            return bit;
        }
    }
}
