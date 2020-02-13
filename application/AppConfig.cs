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

        /// <summary>
        /// 저장된 설정에서 불러옴
        /// </summary>
        public void Load()
        {
            SaveRules.Path = AppConfiguration.GetAppConfig("defaultPath");
            SaveRules.defaultExt = (FileSaveRules.ImageExt) Int32.Parse(AppConfiguration.GetAppConfig("defaultExtension"));
            NameRules.prefix = AppConfiguration.GetAppConfig("NamePrefix");
            NameRules.suffix = AppConfiguration.GetAppConfig("NameSuffix");
            NameRules.addsetFormat = AppConfiguration.GetAppConfig("NameAddsetFormat");
            NameRules.AddsetPosition = (FileNameRules.AddsetPosCode) Int32.Parse(AppConfiguration.GetAppConfig("NameAddsetPosition"));
        }

        /// <summary>
        /// 현재 설정을 저장
        /// </summary>
        public void Save()
        {
            AppConfiguration.SetAppConfig("defaultPath", SaveRules.Path);
            AppConfiguration.SetAppConfig("defaultExtension", SaveRules.defaultExt.ToString());
            AppConfiguration.SetAppConfig("NamePrefix", NameRules.prefix);
            AppConfiguration.SetAppConfig("NameSuffix", NameRules.suffix);
            AppConfiguration.SetAppConfig("NameAddsetFormat", NameRules.addsetFormat);
            AppConfiguration.SetAppConfig("NameAddsetPosition", NameRules.AddsetPosition.ToString());
        }

        public void SetDefaultOption()
        {
            // 저장 확장자
            SaveRules.defaultExt = FileSaveRules.ImageExt.Png;

            // 저장 경로
            SaveRules.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // 파일명 룰
            NameRules.prefix = "스크린샷.";
            NameRules.suffix = "";
            NameRules.AddsetPosition = FileNameRules.AddsetPosCode.End;
            NameRules.addsetFormat = "yyyyMMddHHmmss.fff";

        }

        public override string ToString()
        {
            return $"NameRules: {NameRules.ToString()}, SaveRules: {SaveRules.ToString()}";
        }


        public class FileNameRules
        {
            public string prefix;
            public string suffix;
            public string addsetFormat;
            public AddsetPosCode AddsetPosition;
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
