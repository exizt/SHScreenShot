using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;

/// <summary>
/// 영역 캡처 다이얼로그
/// 
/// imgCaptureScreen 는 캡처영역의 사이즈(투명 영역의 사이즈)
/// </summary>
namespace Image_Capture
{
    public partial class FormCaptureArea : Form
    {
        /// <summary>
        /// 부모폼을 담아올 용도
        /// </summary>
        FormMain mParentForm;

        /// <summary>
        /// 로그 디버깅 옵션
        /// </summary>
        private bool isDebug = true;

        private const int CAPTURE_AREA_PADDING = 7;

        // --------------------- movable 구간 ▽▽▽▽▽ ----------------------------
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0xA1;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // --------------------- movable 구간 △△△△△ ----------------------------
        private const int cGrip = 16;
        private const int cCaption = 32;


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_parentForm"></param>
        public FormCaptureArea(FormMain _parentForm)
        {
            //컴포넌트 초기화 메서드(기본적으로 들어감)
            InitializeComponent();

            //부모 폼 값
            mParentForm = _parentForm;

            this.MinimumSize = new Size(60,80);
        }

        /// <summary>
        /// 로드되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Load(object sender, EventArgs e)
        {
            picboxCaptureArea.Location = new Point(CAPTURE_AREA_PADDING, CAPTURE_AREA_PADDING);

            //투명영역의 크기 조절
            //ResizeCaptureArea();
            
            //캡처 이미지 생성
            DrawPreviewImage();

            //로드여부 활성화
            isLoaded = true;
        }

        /// <summary>
        /// 창 리사이즈 시 발생 이벤트
        /// 처음 로드 될 때에도 불려지는 것으로 보인다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Resize(object sender, EventArgs e)
        {
            if(isLoaded)
            {
                //투명영역의 크기 조절
                //ResizeCaptureArea();

                //debug("this.Size " + this.Size.Width + "," + this.Size.Height);
                //debug("this.Location " + this.Location.X + "," + this.Location.Y);
                //debug("imgCaptureScreenWH " + imgCaptureScreen.Width + "," + imgCaptureScreen.Height);
                
                //캡처 이미지 생성
                DrawPreviewImage();
            }
        }

        /// <summary>
        /// 창 위치 변경 시 발생 이벤트.
        /// 처음 로드 될 때에도 동작되므로, 주의 할 것.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Move(object sender, EventArgs e)
        {
            Debug("FormCaptureArea_Move 호출");
            if (isLoaded)
            {
                //캡처 이미지 생성
                DrawPreviewImage();
            }
        }

        /// <summary>
        /// 창 클릭 이벤트.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgCaptureScreen_Click(object sender, EventArgs e)
        {
            //이미지 파일 저장
            //save();
        }
        
        /// <summary>
        /// 단축키 지정
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData;
            if (key != Keys.ShiftKey)
            {
                //debug(key.ToString());
                if (key == Keys.P || key == Keys.PrintScreen || key == Keys.Print || key == Keys.F1)
                {
                    Save();//이미지 저장 호출
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void WndProc(ref Message m)
        {
            // resizable 
            if (m.Msg == WM_NCHITTEST)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);

            // movable -----------------
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
            // ---------------- movable
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
