using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Image_Capture
{
    class HFilePath
    {

        //=============================================================
        /// <summary>
        /// 현재 프로그램의 경로를 가져온다.
        /// </summary>
        /// <returns></returns>
        public static string Auto_Dir()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        /// <summary>
        /// 현재 시간을 가져온다.
        /// </summary>
        /// <returns></returns>
        public static string Auto_FileName()
        {
            //return DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff");
            return DateTime.Now.ToString("yyyyMMdd-HH.mm.ss.fff");
        }
        /// <summary>
        /// 자동적으로 파일경로를 생성하는 메서드이다.
        /// 프로그램의 경로에서 시간형식의 이름을 붙인다.
        /// </summary>
        /// <returns></returns>
        public static string Auto_FilePath()
        {
            return Auto_Dir() + "\\" + Auto_FileName() + ".jpg";
        }
        /// <summary>
        /// 바로 파일을 저장해버리는 메서드이다.
        /// </summary>
        /// <param name="_bitmap"></param>
        public static void Auto_Save(System.Drawing.Bitmap _bitmap)
        {
            HFilePath.Auto_FilePath();//파일경로 생성
            Save(HFilePath.Auto_FilePath(), _bitmap);//저장하기

        }
        //=============================================================


        /// <summary>
        /// bitmap 을 저장하는 메서드.
        /// 저장할 것인지 다이얼로그 로 물어본후, 각각 PathDialog 메서드와 Save 메서드를 호출한다.
        /// </summary>
        /// <param name="_bitmap"></param>
        public static void Save(Bitmap _bitmap)
        {
            if (System.Windows.Forms.MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string dirPath = HFilePath.PathDialog();
                if (dirPath != "")
                {
                    if (_bitmap != null)
                    {
                        Save(dirPath, _bitmap);

                    }
                    else { System.Windows.Forms.MessageBox.Show("그림을 캡쳐해주세요."); }
                }
                else { System.Windows.Forms.MessageBox.Show("저장경로를 설정해주세요"); }
            }
        }


        /// <summary>
        /// 저장할 파일 경로를 탐색하는 메서드.
        /// 제대로 잘 선택했을 시에 파일명을 리턴한다.
        /// </summary>
        /// <returns></returns>
        public static string PathDialog()
        {
            System.Windows.Forms.SaveFileDialog _saveFD = new System.Windows.Forms.SaveFileDialog();
            _saveFD.Filter = "이미지 파일 (*.jpg)|*.jpg|비트맵파일 (*.bmp)|*.bmp|비트맵파일 (*.png)|*.png|모든 파일 (*.*)|*.*";//확장자 선택
            _saveFD.Title = "다른 이름으로 저장";//창위에 뜨는 타이틀
            _saveFD.FileName = Auto_FileName();

            //showDialog의 리턴값이 OK 일 때
            if (_saveFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return _saveFD.FileName;
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
        public static void Save(string _dir_path, Bitmap _bitmap)
        {
            if (_dir_path != "")
            {
                if (_bitmap != null)
                {
                    //string ext = _dir_path.Substring(_dir_path.LastIndexOf('.'));
                    
                    string ext = System.IO.Path.GetExtension(_dir_path);
                    System.Diagnostics.Debug.WriteLine(ext);
                    if (ext.Equals(".jpg") || ext.Equals(".jpeg"))
                    {
                        _bitmap.Save(_dir_path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    } else if(ext.Equals(".png"))
                    {
                        _bitmap.Save(_dir_path, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (ext.Equals(".bmp"))
                    {
                        _bitmap.Save(_dir_path, System.Drawing.Imaging.ImageFormat.Bmp);
                    } else
                    {
                        _bitmap.Save(_dir_path, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    System.Windows.Forms.MessageBox.Show("저장 되었습니다.");
                }
                else { System.Windows.Forms.MessageBox.Show("그림을 캡쳐해주세요."); }
            }
            else { System.Windows.Forms.MessageBox.Show("저장경로를 설정해주세요"); }
        }


    }
}
