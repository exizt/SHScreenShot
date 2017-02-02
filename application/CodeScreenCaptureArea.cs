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
        /// 스크린의 사이즈를 셋팅.
        /// 현재 창에서 여백을 제거하고, 투명영역의 크기를 조절함.
        /// </summary>
        private void setCaptureScreenSize()
        {
            //선택 창의 사이즈 조절에 맞춰서, 투명영역의 사이즈를 조절한다.
            imgCaptureScreen.Width = ClientSize.Width;
            imgCaptureScreen.Height = ClientSize.Height;
        }

        /// <summary>
        /// 스크린샷 이미지 생성
        /// TODO 메모리 누수 가 있는 듯
        /// </summary>
        private void getCapture()
        {
            /**
            * 선택영역의 좌표를 구하기. (좌표는 상단 좌측 기준으로 0,0 으로 시작한다)
            * 그러므로, 해당 창 의 좌표를 구하고, 거기서 헤더부분과 좌측 border 를 추가한 좌표를 구해야한다.
            */
            ptScreenXY.X = this.Location.X + (Width - ClientSize.Width) / 2;//선택 창의 X 좌표
            ptScreenXY.Y = this.Location.Y + (Height - ClientSize.Height - (Width - ClientSize.Width) / 2);//선택 창의 Y 좌표

            //선택영역의 가로 세로 크기 구하기.
            szScreenWH.Width = imgCaptureScreen.Width;
            szScreenWH.Height = imgCaptureScreen.Height;

            mParentForm.createImageByScreen(ptScreenXY, szScreenWH);
        }

        /// <summary>
        /// 이미지 파일 저장
        /// 메인 폼의 이미지 저장 메서드 호출
        /// </summary>
        private void save()
        {
            mParentForm.SaveFile_Result();
        }

    }
}
