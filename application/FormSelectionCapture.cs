using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;

/// <summary>
/// 영역 캡처 다이얼로그
/// 
/// imgCaptureScreen 는 캡처영역의 사이즈(투명 영역의 사이즈)
/// </summary>
namespace Image_Capture
{
    public partial class FormSelectionCapture : Form
    {
        /// <summary>
        /// 로그 디버깅 옵션.
        /// </summary>
        private readonly bool isDebug = false;

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
        /// 
        /// </summary>
        private const int cGrip = 16;

        /// <summary>
        /// 
        /// </summary>
        private const int cCaption = 32;

        /// <summary>
        /// 
        /// </summary>
        private const int WM_NCHITTEST = 0x84;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        /// <summary>
        /// 드래그 가능하게 해주는 SendMessage, ReleaseCapture 추가
        /// </summary>
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll")]
            internal static extern bool ReleaseCapture();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_parentForm"></param>
        public FormSelectionCapture(FormMain _parentForm)
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
            //mParentForm.DrawResultImage(locationCaptureArea,sizeCaptureArea);
            mParentForm.DrawResultImageWithPreviewImage(locationCaptureArea, sizeCaptureArea);
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
                timer1.Stop();
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
                timer1.Stop();
                //미리보기 이미지 생성
                DrawPreviewImage();
            }
        }

        /// <summary>
        /// 헤더의 Panel 에서 창 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void Debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine($"[FormSelectionCapture] {msg}");
        }

        /// <summary>
        /// Debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msg2"></param>
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

        /// <summary>
        /// 단축키 지정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();//이미지 저장 호출
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            } else if (e.Control && e.KeyCode == Keys.W)
            {
                this.Close();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Debug("Timer_Tick");
            //미리보기 이미지 생성
            DrawPreviewImage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_ResizeEnd(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// 드래그 가능하게 하기 위함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, (IntPtr)0);
            }
            //mousePoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// 창 크기 조절을 위한 부분
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int HT_LEFT = 10;
            const int HT_RIGHT = 11;
            //const int HT_TOP = 12;
            //const int HT_TOPLEFT = 13;
            //const int HT_TOPRIGHT = 14;
            //const int HT_BOTTOM = 15;
            const int HT_BOTTOMLEFT = 16;
            const int HT_BOTTOMRIGHT = 17;

            // resizable 
            if (m.Msg == WM_NCHITTEST)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)HT_CAPTION;
                    return;
                }
                // 우측 하단
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)HT_BOTTOMRIGHT;
                    return;
                }
                // 좌측 하단
                if (pos.X <= cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)HT_BOTTOMLEFT;
                    return;
                }
                // 좌측 
                if (pos.X <= 7)
                {
                    m.Result = (IntPtr)HT_LEFT;
                    return;
                }
                // 우측
                if (pos.X >= this.ClientSize.Width - 7)
                {
                    m.Result = (IntPtr)HT_RIGHT;
                    return;
                }
                // 하단
                if (pos.Y > this.ClientSize.Height - this.Padding.Bottom)
                {
                    m.Result = (IntPtr)HT_CAPTION;
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
