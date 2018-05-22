using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Text;

/// <summary>
/// 전체 화면 스크린 캡쳐 기능 을 모아놓음
/// </summary>
namespace Image_Capture
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 결과 이미지
        /// </summary>
        public Image resultImage;

        /// <summary>
        /// point 0, 0
        /// </summary>
        Point ptZero = new Point(0, 0);

        /// <summary>
        /// 
        /// </summary>
        string strFilePath = "";

        /// <summary>
        /// 결과 이미지의 사이즈 개체
        /// </summary>
        Size szResultImage = new Size(0, 0);

        /// <summary>
        /// 미리보기 이미지의 사이즈 값.
        /// 윈도우 설정에 따라 변경 될 수 있으므로, Load 된 이후에 실제 크기(픽셀) 을 알아온다.
        /// </summary>
        public Size szPreviewImage;

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
            //Debug(this.Location.ToString());

            Screen screen = Screen.FromControl(this);

            //Debug(screen.DeviceName);
            //Debug(screen.Bounds.Location.ToString());

            //기본창을 최소화.
            this.HideForm();

            /*
            복수개의 모니터는 Screen.AllScreens 컬렉션 속성을 참조하여 엑세스할 수 있다.
            즉, 첫번째 모니터는 Screen.AllScreens[0], 두번째 모니터는 Screen.AllScreens[1] 등과 같이 엑세스한다.
            주 모니터만 참고하려면 PrimaryScreen 을 사용할 수 있다.
            */

            // 스크린샷 이미지를 생성하고, 미리보기 이미지도 생성
            //DrawImagebyFullScreen();
            DrawResultImageWithPreviewImage(screen.Bounds.Location,screen.Bounds.Size);

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
                SaveFile_Dialog();
            }
            else
            {
                if (resultImage != null) { resultImage.Dispose(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowForm()
        {
            this.Visible = true;//활성화
            this.Opacity = 100;
            this.WindowState = FormWindowState.Normal;//폼의 상태를 일반 상태로 되돌림.
        }

        /// <summary>
        /// 
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
        /// <param name="msg"></param>
        private void Debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void Debug(string msg, string msg2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(msg);
            sb.Append(msg2);
            Debug(sb.ToString());
            sb.Clear();
        }
    }
}
