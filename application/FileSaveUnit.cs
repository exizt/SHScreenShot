using System;
using System.Diagnostics;//debug용
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Reflection;

/// <summary>
/// 전체 화면 스크린 캡쳐 기능 을 모아놓음
/// </summary>
namespace Image_Capture
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 결과 이미지 저장. 파일 다이얼로그.
        /// </summary>
        private void SaveFile_Dialog()
        {
            string filepath = "";
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "이미지 파일 (*.jpg)|*.jpg|비트맵파일 (*.bmp)|*.bmp|비트맵파일 (*.png)|*.png|모든 파일 (*.*)|*.*";//확장자 선택
                fileDialog.Title = "다른 이름으로 저장";//창위에 뜨는 타이틀
                fileDialog.FileName = FileSave_Auto_FileName();
                //showDialog의 리턴값이 OK 일 때
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filepath = fileDialog.FileName;
                }
            }

            if (filepath != "")
            {
                if (resultImage != null)
                {
                    try
                    {
                        resultImage.Save(filepath, ImageExtension(filepath));
                        strFilePath = filepath;
                        MessageBox.Show("저장 되었습니다.");
                    }
                    catch (ArgumentNullException e)
                    {
                        MessageBox.Show("에러 발생 ArgNulls" + e);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("에러 발생" + e);
                        Debug.WriteLine(e);
                    }
                    finally
                    {
                        if (resultImage != null)
                        {
                            resultImage.Dispose();
                        }
                    }
                }
                else { MessageBox.Show("그림을 캡쳐해주세요."); }
            }
            else { MessageBox.Show("저장경로를 설정해주세요"); }
        }

        /// <summary>
        /// 이미지 확장자
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ImageFormat ImageExtension(string path)
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
        private string FileSave_Auto_Dir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// 현재 시간을 가져온다.
        /// </summary>
        /// <returns></returns>
        private string FileSave_Auto_FileName()
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
            return FileSave_Auto_Dir() + "\\" + FileSave_Auto_FileName() + ".jpg";
        }
    }
}
