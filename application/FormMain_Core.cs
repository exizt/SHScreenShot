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
        /// 화면상의 미리보기 비트맵 개체
        /// 주로 인스턴스로 사용되어서, picturebox.image 에 넣어지기 전까지 존재한다.
        /// </summary>
        Image previewImage;

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
        public void setImgPreview_Image(Image _image)
        {
            picboxPreview.Image = _image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_image"></param>
        public void setImgPreview_BackgroundImage(Image _image)
        {
            picboxPreview.BackgroundImage = _image;
        }

        /// <summary>
        /// 전체 스크린샷 메서드
        /// </summary>
        private void event_FullScreenCapture()
        {
            //기본창을 최소화.
            this.hideForm();

            // 스크린샷 이미지를 생성하고, 미리보기 이미지도 생성
            DrawImagebyFullScreen();

            //잠깐 텀 을 준후 윈도우창 복귀
            Thread.Sleep(50);
            this.showForm();

            SaveFile_Result();

            // 메모리 정리
            if (resultImage != null) { resultImage.Dispose(); }
        }

        /// <summary>
        /// 스크린 이미지 캡쳐 + 미리보기 이미지 생성
        /// </summary>
        private void DrawImagebyFullScreen()
        {
            /*
            복수개의 모니터는 Screen.AllScreens 컬렉션 속성을 참조하여 엑세스할 수 있다.
            즉, 첫번째 모니터는 Screen.AllScreens[0], 두번째 모니터는 Screen.AllScreens[1] 등과 같이 엑세스한다.
            */
            //ResultImage 만들기
            ScreenImageDrawer.DrawResultImageFromScreen(ptZero, Screen.PrimaryScreen.Bounds.Size);
            resultImage = ScreenImageDrawer.ResultImage;
            
            //PrevieImage 만들기 (ResultImage 를 기준으로)
            ScreenImageDrawer.DrawPreviewImage();
            picboxPreview.Image = ScreenImageDrawer.PreviewImage;

        }

        /// <summary>
        /// 미리보기 이미지 '만' 드로잉 하는 메서드
        /// 외부 에서도 호출 가능한 메서드. 좌표만 넘겨주면 됨.
        /// </summary>
        /// <param name="startPoint">시작 좌표</param>
        /// <param name="areaSize">영역 크기</param>
        public void DrawPreviewImage(Point startPoint, Size areaSize)
        {
            ScreenImageDrawer.DrawPreviewImageFromScreen(startPoint, areaSize);

            // ScreenImageDrawer.PreviewImage 의 포인터는 변하지 않는 포인트이므로, 메모리 누수 우려 안해도 됨.
            picboxPreview.Image = ScreenImageDrawer.PreviewImage;
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

        public void SaveAndDrawResultImage(Point startPoint, Size areaSize)
        {
            // 결과 이미지를 생성하는 부분
            ScreenImageDrawer.DrawResultImageFromScreen(startPoint, areaSize);
            resultImage = ScreenImageDrawer.ResultImage;

            SaveFile_Result();
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
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg, string msg2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(msg);
            sb.Append(msg2);
            debug(sb.ToString());
            sb.Clear();
        }
    }
}
