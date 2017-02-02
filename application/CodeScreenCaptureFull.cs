using System;
using System.Diagnostics;//debug용
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

/// <summary>
/// 전체 화면 스크린 캡쳐 기능 을 모아놓음
/// </summary>
namespace Image_Capture
{
    public partial class FormMain : Form
    {
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
    }
}
