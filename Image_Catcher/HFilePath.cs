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
        //프로그램 설치 디렉토리 위치 가져오는 메서드
        public static string Auto_Dir()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
        //시간을 가져오는 메서드. (중복되지 않는 파일명 만들때 사용)
        public static string Auto_FileName()
        {
            return DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss.fff");
        }
        //자동적으로 생성하는 파일저장위치.
        public static string Auto_FilePath()
        {
            return Auto_Dir() + "\\" + Auto_FileName() + ".jpg";
        }
        public static void Auto_Save(System.Drawing.Image _image)
        {
            HFilePath.Auto_FilePath();//파일경로 생성
            Save(HFilePath.Auto_FilePath(), _image);//저장하기

        }
        //=============================================================


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
        /// SH. 메서드. 파일 저장 메서드
        /// </summary>
        /// <param name="dir_path">string 파일의 전체 저장경로(확장자포함)</param>
        /// <param name="_image">Image 객체</param>
        public static void Save(string dir_path, System.Drawing.Image _image)
        {
            if (dir_path != "")
            {
                if (_image != null)
                {
                    _image.Save(dir_path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Windows.Forms.MessageBox.Show("저장 되었습니다.");
                }
                else { System.Windows.Forms.MessageBox.Show("그림을 캡쳐해주세요."); }
            }
            else { System.Windows.Forms.MessageBox.Show("저장경로를 설정해주세요"); }
        }

        /// <summary>
        /// SH. 메서드. 파일 저장 메서드
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


        /// <summary>
        /// 기본 타입은 jpeg
        /// </summary>
        /// <param name="_image"></param>
        public void Save(System.Drawing.Image _image)
        {
            if (System.Windows.Forms.MessageBox.Show("저장하시겠습니까?", "스크린샷 파일저장",
                System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string dir_path = HFilePath.PathDialog();
                if (dir_path != "")
                {
                    if (_image != null)
                    {
                        _image.Save(dir_path, System.Drawing.Imaging.ImageFormat.Jpeg);
                        System.Windows.Forms.MessageBox.Show("저장 되었습니다.");

                    }
                    else { System.Windows.Forms.MessageBox.Show("그림을 캡쳐해주세요."); }
                }
                else { System.Windows.Forms.MessageBox.Show("저장경로를 설정해주세요"); }
            }
        }

    }
}
