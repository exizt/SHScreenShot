using System;
using System.Drawing;
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
        /// </summary>
        public bool isDebug = false;

        /// <summary>
        /// 이미지 파일 저장 관련
        /// </summary>
        internal ScreenImageFileHandler ScreenImageFileHandler { get; private set; }

        /// <summary>
        /// 결과 이미지
        /// </summary>
        public Image resultImage;

        /// <summary>
        /// point 0, 0
        /// </summary>
        Point ptZero = new Point(0, 0);

        /// <summary>
        /// Quick 세이브 모드 여부
        /// </summary>
        bool isQuickSaveMode = false;

        /// <summary>
        /// 마우스 포인터 저장할 값
        /// </summary>
        private Point mousePoint;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        internal static class NativeMethods
        {
            [DllImport("User32.dll")]
            public static extern bool ReleaseCapture();
            [DllImport("User32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        }

        /// <summary>
        /// Round 된 윈도우 구현
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
            pnlSettings.Visible = false;

            // 스크린 이미지를 가져오는 클래스 생성. composition 으로.
            //ScreenImageDrawer = new ScreenImageDrawer(picboxPreview.Size);

            ScreenImageFileHandler = new ScreenImageFileHandler();
            ChangeDirPath();

            // Rounded 윈도우 구현
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        /// <summary>
        /// 그림자 구현
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
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
        /// 영역 선택 캡쳐 기능.
        /// 버튼 클릭시 영역 선택 창을 띄운다. (그것뿐...)
        /// </summary>
        private void DoSelectionCaptureFeature()
        {
            //FormCaptureArea nForm = new FormCaptureArea(this);
            //nForm.Show();

            // modaless 에서 modal 로 변경하고, using 구문과 GC 구문을 추가.
            using (FormSelectionCapture form = new FormSelectionCapture(this))
            {
                form.ShowDialog();
            }
            GC.Collect();
        }

        /// <summary>
        /// 전체 스크린샷 메서드
        /// </summary>
        private void DoScreenCaptureFeature()
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

            SaveResultImageFile();

            // 메모리 정리
            if (resultImage != null) { resultImage.Dispose(); }
        }

        /// <summary>
        /// 결과 이미지와 미리보기 이미지를 같이 그리기
        /// '스크린 캡쳐','전체 캡쳐', '영역 캡쳐 > 저장' 에서 호출
        /// </summary>
        /// <param name="location">시작 좌표</param>
        /// <param name="screenArea">영역 크기</param> 
        public void DrawResultImageWithPreviewImage(Point location, Size screenArea)
        {
            /*
            //ResultImage 만들기
            ScreenImageDrawer.DrawResultImageFromScreen(location, screenArea);
            if (resultImage != null) resultImage.Dispose();
            resultImage = ScreenImageDrawer.ResultImage;

            //PrevieImage 만들기 (ResultImage 를 기준으로)
            ScreenImageDrawer.DrawPreviewImage();
            //if (picboxPreview.Image != null) picboxPreview.Image.Dispose();
            picboxPreview.Image = ScreenImageDrawer.PreviewImage;
            */

            using (ScreenImageDrawer drawer = new ScreenImageDrawer(picboxPreview.Size))
            {
                drawer.DrawFromScreen(location, screenArea, true, true);
                if (resultImage != null) resultImage.Dispose();
                resultImage = new Bitmap(drawer.ResultImage);

                if (picboxPreview.Image != null) picboxPreview.Image.Dispose();
                picboxPreview.Image = new Bitmap(drawer.PreviewImage);
            }

        }

        /// <summary>
        /// 미리보기 이미지 '만' 드로잉하는 메서드
        /// 외부 에서도 호출 가능한 메서드. 좌표만 넘겨주면 됨.
        /// '영역 캡쳐'에서 이용됨.
        /// </summary>
        /// <param name="location">시작 좌표</param>
        /// <param name="screenArea">영역 크기</param>
        public void DrawPreviewImage(Point location, Size screenArea)
        {
            /*
            ScreenImageDrawer.DrawPreviewImageFromScreen(location, screenArea);

            if (picboxPreview.Image != null) picboxPreview.Image.Dispose();
            picboxPreview.Image = ScreenImageDrawer.PreviewImage;
            */

            using (ScreenImageDrawer drawer = new ScreenImageDrawer(picboxPreview.Size))
            {
                drawer.DrawFromScreen(location, screenArea, false, true);
                if (picboxPreview.Image != null) picboxPreview.Image.Dispose();
                picboxPreview.Image = new Bitmap(drawer.PreviewImage);
            }
        }

        /// <summary>
        /// 사진파일을 저장하는 메서드.
        /// Messagebox 호출 후 저장위치 선택해서 저장
        /// </summary>
        public void SaveResultImageFile()
        {
            // 여기서 퀵 세이브 모드와 관련된 설정을 해주어야 할 듯 하다.
            if (isQuickSaveMode)
            {
                ScreenImageFileHandler.QuickSaveImageFile(resultImage);
            }
            else
            {
                if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //SaveFile_Dialog();
                    if (ScreenImageFileHandler.CallSaveFileDialog(resultImage))
                    {
                        ChangeDirPath();
                    }
                }
            }

            // 저장을 했건, 안 했건, 오류가 났건 resultImage 는 Dispose 시킨다.
            // 어차피 다시 시도할 때, 새로 캡쳐해야하기 때문이다.
            if (resultImage != null) { resultImage.Dispose(); }

        }

        /// <summary>
        /// 전체 스크린샷 메서드. 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFullCapture_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            DoScreenCaptureFeature();
        }

        /// <summary>
        /// 영역 캡처 기능. 이벤트 메서드.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectionCapture_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            DoSelectionCaptureFeature();
        }

        /// <summary>
        /// 이벤트 메서드.클릭. 폴더 열기 버튼 클릭시 동작.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFolderOpen_Click(object sender, EventArgs e)
        {
            //Debug("GenerateBasePath:" + ScreenImageFileHandler.GenerateBasePath());
            //Debug("BtnFolderOpen_Click:" + ScreenImageFileHandler.FileDirPath);
            if (ScreenImageFileHandler.FileDirPath != "")
            {
                System.Diagnostics.Process.Start("explorer.exe", ScreenImageFileHandler.FileDirPath);
            } else
            {
                System.Diagnostics.Process.Start("explorer.exe", ScreenImageFileHandler.GenerateBasePath());
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
        /// 숨김처리했던 폼을 다시 visible 처리
        /// </summary>
        private void ShowForm()
        {
            this.Visible = true;//활성화
            this.Opacity = 1.0;
            this.WindowState = FormWindowState.Normal;//폼의 상태를 일반 상태로 되돌림.
        }

        /// <summary>
        /// 폼을 숨김처리
        /// </summary>
        private void HideForm()
        {
            this.Opacity = 0;
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg">Message</param>
        private void Debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine($"[FormMain] {msg}");
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg">Message</param>
#pragma warning disable IDE0051 // 사용되지 않는 private 멤버 제거
        private void Debug(string msg, string msg2)
#pragma warning restore IDE0051 // 사용되지 않는 private 멤버 제거
        {
            if (isDebug)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(msg);
                sb.Append(msg2);
                Debug(sb.ToString());
                sb.Clear();
            }
        }

        private void SwitchQuickSaveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                isQuickSaveMode = true;
                //FolderBrowser();
                //Debug("isQuickSaveMode true");
            } else
            {
                isQuickSaveMode = false;
                //Debug("isQuickSaveMode false");
            }
        }

        private void FolderBrowser()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            DialogResult result = folderDlg.ShowDialog();
            if(result == DialogResult.OK)
            {
                ScreenImageFileHandler.FileDirPath = folderDlg.SelectedPath;
                ChangeDirPath();
            }
        }

        private void ChangeDirPath()
        {
            saveDirectoryPath.Text = ScreenImageFileHandler.FileDirPath;
        }

        /// <summary>
        /// 단축키 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                // 스크린 캡쳐 기능
                DoScreenCaptureFeature();
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShortcutGuide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("스크린 캡쳐: Ctrl + S\n" +
                "영역 캡쳐에서 저장: Ctrl + S\n" +
                "영역 캡쳐에서 닫기: Ctrl + W","단축키 일람");
        }

        /// <summary>
        /// 폼에서 드래그 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// 창 의 드래그 기능
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void BtnFolderChange_Click(object sender, EventArgs e)
        {
            FolderBrowser();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTopNav_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = true;
        }
    }
}
