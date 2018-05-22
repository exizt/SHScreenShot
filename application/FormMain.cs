using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
        /// ScreenImageDrawer 인스턴스
        /// 이미지 캡쳐 등의 기능을 담은 클래스
        /// </summary>
        internal ScreenImageDrawer ScreenImageDrawer { get; private set; }

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
                System.Diagnostics.Process.Start("explorer.exe", GenerateBasePath());
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
    }
}
