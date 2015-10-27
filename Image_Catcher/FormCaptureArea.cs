using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;//debug용

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
        FormMain parentForm;//부모폼을 담아올 용도.

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_parentForm"></param>
        public FormCaptureArea(FormMain _parentForm)
        {
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
            parentForm = _parentForm;//부모 폼 값
            setCaptureScreenSize();
        }

        /// <summary>
        /// 로드되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 스크린의 사이즈를 셋팅.
        /// 현재 창에서 여백을 제거하고, 투명영역의 크기를 조절함.
        /// </summary>
        private void setCaptureScreenSize()
        {
            int w = this.Size.Width - 18;
            int h = this.Size.Height - 39;

            //사이즈에 맞춰서 투명영역을 조절함.
            imgCaptureScreen.Size = new Size(w,h);
        }


        private void getCapture()
        {
            //이미지 반영 시키기
            int ScreenX = this.Location.X+9;//찍기 시작하는 좌표
            int ScreenY = this.Location.Y+30;

            
            int ScreenW = imgCaptureScreen.Width;
            int ScreenH = imgCaptureScreen.Height;
            //------------------------------------------------------
            // 설명 : 이미지 가져오기. 정의한 메서드(private) 
            // 인수 : 전체스크린에서의 시작점좌표, 이미지에 넣을 좌표, 이미지에 넣을 크기
            parentForm.imgCaptureResult = getImageCopyFromScreen(
                                            new Point(ScreenX, ScreenY),
                                            new Point(0, 0),
                                            new Size(ScreenW, ScreenH));//그려진 비트맵을 객체에 넣는다.
            //------------------------------------------------------
            //미리보기 생성
            parentForm.imgPreview.Image = parentForm.getImageResizeFromImage(parentForm.imgCaptureResult, parentForm.imgPreview.Size);
        }

        /// <summary>
        /// 창 리사이즈 시 발생 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Resize(object sender, EventArgs e)
        {
            setCaptureScreenSize();//투명영역의 크기 조절
            getCapture();
        }

        /// <summary>
        /// 창 위치 변경 시 발생 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_LocationChanged(object sender, EventArgs e)
        {
            getCapture();
        }

        /// <summary>
        /// 창 클릭 이벤트.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgCaptureScreen_Click(object sender, EventArgs e)
        {
            //이미지 저장 호출
            save();
        }

        /// <summary>
        /// 메인 폼의 이미지 저장 메서드 호출
        /// </summary>
        private void save()
        {
            //들어있는 imgCapture 의 내역을 파일로 저장시키는 메서드.
            parentForm.imgCapture_Save();
        }
        //-------------------------------------------------------
        //지정한 크기 만큼 스크린샷 메서드.
        //형식인수 : 시작할좌표, 이미지에 넣을 좌표, 이미지에 넣을 크기
        private Bitmap getImageCopyFromScreen(Point ptScreen, Point ptDraw, Size szImage)
        {
            return parentForm.getImageCopyFromScreen(ptScreen, ptDraw, szImage);
        }

        /// <summary>
        /// 단축키 지정
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData;
            //MessageBox.Show("ProcessCmdKey keyData[" + keyData + "] ");
            if(key!=Keys.ShiftKey){
                if (key == Keys.P || key == Keys.PrintScreen || key == Keys.Print || key==Keys.F1)
                {
                    //이미지 저장 호출
                    save();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }//class
}//namespace
