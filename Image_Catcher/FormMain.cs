using System;
using System.Deployment.Application;
using System.Diagnostics;//debug용
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Image_Capture
{
    public partial class FormMain : Form
    {
        //=============================================================
        //스크린샷을 찍기 위한 임포트
        /*
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        private static extern int GetSystemMetrics(int abc);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        */
        //스크린샷을 찍기 위한 임포트 END
        //=============================================================

        /// <summary>
        /// 프로그램 타이틀 지정.
        /// </summary>
        public static string cfgTitle = "Image Capture - by e2xist";

        /// <summary>
        /// point 0, 0
        /// </summary>
        Point ptZero = new Point(0, 0);

        /// <summary>
        /// 컨버팅 하는 용도
        /// </summary>
        ImageConverter converter = new ImageConverter();

        /// <summary>
        /// 
        /// </summary>
        string strFilePath = "";


        /// <summary>
        /// 캡처 와 저장 사이의 데이터이다.
        /// </summary>
        byte[] byteData;

        /// <summary>
        /// 캡쳐된 결과 이미지. 이 이미지 객체를 저장한다.
        /// </summary>
        public Image imgCaptureResult;

        /// <summary>
        /// 결과 이미지의 사이즈 개체
        /// </summary>
        Size szResultImage = new Size(0, 0);

        /// <summary>
        /// 결과 이미지 비트맵 개체
        /// </summary>
        Bitmap bitmapResult;


        /// <summary>
        /// 화면상의 미리보기 비트맵 개체
        /// 주로 인스턴스로 사용되어서, picturebox.image 에 넣어지기 전까지 존재한다.
        /// </summary>
        Bitmap bitmapPreviewImage;

        /// <summary>
        /// 미리보기 이미지의 사이즈 값.
        /// 윈도우 설정에 따라 변경 될 수 있으므로, Load 된 이후에 실제 크기(픽셀) 을 알아온다.
        /// </summary>
        public Size szPreviewImage;

        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            SetAddRemoveProgramsIcon();
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
            this.Text = cfgTitle;

            //tester();
        }

        private void tester()
        {
            if (ApplicationDeployment.IsNetworkDeployed
                 && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                string result = "";
                result += "ActivationUri[" + ApplicationDeployment.CurrentDeployment.ActivationUri + "]";
                result += "CurrentVersion[" + ApplicationDeployment.CurrentDeployment.CurrentVersion + "]";
                result += "UpdatedVersion[" + ApplicationDeployment.CurrentDeployment.UpdatedVersion + "]";
                result += "UpdateLocation[" + ApplicationDeployment.CurrentDeployment.UpdateLocation + "]";


                MessageBox.Show(result);
            }
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
            //debug("FormMain Load 이벤트 발생!");
            //debug("imgPreview.Width : " + imgPreview.Width+","+imgPreview.Height);
            //debug("imgPreview.Size.Width" + imgPreview.Size.Width + "," + imgPreview.Size.Height);

            //커서가 안 보이는 환경일 때, 커서를 복귀.
            Cursor current = Cursor.Current;
            if (current == null)
            {
                Cursor.Show();
            }

            //미리보기 이미지의 사이즈 를 가져온다.
            //폼 컨트롤의 크기를 처리 할 때에는 최소 Load 이후에 하도록 한다.(생성자에 넣으면 버그 발생 가능성 있음)
            szPreviewImage = imgPreview.Size;

            //미리보기 이미지 객체 생성
            bitmapPreviewImage = new Bitmap(szPreviewImage.Width, szPreviewImage.Height);
            bitmapResult = new Bitmap(szPreviewImage.Width, szPreviewImage.Height);
        }

        /// <summary>
        /// 전체 스크린샷 메서드. 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapture_Click(object sender, EventArgs e)
        {
            //기본창을 최소화.
            this.hideForm();

            //전체 스크린샷 이미지를 가져옴.
            //Image _image = GetDesktopImage2();//스크린샷 이미지를 가져와서 저장시킬 곳에 넣어둠.
            screenshotFullScreen();

            Thread.Sleep(50);
            //기본창을 다시 활성화.
            this.showForm();

            //미리보기 이미지 지정
            //imgPreview.Image = getImageResizeFromImage(_image, imgPreview.Size);//스크린샷 이미지를 미리보기로.
            drawPreviewImageFromBytes();


            //스크린샷 이미지를 저장함.
            // SaveScreenShotFile(_image);//해당 파일을 저장.
            saveFile_ResultImageFromBytes();

            /*
            복수개의 모니터는 Screen.AllScreens 컬렉션 속성을 참조하여 엑세스할 수 있다.
            즉, 첫번째 모니터는 Screen.AllScreens[0], 두번째 모니터는 Screen.AllScreens[1] 등과 같이 엑세스한다.
            */

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
            //MessageBox.Show("dd");
            //using (Bitmap b = new Bitmap(_sizeImage.Width, _sizeImage.Height))
            using (Bitmap b = new Bitmap(_sizeImage.Width, _sizeImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
                using (Graphics g = Graphics.FromImage(b))
                {
                    //그래픽 옵션 주기
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;//이것이 가장 퀄리티가 높다고 함.
                    //g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;//샘플로 추가
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;


                    //스크린 캡쳐 시작                    
                    // 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    //g.CopyFromScreen(_pointStart, ptZero, _sizeImage);
                    //copypixeloperation 옵션을 줄 수도 있다.
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage, CopyPixelOperation.SourceCopy );// 인수:스크린좌표,그리기시작좌표,그리는사이즈.

                }

                //imgCaptureResult = (Image)b;
                byteData = (byte[])converter.ConvertTo(b, typeof(byte[]));
            }
        }
        /// <summary>
        /// 색상 추출에서 사용될 메서드. 
        /// 픽셀 처리에서 각지게 표현해야 되서, 메서드를 분리함.
        /// </summary>
        /// <param name="_pointStart"></param>
        /// <param name="_sizeImage"></param>
        public void drawPreviewImage_ColorSpoid(Point _pointStart, Size _sizeImage)
        {

            Bitmap bitmapPreviewSpoid = new Bitmap(bitmapPreviewImage.Width, bitmapPreviewImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Bitmap b = new Bitmap(_sizeImage.Width, _sizeImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
                using (Graphics g = Graphics.FromImage(b))
                {
                    //그래픽 옵션 주기
                    //g.SmoothingMode = SmoothingMode.AntiAlias;
                    //g.InterpolationMode = InterpolationMode.HighQualityBicubic;//이것이 가장 퀄리티가 높다고 함.
                    //g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;//샘플로 추가
                    //g.CompositingQuality = CompositingQuality.HighQuality;
                    //g.PixelOffsetMode = PixelOffsetMode.HighQuality;



                    //스크린 캡쳐 시작                    
                    // 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    //g.CopyFromScreen(_pointStart, ptZero, _sizeImage);
                    //copypixeloperation 옵션을 줄 수도 있다.
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.

                }

                using (Graphics g = Graphics.FromImage(bitmapPreviewSpoid))
                {
                    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    //g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                    //이 항목이 있어야 선명하게 확대가 된다.
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                    
                    //g.DrawImage(b, 0, 0, _sizeImage.Width, _sizeImage.Height);
                    g.DrawImage(b, 0, 0, bitmapPreviewImage.Width, bitmapPreviewImage.Height);
                }

            }
            imgPreview.Image = bitmapPreviewSpoid;
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
            if (szResultImage.Equals(_sizeImage))
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
                HFilePath.Save(strFilePath, (Bitmap)converter.ConvertFrom(byteData));//확장자도 선택할 수 있게 바꿔야겠다..
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
                HFilePath.Save(strFilePath, (Bitmap)_image);//파일저장
            }
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
        /// 색상을 추출하는 메서드.
        /// 미리보기 이미지에서 중간에 있는 픽셀의 값을 가져온다.
        /// </summary>
        /// <returns></returns>
        public Color getColorPixelPickup()
        {
            using (Bitmap b = new Bitmap(imgPreview.Image))
            {
                return b.GetPixel((int)(imgPreview.Width / 2), (int)(imgPreview.Height / 2));
            }
        }


        private void MainForm_activated(object sender, EventArgs e)
        {
            //debug("[]MainForm_activated");
            //Cursor.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.showForm();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.Visible = false;
            //this.hide(sender, e);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.showForm();
        }

        private void hide(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.hideForm();
        }
        /// <summary>
        /// 
        /// </summary>
        private void showForm()
        {
            this.Visible = true;//활성화
            this.Opacity = 100;
            this.WindowState = FormWindowState.Normal;//폼의 상태를 일반 상태로 되돌림.
        }
        /// <summary>
        /// 
        /// </summary>
        private void hideForm()
        {
            this.Opacity = 0;
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            //최소화 버튼 클릭시 이벤트
            if (this.WindowState == FormWindowState.Minimized)
            {
                //MessageBox.Show("창이 최소화되었습니다.");
                //창을 숨김 처리 한다.
                this.hideForm();
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                //MessageBox.Show("창이 최대화되었습니다.");
            }
        }
        /// <summary>
        /// 트레이 -> 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// ClickOnce 설치 의 경우, 제어판-프로그램추가/삭제 에서 아이콘 표시가 안 나온다. 그 부분을 보정하는 소스.
        /// </summary>
        private static void SetAddRemoveProgramsIcon()
        {
            //only run if deployed
            //clickonce 의 경우에만, currentdeployment 값을 가진다고 한다.
            //clickOnce 여부는 isNetworkDeployed 값으로 판단한다.
            if (ApplicationDeployment.IsNetworkDeployed
                 && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    //the icon is included in this program
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "MainIcon.ico");

                    if (!File.Exists(iconSourcePath))
                        return;

                    Microsoft.Win32.RegistryKey myUninstallKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        Microsoft.Win32.RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("UrlUpdateInfo");
                        if(myValue != null)
                        {
                            string updateinfo = myValue.ToString();
                            string updateLocation = ApplicationDeployment.CurrentDeployment.UpdateLocation.ToString();
                            if (updateinfo==updateLocation)
                            {
                                myKey.SetValue("DisplayIcon", iconSourcePath);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /**
* --------------------------------------------
* 폐기예정인 것들은 젤 아래로 모아두기.
* --------------------------------------------
*/
    }
}
