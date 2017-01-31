using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;//debug용
using System.Security.Permissions;

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
        FormMain mParentForm;//부모폼을 담아올 용도.
        Point ptScreenXY;
        Size szScreenWH;
        //Bitmap bitmapScreen;

        /// <summary>
        /// 로드가 완료되었는지 여부.
        /// </summary>
        bool loaded = false;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_parentForm"></param>
        public FormCaptureArea(FormMain _parentForm)
        {
            //컴포넌트 초기화 메서드(기본적으로 들어감)
            InitializeComponent();

            //부모 폼 값
            mParentForm = _parentForm;
        }

        //=============================================================
        //이벤트 메서드들.
        /// <summary>
        /// 로드되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Load(object sender, EventArgs e)
        {
            //debug("FormCaptureArea_Load 호출");
            
            //투명영역의 크기 조절
            setCaptureScreenSize();
            //캡처 이미지 생성
            getCapture();

            //로드여부 활성화
            loaded = true;
        }

        /// <summary>
        /// 창 리사이즈 시 발생 이벤트
        /// 처음 로드 될 때에도 불려지는 것으로 보인다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCaptureArea_Resize(object sender, EventArgs e)
        {
            //debug("FormCaptureArea_Resize 호출");

            if(loaded)
            {
                //투명영역의 크기 조절
                setCaptureScreenSize();

                //debug("this.Size " + this.Size.Width + "," + this.Size.Height);
                //debug("this.Location " + this.Location.X + "," + this.Location.Y);
                //debug("imgCaptureScreenWH " + imgCaptureScreen.Width + "," + imgCaptureScreen.Height);
                
                //캡처 이미지 생성
                getCapture();
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
            //debug("FormCaptureArea_Move 호출");

            if (loaded)
            {
                //캡처 이미지 생성
                getCapture();
            }
        }

        /// <summary>
        /// 창 클릭 이벤트.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgCaptureScreen_Click(object sender, EventArgs e)
        {
            //이미지 파일 저장
            save();
        }

        //close of 이벤트 메서드들
        //=============================================================
        //debug method
        private void debug(string msg)
        {
            Debug.WriteLine(msg);
        }

        /// <summary>
        /// 스크린의 사이즈를 셋팅.
        /// 현재 창에서 여백을 제거하고, 투명영역의 크기를 조절함.
        /// </summary>
        private void setCaptureScreenSize()
        {
            //선택 창의 사이즈 조절에 맞춰서, 투명영역의 사이즈를 조절한다.
            //imgCaptureScreen.Width = Size.Width - 18;
            //imgCaptureScreen.Height = Size.Height - 39;
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
            ptScreenXY.X = this.Location.X + (Width-ClientSize.Width)/2;//선택 창의 X 좌표
            ptScreenXY.Y = this.Location.Y + (Height - ClientSize.Height - (Width - ClientSize.Width) / 2);//선택 창의 Y 좌표



            //선택영역의 가로 세로 크기 구하기.
            szScreenWH.Width = imgCaptureScreen.Width;
            szScreenWH.Height = imgCaptureScreen.Height;




            //debug("ptScreenXY " + ptScreenXY.X + "," + ptScreenXY.Y);
            //debug("szScreenWH " + szScreenWH.Width + "," + szScreenWH.Height);
            /**
            * 1. 결과값에 좌표 기준으로 image 타입 생성
            * 2. 미리보기 이미지에 결과값을 resize 한 것을 보여줌
            */
            // 스크린 화면에서 좌표와 크기에 따른 이미지 객체를 생성합니다.
            // 해당 이미지는 부모창에서 imgCaptureResult 에 기록이 됩니다.
            mParentForm.getByteFromScreen(ptScreenXY, szScreenWH);

            //미리보기 생성
            mParentForm.drawPreviewImageFromBytes();

        }

        /// <summary>
        /// 이미지 파일 저장
        /// 메인 폼의 이미지 저장 메서드 호출
        /// </summary>
        private void save()
        {
            //들어있는 imgCapture 의 내역을 파일로 저장시키는 메서드.
            //mParentForm.imgCapture_Save();
            mParentForm.saveFile_ResultImageFromBytes();
        }

        /// <summary>
        /// 단축키 지정
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
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



        /**
        * --------------------------------------------
        * 폐기예정인 것들은 젤 아래로 모아두기.
        * --------------------------------------------
        */
    }//class
}//namespace
