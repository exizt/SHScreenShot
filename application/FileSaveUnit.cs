using System;
using System.Deployment.Application;
using System.Diagnostics;//debug용
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
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
        /// 바로 파일을 저장해버리는 메서드이다.
        /// </summary>
        /// <param name="_bitmap"></param>
        private void FileSave_Auto_Save(Bitmap _bitmap)
        {
            FileSave_Auto_FilePath();//파일경로 생성
            FileSave_Save(FileSave_Auto_FilePath(), _bitmap);//저장하기
        }
        /// <summary>
        /// 저장할 파일 경로를 탐색하는 메서드.
        /// 제대로 잘 선택했을 시에 파일명을 리턴한다.
        /// </summary>
        /// <returns></returns>
        private string FileSave_PathDialog()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "이미지 파일 (*.jpg)|*.jpg|비트맵파일 (*.bmp)|*.bmp|비트맵파일 (*.png)|*.png|모든 파일 (*.*)|*.*";//확장자 선택
            saveFile.Title = "다른 이름으로 저장";//창위에 뜨는 타이틀
            saveFile.FileName = FileSave_Auto_FileName();
            //saveFile.FileName = "zz";

            //showDialog의 리턴값이 OK 일 때
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                return saveFile.FileName;
            }
            return "";
        }



        /// <summary>
        /// 파일저장 메서드.
        /// Bitmap 파일을 저장하는 메서드 이다.
        /// 파일명에서 확장자를 추출해서, 확장자에 맞게 변환하면서 저장한다.
        /// </summary>
        /// <param name="_dir_path">string 파일의 전체 저장경로(확장자포함)</param>
        /// <param name="_bitmap">Image 객체</param>
        private void FileSave_Save(string _dir_path, Bitmap _bitmap)
        {
            if (_dir_path != "")
            {
                if (_bitmap != null)
                {
                    try
                    {
                        _bitmap.Save(_dir_path, ImageExtension(_dir_path));
                    } catch (Exception e)
                    {
                        MessageBox.Show("에러 발생"+e);
                        Debug.WriteLine(e);
                    }
                    MessageBox.Show("저장 되었습니다.");
                }
                else { MessageBox.Show("그림을 캡쳐해주세요."); }
            }
            else { MessageBox.Show("저장경로를 설정해주세요"); }
        }

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
        /// bitmap 을 저장하는 메서드.
        /// 저장할 것인지 다이얼로그 로 물어본후, 각각 PathDialog 메서드와 Save 메서드를 호출한다.
        /// </summary>
        /// <param name="_bitmap"></param>
        private void FileSave_Save(Bitmap _bitmap)
        {
            if (MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string dirPath = FileSave_PathDialog();
                if (dirPath != "")
                {
                    if (_bitmap != null)
                    {
                        FileSave_Save(dirPath, _bitmap);

                    }
                    else { MessageBox.Show("그림을 캡쳐해주세요."); }
                }
                else { MessageBox.Show("저장경로를 설정해주세요"); }
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
