using System.Drawing;
using System.Windows.Forms;

namespace SHColorPicker
{
    public partial class FormColorPickup : Form
    {
        int magnif = 2;//확대 배율. (기본값으로는 2배. 차후 변경 가능하게 구성)

        /// <summary>
        /// 부모폼에 있는 미리보기 사이즈.
        /// </summary>
        Size szPreviewImage;

        /// <summary>
        /// 미리보기 사이즈 를 배율을 역으로 축소시킨 사이즈.
        /// </summary>
        Size szPreviewImageCompress;
        Point ptPreviewImageCompress;

        /// <summary>
        /// 미리보기 이미지 비트맵
        /// </summary>
        Bitmap bitmapPreview;

        /// <summary>
        /// 선택한 색상 코드
        /// </summary>
        Color colorResult;

        /// <summary>
        /// 부모창의 Preview 와 동일한 크기의 Bitmap 생성
        /// 기본창의 '미리보기' PictureBox 가 있는데, 이것과 동일한 크기의 Bitmap 을 생성해놓는 작업이다.
        /// </summary>
        private void initPickup()
        {
            //부모창의 Preview 와 동일한 크기의 Bitmap 생성
            bitmapPreview = new Bitmap(mParentForm.imgPreview.Width, mParentForm.imgPreview.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        /// <summary>
        /// 현재 창의 spoid Picturebox 영역의 크기를 확대축소 비율에 맞게 조절한다. 
        /// 스포이드 는 그 정가운데에 놓도록 한다.
        /// </summary>
        private void loadPickup()
        {
            // 부모창의 미리보기 사이즈 를 가져와서 대입
            szPreviewImage = bitmapPreview.Size;

            // 역으로 축소된 사이즈를 계산 (축소 버전 미리보기 이미지)
            szPreviewImageCompress.Width = szPreviewImage.Width / magnif;
            szPreviewImageCompress.Height = szPreviewImage.Height / magnif;

            // 필요한 만큼으로만 윈도우 폼 을 구성
            this.Size = new Size(szPreviewImageCompress.Width + 100, szPreviewImageCompress.Height + 100);

            // 작아진 윈도우 폼 에 맞춰서 스포이드 위치 조정
            this.spoidPicture.Location = new Point(this.Size.Width/2, this.Size.Height/2- this.spoidPicture.Height);
        }

        /// <summary>
        /// 타이머 로 로드할 메서드
        /// </summary>
        /// <param name="mousePosition"></param>
        private void callEventColorPickup(Point mousePosition)
        {
            // 마우스 커서를 기준으로 해당 윈도우 창 (픽업용 히든 윈도우) 이 
            // 따라 움직이게 XY 좌표를 이동
            winCPoint.X = mousePosition.X - Size.Width / 2;
            winCPoint.Y = mousePosition.Y - Size.Height / 2;
            this.Location = winCPoint;

            // 축소된 영역의 XY 좌표
            ptPreviewImageCompress.X = mousePosition.X - szPreviewImageCompress.Width / 2;
            ptPreviewImageCompress.Y = mousePosition.Y - szPreviewImageCompress.Height / 2;

            // 미리보기 이미지 를 생성
            //bitmapPreview = createPreviewBitmap(ptPreviewImageCompress, szPreviewImageCompress);
            createPreviewBitmap(ptPreviewImageCompress, szPreviewImageCompress);

            // 색상코드 를 추출
            colorResult = getColorFromImage(bitmapPreview, new Point(szPreviewImage.Width / 2, szPreviewImage.Height / 2));
        }



        /// <summary>
        /// 이미지 생성. 스크린에서 xy 좌표, width height 를 기준으로 이미지를 생성.
        /// 이미지 를 확대함
        /// </summary>
        /// <param name="point">축소된 영역의 xy 좌표</param>
        /// <param name="size">축소된 영역의 size</param>
        /// <returns></returns>
        private void createPreviewBitmap(Point point, Size size)
        {
            using (Bitmap bitmap = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                // 작은 이미지의 생성
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    g.CopyFromScreen(point, new Point(0, 0), size);// 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                }

                // 이미지 의 확대 동작
                using (Graphics g = Graphics.FromImage(bitmapPreview))
                {
                    //이 항목이 있어야 선명하게 확대가 된다.
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    //이미지 확대 (bitmap 의 크기가 작고, szPreviewImage 의 크기가 커서 확대가 됨)
                    g.DrawImage(bitmap, 0, 0, szPreviewImage.Width, szPreviewImage.Height);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private Color getColorFromImage(Image image,Point point)
        {
            using (Bitmap b = new Bitmap(image))
            {
                return b.GetPixel((int)(point.X), (int)(point.Y));
            }
        }
    }
}
