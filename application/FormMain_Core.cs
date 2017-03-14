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
        private Image resultImage;

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

            //전체 스크린샷 이미지를 가져옴.
            drawImagebyFullScreen();

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
        private void drawImagebyFullScreen()
        {
            /*
            복수개의 모니터는 Screen.AllScreens 컬렉션 속성을 참조하여 엑세스할 수 있다.
            즉, 첫번째 모니터는 Screen.AllScreens[0], 두번째 모니터는 Screen.AllScreens[1] 등과 같이 엑세스한다.
            */
            createImageByScreen(ptZero, Screen.PrimaryScreen.Bounds.Size);
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
        public void createImageByScreen(Point _pointStart, Size _sizeImage)
        {
            // dlatl bitmap 을 생성 한 후 작업. using 내부의 new 는 자동 해제 됨.
            using (Bitmap bitmap = new Bitmap(_sizeImage.Width, _sizeImage.Height, PixelFormat.Format32bppArgb))
            {
                //임시 비트맵으로 그래픽도구를 생성. 그리기 시작한다.
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //그래픽 옵션 주기
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;//이것이 가장 퀄리티가 높다고 함.
                    //g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;//샘플로 추가
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    //스크린 캡쳐 시작                    
                    // 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    //copypixeloperation 옵션을 줄 수도 있다.
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage, CopyPixelOperation.SourceCopy);
                }

                if (resultImage != null) { resultImage.Dispose(); }
                resultImage = new Bitmap(bitmap);

                // 미리보기 이미지 생성
                using (Graphics g = Graphics.FromImage(previewImage))
                {
                    //결과 이미지와 미리보기 이미지의 사이즈가 다르므로 이것을 리사이징 하는 부분이다.
                    g.DrawImage(bitmap, 0, 0, szPreviewImage.Width, szPreviewImage.Height);

                    //리사이징 하면서 이미지가 지저분하므로, 렌더링 처리를 한다.
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    //미리보기 화면상에 지정
                    picboxPreview.Image = previewImage;
                }
            }
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
