using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Image_Capture
{
    /// <summary>
    /// 이미지 캡쳐 등의 기능을 담은 클래스
    /// </summary>
    class ScreenImageDrawer : IDisposable
    {
        private readonly Point ptZero = new Point(0, 0);

        public Image PreviewImage { get; private set; }
        public Image ResultImage { get; private set;}

        /// <summary>
        /// ScreenImageDrawer 의 생성자
        /// </summary>
        /// <param name="previewSize">미리보기 이미지의 크기</param>
        public ScreenImageDrawer(Size previewSize)
        {
            //미리보기 이미지는 사이즈가 변경되진 않으므로 한번만 생성
            PreviewImage = new Bitmap(previewSize.Width, previewSize.Height);
        }

        /// <summary>
        /// 결과 이미지 생성
        /// 기존의 getImageCopyFromScreen 메서드를 대체한다.
        /// 기존의 bitmap 리턴 타입에서 byte 타입으로 개선되었다.(메모리 회수가 더 쉽다)
        /// 가비지 컬렉션을 배려한 using 구문으로 대처하였다.
        /// </summary>
        /// <param name="startPoint">시작점좌표</param>
        /// <param name="imageSize">이미지크기</param>
        public void DrawFromScreen(Point startPoint, Size imageSize, bool drawResult, bool drawPreview)
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

                if (drawResult)
                {
                    // 결과 이미지
                    if (ResultImage != null) { ResultImage.Dispose(); }
                    ResultImage = new Bitmap(bitmap);
                }

                if (drawPreview)
                {
                    // 미리보기 이미지 생성
                    using (Graphics g = Graphics.FromImage(PreviewImage))
                    {
                        //결과 이미지와 미리보기 이미지의 사이즈가 다르므로 이것을 리사이징 하는 부분이다.
                        g.DrawImage(bitmap, 0, 0, PreviewImage.Width, PreviewImage.Height);

                        //리사이징 하면서 이미지가 지저분하므로, 렌더링 처리를 한다.
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (PreviewImage != null) { PreviewImage.Dispose(); }
                if (ResultImage != null) { ResultImage.Dispose(); }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ScreenImageDrawer()
        {
            Dispose(false);
        }
    }
}
