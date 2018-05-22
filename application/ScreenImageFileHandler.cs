using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Image_Capture
{
    /// <summary>
    /// 이미지 파일 저장을 담당하는 클래스
    /// FormMain 의 구성 클래스
    /// </summary>
    class ScreenImageFileHandler
    {
        public string FileDirPath { get; set; }

        public ScreenImageFileHandler()
        {
            FileDirPath = GenerateBasePath();
        }

        /// <summary>
        /// 결과 이미지 저장. 파일 다이얼로그.
        /// </summary>
        public bool CallSaveFileDialog(Image image)
        {
            string filePath = "";
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "PNG 이미지 (*.png)|*.png|JPG 이미지 (*.jpg)|*.jpg|BMP 이미지 (*.bmp)|*.bmp|모든 파일 (*.*)|*.*";//확장자 선택
                fileDialog.Title = "스크린샷 이미지 저장";//창위에 뜨는 타이틀
                fileDialog.FileName = GenerateBaseFilename();
                fileDialog.DefaultExt = "png";
                //fileDialog.InitialDirectory = "";
                //showDialog의 리턴값이 OK 일 때
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                } else
                {
                    // 취소 한 경우
                    return false;
                }
            }
            
            if (filePath != "")
            {
                if (image != null)
                {
                    try
                    {
                        //image.Save(filePath, GetImageFormat(filePath));
                        SaveImageFile(image, filePath);
                        MessageBox.Show("저장 되었습니다.");
                        //저장이 완료된 경우에 속성값 FilePath 에 기록해둠.
                        FileDirPath = Path.GetDirectoryName(filePath);
                        return true;
                    }
                    catch (ArgumentNullException e)
                    {
                        MessageBox.Show("에러 발생 ArgNulls" + e);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("에러 발생" + e);
                    }
                }
                else { MessageBox.Show("그림을 캡쳐해주세요."); }
            }
            else
            { 
                // 경로를 잘못 지정한 경우
                MessageBox.Show("저장경로를 설정해주세요");
            }
            return false;
        }

        /// <summary>
        /// 퀵 세이브 기능.
        /// </summary>
        /// <param name="image"></param>
        public bool QuickSaveImageFile(Image image)
        {
            string filePath = Path.Combine(FileDirPath, GenerateBaseFilename() + ".png");
            try
            {
                SaveImageFile(image, filePath);
                MessageBox.Show("저장 되었습니다.");
                FileDirPath = Path.GetDirectoryName(filePath);
                return true;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("에러 발생 ArgNulls" + e);
            }
            catch (Exception e)
            {
                MessageBox.Show("에러 발생" + e);
            }
            finally
            {
                if (image != null)
                {
                    image.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// 이미지파일을 저장하는 부분만 따로 캡슐화 해둠. 
        /// 만약에 대비하기 위한 부분.
        /// </summary>
        /// <param name="image">저장하려는 이미지 파일</param>
        /// <param name="path">저장하려는 경로. (경로+파일명)</param>
        private void SaveImageFile(Image image, string path)
        {
            try
            {
                image.Save(path, GetImageFormat(path));
                System.Diagnostics.Debug.WriteLine(path);
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                throw e;
            }
        }
        /// <summary>
        /// 이미지 확장자
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ImageFormat GetImageFormat(string path)
        {
            //string ext = _dir_path.Substring(_dir_path.LastIndexOf('.'));
            string ext = Path.GetExtension(path);
            if (ext.Equals(".jpg") || ext.Equals(".jpeg"))
            {
                return ImageFormat.Jpeg;
            }
            else if (ext.Equals(".png"))
            {
                return ImageFormat.Png;
            }
            else if (ext.Equals(".bmp"))
            {
                return ImageFormat.Bmp;
            }
            else
            {
                return ImageFormat.Bmp;
            }
        }


        /// <summary>
        /// 설치 경로를 가져온다.
        /// </summary>
        /// <returns></returns>
        public string GenerateBasePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop); ;

            //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //설치 경로
            //Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Desktop
            //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData
        }

        /// <summary>
        /// 파일명의 기본값을 만들어준다.
        /// </summary>
        /// <returns></returns>
        private string GenerateBaseFilename()
        {
            //return DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff");
            return DateTime.Now.ToString("yyyyMMdd-HH.mm.ss.fff");
        }

        /// <summary>
        /// 자동적으로 파일경로를 생성하는 메서드이다.
        /// 프로그램의 경로에서 시간형식의 이름을 붙인다.
        /// </summary>
        /// <returns></returns>
        private string FileSave_Auto_FilePath()
        {
            return GenerateBasePath() + "\\" + GenerateBaseFilename() + ".jpg";
        }
    }
}
