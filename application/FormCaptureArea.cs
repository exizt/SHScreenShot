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
        /// '영역 선택 창' 의 좌표
        /// </summary>
        Point locationCaptureArea;

        /// <summary>
        /// '영역 선택 창' 의 크기
        /// </summary>
        Size sizeCaptureArea;

        /// <summary>
        /// 로드가 완료되었는지 여부.
        /// </summary>
        bool isLoaded = false;

        /// <summary>
        /// 로그 디버깅 옵션
        /// </summary>
        private bool isDebug = true;

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
            //캡처 이미지 생성
            DrawPreviewImage();

            //로드여부 활성화
            isLoaded = true;
        }


        /// <summary>
        /// 스크린샷 이미지 생성
        /// </summary>
        private void DrawPreviewImage()
        {
            /**
            * this.Location 은 창의 XY 좌표 (Screen 기준으로의 좌표. 상단 좌측부터 0,0 으로 시작됨)
            * this.Location 에서 촬영할 위치에 맞게 좌표를 조금씩 더 한다. (예전 방식이었음..)
            * PointToScreen 메서드가 있는 관계로 이것을 이용해서 더 간단히 함. 
            */
            this.locationCaptureArea = picboxCaptureArea.Parent.PointToScreen(picboxCaptureArea.Location);

            //Debug("ScreenXY[" + this.locationCaptureArea.ToString()+"] thisLocation["+ this.Location.ToString()+ "] locationOnForm[" + locationCaptureArea.ToString()+"]"+"picboxLocation["+ picboxCaptureArea.Location.ToString()+"]");
            //debug("picboxCaptureScreen.location[" + picboxCaptureScreen.Location.ToString()+"]");

            // 선택영역의 가로 세로 크기 구하기.
            sizeCaptureArea = picboxCaptureArea.Size;

            // 시작 좌표와 영역을 통해서 미리보기 이미지 생성
            mParentForm.DrawPreviewImage(locationCaptureArea, sizeCaptureArea);
        }

        /// <summary>
        /// 이미지 파일 저장
        /// 메인 폼의 이미지 저장 메서드 호출
        /// </summary>
        private void Save()
        {
            mParentForm.DrawResultImage(locationCaptureArea,sizeCaptureArea);
            mParentForm.SaveResultImageFile();
        }


        /// <summary>
        /// 창 리사이즈 시 발생 이벤트
        /// 처음 로드 될 때에도 불려지는 것으로 보인다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Resize(object sender, EventArgs e)
        {
            //Debug("FormCaptureArea_Resize 호출");
            if (isLoaded)
            {
                //미리보기 이미지 생성
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
            //Debug("FormCaptureArea_Move 호출");
            if (isLoaded)
            {
                //미리보기 이미지 생성
                DrawPreviewImage();
            }
        }

        /// <summary>
        /// 창 클릭 이벤트.
        /// 이제 안 쓰기로... 단축키로 사용함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgCaptureScreen_Click(object sender, EventArgs e)
        {
            //이미지 파일 저장
            //save();
        }

        /// <summary>
        /// 창 크기 조절을 위한 부분
        /// </summary>
        /// <param name="m"></param>
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

        /// <summary>
        /// 헤더의 Panel 에서 창 이동이 가능하게 하는 부분
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// 헤더의 Panel 에서 창 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void Debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// Debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msg2"></param>
        private void Debug(string msg, string msg2)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(msg);
            sb.Append(msg2);
            Debug(sb.ToString());
            sb.Clear();
        }

        /// <summary>
        /// 단축키 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                Save();//이미지 저장 호출
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }
    }
}
