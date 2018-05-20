using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Capture
{

    class ScreenImageDrawer
    {
        private readonly Point ptZero = new Point(0, 0);

        public Image PreviewImage { get; }
        public Image ResultImage { get; private set;}
        public Size szPreviewImage;

        public ScreenImageDrawer(Size previewImageSize)
        {
            PreviewImage = new Bitmap(previewImageSize.Width, previewImageSize.Height);
            szPreviewImage = previewImageSize;
        }



        /// <summary>
        /// 스크린 이미지 생성 및 저장 메서드.
        /// byteDate[] 타입의 멤버변수에 저장을 한다.
        /// 기존의 getImageCopyFromScreen 메서드를 대체한다.
        /// 기존의 bitmap 리턴 타입에서 byte 타입으로 개선되었다.(메모리 회수가 더 쉽다)
        /// 가비지 컬렉션을 배려한 using 구문으로 대처하였다.
        /// </summary>
        /// <param name="startPoint">시작점좌표</param>
        /// <param name="imageSize">이미지크기</param>
        public void DrawResultImageFromScreen(Point startPoint, Size imageSize)
        {
            // 임시 bitmap 을 생성 한 후 작업. using 내부의 new 는 자동 해제 됨.
            using (Bitmap bitmap = new Bitmap(imageSize.Width, imageSize.Height, PixelFormat.Format32bppArgb))
            {
                // 임시 Bitmap 에서 Graphic도구 를 생성
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
                    g.CopyFromScreen(startPoint, ptZero, imageSize, CopyPixelOperation.SourceCopy);
                }

                // 결과 이미지
                if (ResultImage != null) { ResultImage.Dispose(); }
                ResultImage = new Bitmap(bitmap);

            }
        }

        /// <summary>
        /// 미리보기 이미지를 그리는 메서드
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="areaSize"></param>
        public void DrawPreviewImageFromScreen(Point startPoint, Size areaSize)
        {
            // 임시 bitmap 을 생성 한 후 작업. using 내부의 new 는 자동 해제 됨.
            using (Bitmap bitmap = new Bitmap(areaSize.Width, areaSize.Height, PixelFormat.Format32bppArgb))
            {
                // 임시 Bitmap 에서 Graphic도구 를 생성
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
                    g.CopyFromScreen(startPoint, ptZero, areaSize, CopyPixelOperation.SourceCopy);
                }
                // 미리보기 이미지 드로잉
                DrawPreviewImage(bitmap);

            }
        }

        /// <summary>
        /// ResultImage에서 미리보기 이미지 드로잉
        /// 호출하기 전에 결과 이미지를 먼저 처리해주어야 한다. 안 그러면 예전 이미지가 나오게 됨.
        /// </summary>
        public void DrawPreviewImage()
        {
            DrawPreviewImage(ResultImage);
        }

        /// <summary>
        /// Image 인스턴스로부터 '미리보기 이미지' 드로잉
        /// </summary>
        /// <param name="image"></param>
        public void DrawPreviewImage(Image image)
        {
            // 미리보기 이미지 생성
            using (Graphics g = Graphics.FromImage(PreviewImage))
            {
                //결과 이미지와 미리보기 이미지의 사이즈가 다르므로 이것을 리사이징 하는 부분이다.
                g.DrawImage(image, 0, 0, PreviewImage.Width, PreviewImage.Height);

                //리사이징 하면서 이미지가 지저분하므로, 렌더링 처리를 한다.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
        }
    }
}
