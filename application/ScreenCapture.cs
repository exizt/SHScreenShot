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
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage, CopyPixelOperation.SourceCopy);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
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
                    imgPreview.Image = previewImage;
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
    }
}
