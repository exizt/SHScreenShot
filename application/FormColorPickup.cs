using System;
using System.Drawing;
using System.Windows.Forms;


/// <summary>
/// [구현 방식 설명]
/// 스포이드 모양의 이미지를 불러온다.
/// 이 이미지의 크기로 투명의 윈도우를 생성한다.
/// 이 윈도우는 마우스의 위치에 따라, 따라다니면서 움직이게 된다.
/// 이 과정에서 원래의 커서는 숨겨준다.
/// 이 창을 종료하게 되면 커서는 복구된다.
/// </summary>
namespace SHColorPicker
{
    public partial class FormColorPickup : Form
    {
        /// <summary>
        /// 부모폼을 담아올 용도.
        /// </summary>
        FormMain mParentForm;

        /// <summary>
        /// 로그 디버깅 옵션
        /// </summary>
        bool isDebug = false;

        /// <summary>
        /// true 값으로 하면, 창의 투명화를 해제해서, 디버깅 하는 용도.
        /// </summary>
        bool isCursorDebug = false;

        /// <summary>
        /// 마우스의 좌표를 담을 용도.
        /// </summary>
        Point ptMouseCursor = new Point();
        
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

            //부모창의 preview 와 크기가 같은 bitmap 생성
            init();
        }

        /// <summary>
        /// 로드 되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormColorPickup_Load(object sender, EventArgs e)
        {
            /*
            * 1. 커서가 hidden 처리가 되지 않았다면, 여기서 hidden 처리를 한다.
            * 그러나 권장되는 것은, 이 윈도우가 뜨기 전에 이미 hide 처리 할 것을 권장한다.
            */
            // 테스트 중일 때에는 검은 화면으로 보면서 확인.
            if (isCursorDebug)
            {
                Cursor.Show();
                picSection.BackColor = Color.Black;
            }
            else
            {
                Cursor.Hide();
            }

            //debug("FormColorPickup_Load 호출");
            //szImgPreviewParent = mParentForm.szPreviewImage;

            // spoid picturebox 를 조절하고, spoid 를 정가운데에 놓음
            loadPickup();

            //이벤트 발생
            timerPickupColor_Tick(sender, e);
            //timerPickupColor.Interval = 1;
            timerPickupColor.Start();

        }

        /// <summary>
        /// Timer 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPickupColor_Tick(object sender, EventArgs e)
        {
            //마우스 포인터에 변화가 없을 때에는 동작하지 않도록 합니다.
            if (Equals(ptMouseCursor, Control.MousePosition))
            {
                //return;
            }

            // 마우스 커서의 좌표를 가져오기
            ptMouseCursor = Control.MousePosition;

            // 이벤트 호출
            callEventColorPickup();
        }

        /// <summary>
        /// this 창의 클릭 이벤트에 의해서 호출될 메서드 이다.
        /// 여기서 종료시에 처리할 구문을 모아둔다.
        /// </summary>
        private void PickerClose()
        {
            Cursor.Show();
            timerPickupColor.Stop();

            Close();
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
    }
}
