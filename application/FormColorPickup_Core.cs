using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SHColorPicker
{
    public partial class FormColorPickup : Form
    {
        /// <summary>
        /// 확대 배율. (기본값으로는 2배. 차후 변경 가능하게 구성)
        /// </summary>
        int magnif = 2;

        /// <summary>
        /// point 0, 0
        /// </summary>
        Point ptZero = new Point(0, 0);

        /// <summary>
        /// 부모폼에 있는 미리보기 사이즈.
        /// </summary>
        Size szPreviewImage;

        /// <summary>
        /// 미리보기 사이즈 를 배율을 역으로 축소시킨 사이즈.
        /// </summary>
        Size szPreviewCompress;
        Point ptPreviewCompress;

        /// <summary>
        /// 미리보기 이미지 비트맵
        /// </summary>
        Bitmap bitmapPreview;

        Point _spoidPicture_Location = new Point();
        
        /// <summary>
        /// 부모창의 Preview 와 동일한 크기의 Bitmap 생성
        /// 기본창의 '미리보기' PictureBox 가 있는데, 이것과 동일한 크기의 Bitmap 을 생성해놓는 작업이다.
        /// </summary>
        private void initPickup()
        {
            szPreviewImage = mParentForm.imgPreview.Size;

            //부모창의 Preview 와 동일한 크기의 Bitmap 생성
            if (bitmapPreview != null) bitmapPreview.Dispose();
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

            // 확대될 영역 (축소된 영역) 을 계산 (배율 역계산)
            szPreviewCompress.Width = szPreviewImage.Width / magnif;
            szPreviewCompress.Height = szPreviewImage.Height / magnif;

            // 필요한 만큼으로만 윈도우 폼 을 구성
            _formSize.Width = szPreviewCompress.Width + 100;
            _formSize.Height = szPreviewCompress.Height + 100;
            this.Size = _formSize;

            // ColorPickupForm 의 중간으로 Spoid Icon 위치
            _spoidPicture_Location.X = _formSize.Width / 2;
            _spoidPicture_Location.Y = _formSize.Height / 2 - this.spoidPicture.Height;
            this.spoidPicture.Location = _spoidPicture_Location;
        }

        /// <summary>
        /// 타이머 로 로드할 메서드
        /// </summary>
        /// <param name="mousePosition"></param>
        private void callEventColorPickup(Point mousePosition)
        {

            // 마우스 커서를 기준으로 해당 윈도우 창 (픽업용 히든 윈도우) 이 
            // 따라 움직이게 XY 좌표를 이동
            _formLocation.X = mousePosition.X - (Size.Width / 2);
            _formLocation.Y = mousePosition.Y - (Size.Height / 2);
            this.Location = _formLocation;

            // 축소된 영역의 XY 좌표
            ptPreviewCompress.X = mousePosition.X - (szPreviewCompress.Width / 2);
            ptPreviewCompress.Y = mousePosition.Y - (szPreviewCompress.Height / 2);

            // 미리보기 이미지 를 생성
            //bitmapPreview = createPreviewBitmap(ptPreviewImageCompress, szPreviewImageCompress);
            drawPreviewBitmap(ptPreviewCompress, szPreviewCompress, bitmapPreview);

            // 색상코드 를 추출. 부모창에 대입.
            mParentForm.generateView_fromColor(getColorFromImage(bitmapPreview));

            // 결과를 부모창의 미리보기 이미지 에 대입
            mParentForm.imgPreview.Image = bitmapPreview;
        }

        /// <summary>
        /// 이미지 생성. 스크린에서 xy 좌표, width height 를 기준으로 이미지를 생성.
        /// 이미지 를 확대함
        /// </summary>
        /// <param name="point">축소된 영역의 xy 좌표</param>
        /// <param name="size">축소된 영역의 size</param>
        /// <returns></returns>
        private void drawPreviewBitmap(Point _pointStart, Size _sizeImage,Image _PreviewImage)
        {
            // 임시 bitmap 을 생성 한 후 작업. using 내부의 new 는 자동 해제 됨.
            using (Bitmap bitmap = new Bitmap(_sizeImage.Width, _sizeImage.Height, PixelFormat.Format32bppArgb))
            {
                // 임시 bitmap 을 기준으로 grahipcs 를 시작.
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // 인수:스크린좌표,그리기시작좌표,그리는사이즈.
                    g.CopyFromScreen(_pointStart, ptZero, _sizeImage);
                }

                // 이미지 의 확대 동작
                using (Graphics g = Graphics.FromImage(_PreviewImage))
                {
                    //이 항목이 있어야 선명하게 확대가 된다.
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    //이미지 확대 (bitmap 의 크기가 작고, szPreviewImage 의 크기가 커서 확대가 됨)
                    g.DrawImage(bitmap, 0, 0, szPreviewImage.Width, szPreviewImage.Height);
                }
            }
        }

        /// <summary>
        /// 이미지 의 정가운데에 있는 픽셀의 값을 가져옴
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        /// 
        private Color getColorFromImage(Image image)
        {
            using (Bitmap b = new Bitmap(image))
            {
                return b.GetPixel((int)(image.Width / 2), (int)(image.Height/2));
            }
        }

        /// <summary>
        /// 디버그용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg)
        {
            if(isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}
