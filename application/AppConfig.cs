using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Capture
{
    /// <summary>
    /// 앱 환경설정을 다루기 위한 클래스 (내가 만듦)
    /// </summary>
    class AppConfig
    {
        internal FileNameRules NameRules { get; set; }
        internal FileSaveRules SaveRules { get; set; }

        public AppConfig()
        {
            this.NameRules = new FileNameRules();
            this.SaveRules = new FileSaveRules();

            SetDefaultOption();
        }

        public void Load()
        {
        }

        public void SetDefaultOption()
        {
            // 파일명 룰
            NameRules.prefix = "sample";
            NameRules.suffix = "suffix";
            NameRules.AddsetType = FileNameRules.AddsetTypeCode.TypeA;
            NameRules.AddsetPosition = FileNameRules.AddsetPosCode.End;

            // 저장 확장자
            SaveRules.defaultExt = FileSaveRules.ImageExt.Png;

            // 저장 경로
            SaveRules.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public override string ToString()
        {
            return $"NameRules: {NameRules.ToString()}, SaveRules: {SaveRules.ToString()}";
        }


        public class FileNameRules
        {
            public string prefix;
            public string suffix;
            public AddsetTypeCode AddsetType;
            public AddsetPosCode AddsetPosition;
            public enum AddsetTypeCode
            {
                TypeA
            }
            public enum AddsetPosCode
            {
                Front, Middle, End
            }
            public override string ToString()
            {
                return $"prefix: {prefix}, suffix: {suffix}";
            }
        }

        public class FileSaveRules
        {
            public string Path;
            public ImageExt defaultExt;

            public enum ImageExt
            {
                Png, Jpg, Bmp, Gif
            }

            public string ImageExtToString(ImageExt ext)
            {
                switch (ext)
                {
                    case ImageExt.Png:
                        return "png";
                    case ImageExt.Jpg:
                        return "jpg";
                    case ImageExt.Bmp:
                        return "bmp";
                    case ImageExt.Gif:
                        return "gif";
                    default:
                        return "";
                }
            }

            public override string ToString()
            {
                return $"Path: {Path}, DefaultImageExt: {defaultExt}";
            }
        }
    }
}
