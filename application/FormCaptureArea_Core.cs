using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// 영역 캡처 다이얼로그
/// 
/// [메모]
/// imgCaptureScreen 는 캡처영역의 사이즈(투명 영역의 사이즈)
/// </summary>
namespace Image_Capture
{
    public partial class FormCaptureArea : Form
    {
        /// <summary>
        /// '영역 선택 창' 의 좌표
        /// </summary>
        Point ptScreenXY;

        /// <summary>
        /// '영억 선택 창' 의 크기
        /// </summary>
        Size szScreenWH;

        /// <summary>
        /// 로드가 완료되었는지 여부.
        /// </summary>
        bool isLoaded = false;

        /// <summary>
        /// 스크린의 사이즈를 셋팅.
        /// 현재 창에서 여백을 제거하고, 투명영역의 크기를 조절함.
        /// </summary>
        private void ResizeCaptureArea()
        {
            //선택 창의 사이즈 조절에 맞춰서, 투명영역의 사이즈를 조절한다.
            if (ClientSize.Width >= 0)
            {
                picboxCaptureScreen.Width = ClientSize.Width;
            }
            if (ClientSize.Height >= 0)
            {
                picboxCaptureScreen.Height = ClientSize.Height;
            }
        }

        /// <summary>
        /// 스크린샷 이미지 생성
        /// </summary>
        private void getCapture()
        {
            /**
            * 선택영역의 좌표를 구하기. (좌표는 상단 좌측 기준으로 0,0 으로 시작한다)
            * 그러므로, 해당 창 의 좌표를 구하고, 거기서 헤더부분과 좌측 border 를 추가한 좌표를 구해야한다.
            * X : 선택 창의 X 좌표
            * Y : 선택 창의 Y 좌표
            */
            ptScreenXY.X = this.Location.X + (Width - ClientSize.Width) / 2;
            ptScreenXY.Y = this.Location.Y + (Height - ClientSize.Height - (Width - ClientSize.Width) / 2);

            debug("ScreenXY["+ptScreenXY.ToString()+"] thisLocation["+ this.Location.ToString()+"] this.Size["+this.Size.ToString()+"] ClientSize["+ClientSize.ToString()+"]");
            // 선택영역의 가로 세로 크기 구하기.
            szScreenWH.Width = picboxCaptureScreen.Width;
            szScreenWH.Height = picboxCaptureScreen.Height;

            // 시작 좌표와 영역을 통해서 미리보기 이미지 생성
            mParentForm.DrawPreviewImage(ptScreenXY, szScreenWH);

            // 좌표와 사이즈 를 기준으로 스크린샷 생성
            //mParentForm.createImageByScreen(ptScreenXY, szScreenWH);



            //mParentForm.ScreenImageDrawer.DrawResultImageFromScreen(ptScreenXY, szScreenWH);
            //mParentForm.ScreenImageDrawer.DrawPreviewImage();

            //mParentForm.resultImage = mParentForm.ScreenImageDrawer.ResultImage;
            //mParentForm.picboxPreview.Image = mParentForm.ScreenImageDrawer.PreviewImage;
        }

        /// <summary>
        /// 이미지 파일 저장
        /// 메인 폼의 이미지 저장 메서드 호출
        /// </summary>
        private void save()
        {
            mParentForm.SaveAndDrawResultImage(ptScreenXY, szScreenWH);
            //mParentForm.SaveFile_Result();
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
        /// Debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msg2"></param>
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
