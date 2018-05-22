using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;

namespace Image_Capture
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 로그 디버깅 옵션.
        /// formCaptureArea 도 영향을 받는다.
        /// </summary>
        public bool isDebug = true;

        /// <summary>
        /// ScreenImageDrawer 인스턴스.
        /// 이미지 캡쳐 등의 기능을 담은 클래스.
        /// </summary>
        internal ScreenImageDrawer ScreenImageDrawer { get; private set; }

        internal ScreenImageFileHandler ScreenImageSaver { get; private set; }

        /// <summary>
        /// 결과 이미지
        /// </summary>
        public Image resultImage;

        /// <summary>
        /// point 0, 0
        /// </summary>
        Point ptZero = new Point(0, 0);

        /// <summary>
        /// 파일 경로
        /// </summary>
        string strFilePath = "";

        bool isQuickSaveMode = false;

        // --------------------- movable 구간 ▽▽▽▽▽ ----------------------------
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // --------------------- movable 구간 △△△△△ ----------------------------

        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)

            // 스크린 이미지를 가져오는 클래스 생성. composition 으로.
            ScreenImageDrawer = new ScreenImageDrawer(picboxPreview.Size);

            ScreenImageSaver = new ScreenImageFileHandler();
        }

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
        /// 전체 스크린샷 메서드. 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFullCapture_Click(object sender, EventArgs e)
        {
            Event_FullScreenCapture();
        }

        /// <summary>
        /// 영역 캡처 기능. 이벤트 메서드.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCaptureArea_Click(object sender, EventArgs e)
        {
            FormCaptureArea nForm = new FormCaptureArea(this);
            nForm.Show();
        }

        /// <summary>
        /// 이벤트 메서드.클릭. 폴더 열기 버튼 클릭시 동작.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFolderOpen_Click(object sender, EventArgs e)
        {
            if (strFilePath != "")
            {
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(strFilePath));
            } else
            {
                System.Diagnostics.Process.Start("explorer.exe", ScreenImageSaver.GenerateBasePath());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.HideForm();
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
                this.HideForm();
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
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 폼에서 드래그 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// 미리보기 이미지 에 이미지를 지정
        /// </summary>
        /// <param name="_image">지정할 이미지</param>
        public void SetImgPreview_Image(Image _image)
        {
            picboxPreview.Image = _image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_image"></param>
        public void SetImgPreview_BackgroundImage(Image _image)
        {
            picboxPreview.BackgroundImage = _image;
        }

        /// <summary>
        /// 전체 스크린샷 메서드
        /// </summary>
        private void Event_FullScreenCapture()
        {
            // 프로그램이 떠 있는 스크린을 감지
            Screen screen = Screen.FromControl(this);

            //기본창을 최소화.
            this.HideForm();

            /*
            주 모니터만 참고하려면 PrimaryScreen 을 사용할 수 있다.
            감지된 모니터만 사용하려면 FromControl 을 이용함.
            주 모니터만 사용하려면 PrimaryScreen 을 이용함.
            전체 모니터에서 하나씩 이용하려면 AllScreens 를 이용함. AllScreens[0] ~ 
            전체 모니터를 감지하는 다른 방법으로, System.Windows.Forms.SystemInformation.VirtualScreen
            */

            // 스크린샷 이미지를 생성하고, 미리보기 이미지도 생성
            DrawResultImageWithPreviewImage(screen.Bounds.Location, screen.Bounds.Size);

            //잠깐 텀 을 준후 윈도우창 복귀
            Thread.Sleep(50);
            this.ShowForm();

            SaveFile_Result();

            // 메모리 정리
            if (resultImage != null) { resultImage.Dispose(); }

        }

        /// <summary>
        /// 결과 이미지와 미리보기 이미지를 같이 그리기
        /// </summary>
        /// <param name="location">시작 좌표</param>
        /// <param name="screenArea">영역 크기</param> 
        private void DrawResultImageWithPreviewImage(Point location, Size screenArea)
        {
            //ResultImage 만들기
            ScreenImageDrawer.DrawResultImageFromScreen(location, screenArea);
            resultImage = ScreenImageDrawer.ResultImage;

            //PrevieImage 만들기 (ResultImage 를 기준으로)
            ScreenImageDrawer.DrawPreviewImage();
            picboxPreview.Image = ScreenImageDrawer.PreviewImage;

        }

        /// <summary>
        /// 미리보기 이미지 '만' 드로잉하는 메서드
        /// 외부 에서도 호출 가능한 메서드. 좌표만 넘겨주면 됨.
        /// </summary>
        /// <param name="location">시작 좌표</param>
        /// <param name="screenArea">영역 크기</param>
        public void DrawPreviewImage(Point location, Size screenArea)
        {
            ScreenImageDrawer.DrawPreviewImageFromScreen(location, screenArea);

            // ScreenImageDrawer.PreviewImage 의 포인터는 변하지 않는 포인트이므로, 메모리 누수 우려 안해도 됨.
            picboxPreview.Image = ScreenImageDrawer.PreviewImage;
        }

        /// <summary>
        /// 결과 이미지 '만' 드로잉하는 메서드
        /// </summary>
        /// <param name="location">좌표</param>
        /// <param name="screenArea">크기</param>
        public void DrawResultImage(Point location, Size screenArea)
        {
            // 결과 이미지를 생성하는 부분
            ScreenImageDrawer.DrawResultImageFromScreen(location, screenArea);
            resultImage = ScreenImageDrawer.ResultImage;
        }

        /// <summary>
        /// 사진파일을 저장하는 메서드.
        /// Messagebox 호출 후 저장위치 선택해서 저장
        /// </summary>
        public void SaveFile_Result()
        {
            if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //SaveFile_Dialog();
                ScreenImageSaver.CallSaveFileDialog(resultImage);
            }
            else
            {
                if (resultImage != null) { resultImage.Dispose(); }
            }
        }

        /// <summary>
        /// 숨김처리했던 폼을 다시 visible 처리
        /// </summary>
        private void ShowForm()
        {
            this.Visible = true;//활성화
            this.Opacity = 100;
            this.WindowState = FormWindowState.Normal;//폼의 상태를 일반 상태로 되돌림.
        }

        /// <summary>
        /// 폼을 숨김처리
        /// </summary>
        private void HideForm()
        {
            this.Opacity = 0;
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg">Message</param>
        private void Debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg">Message</param>
        private void Debug(string msg, string msg2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(msg);
            sb.Append(msg2);
            Debug(sb.ToString());
            sb.Clear();
        }

        private void switchQuickSaveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                isQuickSaveMode = true;
                Debug("isQuickSaveMode true");
            } else
            {
                isQuickSaveMode = false;
                Debug("isQuickSaveMode false");
            }
        }
    }
}
