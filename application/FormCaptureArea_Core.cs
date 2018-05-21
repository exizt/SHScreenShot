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
        /// deprecated
        /// 스크린의 사이즈를 셋팅.
        /// 현재 창에서 여백을 제거하고, 투명영역의 크기를 조절함.
        /// 레이아웃에서 Dock 기능을 사용했기 때문에...이제는 필요없어짐...
        /// </summary>
        private void ResizeCaptureArea()
        {
            /*
            //선택 창의 사이즈 조절에 맞춰서, 투명영역의 사이즈를 조절한다.
            if (ClientSize.Width >= 0)
            {
                picboxCaptureArea.Width = ClientSize.Width - CAPTURE_AREA_PADDING * 2;
            }
            if (ClientSize.Height >= 0)
            {
                picboxCaptureArea.Height = ClientSize.Height - CAPTURE_AREA_PADDING * 4;
            }
            */
        }

        /// <summary>
        /// 스크린샷 이미지 생성
        /// </summary>
        private void DrawPreviewImage()
        {
            /**
            * this.Location 은 창의 XY 좌표 (Screen 기준으로의 좌표. 상단 좌측부터 0,0 으로 시작됨)
            * this.Location 에서 촬영할 위치에 맞게 좌표를 조금씩 더 한다.
            */
            //ptScreenXY.X = this.Location.X + (Width - ClientSize.Width) / 2 + picboxCaptureArea.Location.X;
            //ptScreenXY.Y = this.Location.Y + (Height - ClientSize.Height - (Width - ClientSize.Width) / 2) + picboxCaptureArea.Location.Y;
            //ptScreenXY.X = this.Location.X + picboxCaptureArea.Location.X;
            //ptScreenXY.Y = this.Location.Y + picboxCaptureArea.Location.Y;


            //Point locationOnForm = picboxCaptureArea.FindForm().PointToClient(picboxCaptureArea.Parent.PointToScreen(picboxCaptureArea.Location));
            //Point locationOnForm = picboxCaptureArea.FindForm().PointToClient(picboxCaptureArea.Parent.PointToScreen(picboxCaptureArea.Location));
            Point locationCaptureArea = picboxCaptureArea.Parent.PointToScreen(picboxCaptureArea.Location);
            //ptScreenXY.X = locationCaptureArea.X;
            //ptScreenXY.Y = locationCaptureArea.Y;

            ptScreenXY = locationCaptureArea;

            Debug("ScreenXY["+ptScreenXY.ToString()+"] thisLocation["+ this.Location.ToString()+ "] locationOnForm[" + locationCaptureArea.ToString()+"]"+"picboxLocation["+picboxCaptureArea.Location.ToString()+"]");
            //debug("picboxCaptureScreen.location[" + picboxCaptureScreen.Location.ToString()+"]");
            
            
            // 선택영역의 가로 세로 크기 구하기.
            //szScreenWH.Width = picboxCaptureArea.Width;
            //szScreenWH.Height = picboxCaptureArea.Height;
            szScreenWH = picboxCaptureArea.Size;

            // 시작 좌표와 영역을 통해서 미리보기 이미지 생성
            mParentForm.DrawPreviewImage(locationCaptureArea, szScreenWH);

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
        private void Save()
        {
            mParentForm.SaveAndDrawResultImage(ptScreenXY, szScreenWH);
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
