using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;//dll 임포트를 위한 녀석.
using System.Diagnostics;//debug용


/// <summary>
/// [구현 방식 설명]
/// 스포이드 모양의 이미지를 불러온다.
/// 이 이미지의 크기로 투명의 윈도우를 생성한다.
/// 이 윈도우는 마우스의 위치에 따라, 따라다니면서 움직이게 된다.
/// 이 과정에서 원래의 커서는 숨겨준다.
/// 이 창을 종료하게 되면 커서는 복구된다.
/// </summary>
namespace Image_Capture
{
    public partial class FormColorPickup : Form
    {
        FormMain mParentForm;//부모폼을 담아올 용도.
        
        int magnification = 2;//확대 배율(기본값 2배)
        Size szPickupArea;//확대될 영역(부모폼 / 배율)

        Size szImgPreviewParent;//부모폼에 있는 미리보기 사이즈.
        Size szImgSpoid = new Size(16,16);

        Point ptMouseCursor = new Point();//마우스의 좌표를 담을 용도.
        //Point ptSpoid = new Point();//스포이드의 좌표를 담을 용도.
        Point winCPoint = new Point();//서브윈도우 창의 좌표를 담을 용도.
        Point ptPreviewImage = new Point();//미리보기 이미지 생성 시의 시작좌표

        bool isCursorTest = false;
        //Bitmap bitmapPreviewImage = null;//미리보기 이미지 개체
        //Bitmap bitmapPreviewImageParent = null;

        //Graphics graphics;//그래픽 공간으로 사용할 곳. 임시적으로 사용하고, 메서드 내에서는 반드시 dispose 할 것.

        Color colorPixel;//색상코드 값

        /// <summary>
        /// 생성자
        /// 기본 메서드. 폼 초기화.
        /// </summary>
        /// <param name="_parentForm"></param>
        public FormColorPickup(FormMain _parentForm)
        {
            //컴포넌트 초기화 메서드(기본적으로 들어감)
            InitializeComponent();

            //부모 폼 값
            mParentForm = _parentForm;

            //디버깅 할 시에, 아래 주석을 풀면, 투명이 해제 됨.
            isCursorTest = false;

            //szImgPreviewParent = mParentForm.szPreviewImage;

            //미리보기 이미지 사이즈를 구한다.
            //부모창의 보여질 미리보기 이미지 사이즈 / 배율 만큼 작은 사이즈를 구한다.
            //szPickupArea.Width = szImgPreviewParent.Width / magnification;
            //szPickupArea.Height = szImgPreviewParent.Height / magnification;

            //미리보기 이미지 개체를 생성
            //bitmapPreviewImage = new Bitmap(szPreviewImage.Width, szPreviewImage.Height);

            //부모창 미리보기객체에 넣을 이미지 객체
            //bitmapPreviewImageParent = new Bitmap(szImgPreviewParent.Width, szImgPreviewParent.Height);//임시 비트맵 생성

            //debug("FormColorPickup 생성자 호출");
        }

        //=============================================================
        //이벤트 메서드들.
        /// <summary>
        /// 로드 되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormColorPickup_Load(object sender, EventArgs e)
        {
            debug("FormColorPickup_Load 호출");

            szImgPreviewParent = mParentForm.szPreviewImage;

            //미리보기 이미지 사이즈를 구한다.
            //부모창의 보여질 미리보기 이미지 사이즈 / 배율 만큼 작은 사이즈를 구한다.
            szPickupArea.Width = szImgPreviewParent.Width / magnification;
            szPickupArea.Height = szImgPreviewParent.Height / magnification;

            /*
            * 1. 커서가 hidden 처리가 되지 않았다면, 여기서 hidden 처리를 한다.
            * 그러나 권장되는 것은, 이 윈도우가 뜨기 전에 이미 hide 처리 할 것을 권장한다.
            */
            //Cursor current = Cursor.Current;
            //if (current != null) {
            //    Cursor.Hide();
            //}

            // 테스트 중일 때에는 검은 화면으로 보면서 확인.
            if(isCursorTest)
            {
                Cursor.Show();
                pictureAreaPickupColor.BackColor = Color.Black;
            } else
            {
                Cursor.Hide();
            }

            //스포이드 모양 이미지의 좌표 구성
            //ptSpoid.X = Size.Width / 2;
            //ptSpoid.Y = Size.Height / 2 - szImgSpoid.Height;

            //스포이드 모양 이미지의 좌표 적용
            //투명 윈도우 안에서 중심부터 스포이드 아이콘을 둔다.
            //pictureAreaPickupColor.ImageLocation = ptSpoid.X + "," + ptSpoid.Y;



            //이벤트 발생
            timerPickupColor_Tick(sender, e);
            //timerPickupColor.Interval = 1;
            timerPickupColor.Start();

        }

        /// <summary>
        /// 창 클릭 시 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormColorPickup_Click(object sender, EventArgs e)
        {
            PickerClose();
        }

        private void pictureAreaPickupColor_Click(object sender, EventArgs e)
        {
            PickerClose();
        }

        private void spoidPicture_Click(object sender, EventArgs e)
        {
            PickerClose();
        }
        //=============================================================


        //debug method
        private void debug(string msg)
        {
            Debug.WriteLine(msg);
        }





        /// <summary>
        /// this 창의 클릭 이벤트에 의해서 호출될 메서드 이다.
        /// 여기서 종료시에 처리할 구문을 모아둔다.
        /// </summary>
        private void PickerClose()
        {
            Cursor.Show();
            //parentForm.ImgPreview_Spoid_Remove();
            timerPickupColor.Stop();
            Close();
        }

        //자체 정의 메서드. 색깔코드를 보여주는 메서드.
        private void PickerColorInput(Color cr)
        {
            mParentForm.txtColorCodeR.Text = cr.R.ToString();
            mParentForm.txtColorCodeG.Text = cr.G.ToString();
            mParentForm.txtColorCodeB.Text = cr.B.ToString();
            mParentForm.txtColorCodeFF.Text = ColorTranslator.ToHtml(cr).Substring(1,6);
            mParentForm.imgResultColor.BackColor = cr;
        }

        private void timerPickupColor_Tick(object sender, EventArgs e)
        {
            //마우스 포인터에 변화가 없을 때에는 동작하지 않도록 합니다.
            if (Equals(ptMouseCursor, Control.MousePosition))
            {
                return;
            }

            //마우스 커서의 좌표를 가져오기
            ptMouseCursor = Control.MousePosition;

            //현재 픽업 윈도우의 좌표값을 구성
            //마우스 커서에서 윈도우창의 반 정도를 뺀 값.
            winCPoint.X = ptMouseCursor.X - Size.Width / 2;
            winCPoint.Y = ptMouseCursor.Y - Size.Height / 2;

            //구성된 좌표값을 현재 픽업 윈도우에 반영
            Location = winCPoint;


            //이미지 반영 시키기
            //이것의 배율 크기만큼 작게, 그리고 거기서 1/2 를 각각 마우스 좌표에서 빼서. 시작 좌표를 구한다.
            ptPreviewImage.X = ptMouseCursor.X - szPickupArea.Width / 2;
            ptPreviewImage.Y = ptMouseCursor.Y - szPickupArea.Height / 2;

            //------------------------------------------------------
            // 설명 : 이미지 가져오기. 정의한 메서드(private) 
            // 인수 : 전체스크린에서의 시작점좌표, 이미지에 넣을 좌표, 이미지에 넣을 크기
            /*
            Image _image =  getImageCopyFromScreen(
                                            new Point(ScreenX, ScreenY),
                                            new Point(0, 0),
                                            szPreviewImage);//그려진 비트맵을 객체에 넣는다.
                                            */
            //특정 영역의 이미지를 그리기.
            //drawPreviewImage(ptPreviewImage, szPreviewImage);
            //mParentForm.getByteFromScreen(ptPreviewImage, szPickupArea);
            //------------------------------------------------------

            //------------------------------------------------------
            // 설명 : 이미지 가져오기. 정의한 메서드(private) 
            // 인수 : 전체스크린에서의 시작점좌표, 이미지에 넣을 좌표, 이미지에 넣을 크기
            //form1.imgPreview.Image = getImagePickUpAround();
            //------------------------------------------------------
            //drawPreviewImageParent();//미리보기 이미지(부모창에 사용할)를 생성
            //parentForm.setImgPreview_Image(bitmapPreviewImageParent);
            //mParentForm.drawPreviewImageFromBytes();//미리보기 이미지(부모창에 사용할)를 생성


            mParentForm.drawPreviewImage_ColorSpoid(ptPreviewImage, szPickupArea);

            //------------------------------------------------------
            // 설명 : 색상 코드 추출. 정의한 메서드(private)
            // 인수 : 이미지(PictureBox), 좌표(Point)
            colorPixel = mParentForm.getColorPixelPickup();
            //------------------------------------------------------

            //색상코드를 반영.
            PickerColorInput(colorPixel);
        }



        /**
        * --------------------------------------------
        * 폐기예정인 것들은 젤 아래로 모아두기.
        * --------------------------------------------
        */
    }
}
