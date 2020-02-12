using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
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
        /// <summary>
        /// 로그 디버깅 옵션.
        /// </summary>
        public bool isDebug = true;

        /// <summary>
        /// 최근 저장한 경로
        /// </summary>
        public string RecentSavePath { get; set; }

        public string DefaultExt { get; set; }

        public string ImageDefaultExtString { get; set; }

        internal AppConfig AppConfig { get; set; }

        public ScreenImageFileHandler()
        {
            RecentSavePath = GenerateBasePath();
        }

        public ScreenImageFileHandler(string path)
        {
            RecentSavePath = path;
        }
        public ScreenImageFileHandler(AppConfig config)
        {
            AppConfig = config;
            ReloadAppConfig();
        }

        private void ReloadAppConfig()
        {
            RecentSavePath = AppConfig.SaveRules.Path;
            ImageDefaultExtString = AppConfig.SaveRules.ImageExtToString(AppConfig.SaveRules.defaultExt);
        }

        /// <summary>
        /// 결과 이미지 저장. 파일 다이얼로그.
        /// </summary>
        public bool DoSaveFileDialog(Image image)
        {
            ReloadAppConfig();
            string filePath = "";
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "PNG 이미지 (*.png)|*.png|JPG 이미지 (*.jpg)|*.jpg|BMP 이미지 (*.bmp)|*.bmp|모든 파일 (*.*)|*.*";//확장자 선택
                fileDialog.Title = "스크린샷 이미지 저장";//창위에 뜨는 타이틀
                fileDialog.FileName = GenerateBaseFilename();
                fileDialog.DefaultExt = ImageDefaultExtString;
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
            
            if (filePath.Trim().Length > 1)
            {
                try
                {
                    //image.Save(filePath, GetImageFormat(filePath));
                    SaveImageFile(image, filePath);
                    //MessageBox.Show("저장 되었습니다.");
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
            else
            { 
                // 경로를 잘못 지정한 경우
                MessageBox.Show("저장경로를 설정해주세요");
            }
            return false;
        }

        /// <summary>
        /// 자동 세이브 구현
        /// </summary>
        /// <param name="image"></param>
        public bool DoAutoSaveImageFile(Image image)
        {
            ReloadAppConfig();
            //string filePath = Path.Combine(RecentSavePath, GenerateBaseFilename() + "." + AppConfig.SaveRules.ImageExtToString(AppConfig.SaveRules.defaultExt));
            string filePath = Path.Combine(RecentSavePath, GenerateBaseFilename() + "." + ImageDefaultExtString);
            try
            {
                SaveImageFile(image, filePath);
                //MessageBox.Show("저장 되었습니다.");
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
            return false;
        }

        /// <summary>
        /// 이미지파일을 저장하는 부분만 따로 캡슐화 해둠. 
        /// 만약에 대비하기 위한 부분.
        /// </summary>
        /// <param name="image">저장하려는 이미지 파일</param>
        /// <param name="path">저장하려는 경로. (경로+파일명)</param>
        private void SaveImageFile(Image image, string filePath)
        {
            if (image != null)
            {
                try
                {
                    Debug("[SaveImageFile]", filePath);
                    image.Save(filePath, GetImageFormat(filePath));
                    RecentSavePath = Path.GetDirectoryName(filePath);
                    MessageBox.Show("저장 되었습니다.");
                }
                catch (ArgumentNullException e)
                {
                    Debug("[SaveImageFile][ArgumentNullException]", e);
                    //MessageBox.Show("에러 발생 ArgNulls" + e);
                    //throw e;
                }
                catch (Exception e)
                {
                    Debug("[SaveImageFile][Exception]", e);
                    //MessageBox.Show("에러 발생" + e);
                    //throw e;
                }
                finally
                {
                    if (image != null)
                    {
                        image.Dispose();
                    }
                }
            }
            else { MessageBox.Show("이미지 캡쳐해주세요."); }
        }

        /// <summary>
        /// 이미지 확장자
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ImageFormat GetImageFormat(string path)
        {
            //string ext = _dir_path.Substring(_dir_path.LastIndexOf('.'));
            Debug("[GetImageFormat] path", path);
            string ext = Path.GetExtension(path).ToLower();
            switch (ext)
            {
                case ".jpeg":
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".png":
                    return ImageFormat.Png;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".gif":
                    return ImageFormat.Gif;
                default:
                    return ImageFormat.Png;
            }
        }


        /// <summary>
        /// 설치 경로를 가져온다.
        /// </summary>
        /// <returns></returns>
        public string GenerateBasePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg">Message</param>
        private void Debug(string msg)
        {
            if (isDebug) System.Diagnostics.Debug.WriteLine($"[ScreenImageFileHandler] {msg}");
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg">Message</param>
#pragma warning disable IDE0051 // 사용되지 않는 private 멤버 제거
        private void Debug(string msg, string msg2)
#pragma warning restore IDE0051 // 사용되지 않는 private 멤버 제거
        {
            if (isDebug)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(msg);
                sb.Append(msg2);
                Debug(sb.ToString());
                sb.Clear();
            }
        }
        private void Debug(string msg, Object obj)
        {
            if (isDebug)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(msg);
                sb.Append(obj.ToString());
                Debug(sb.ToString());
                sb.Clear();
            }
        }
    }
}
