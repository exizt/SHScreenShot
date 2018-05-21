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
            mParentForm.SaveAndDrawResultImage(locationCaptureArea, sizeCaptureArea);
            //mParentForm.SaveFile_Result();
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
            StringBuilder sb = new StringBuilder();
            sb.Append(msg);
            sb.Append(msg2);
            Debug(sb.ToString());
            sb.Clear();
        }
    }
}
