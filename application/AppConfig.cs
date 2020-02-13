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
    internal class AppConfig
    {
        internal FileNameRules NameRules { get; set; }
        internal FileSaveRules SaveRules { get; set; }

        public AppConfig()
        {
            this.NameRules = new FileNameRules();
            this.SaveRules = new FileSaveRules();

            SetDefaultOption();
            Load();
        }

        /// <summary>
        /// 저장된 설정에서 불러옴
        /// </summary>
        public void Load()
        {
            if(AppConfiguration.GetAppConfig(OptionKeys.DefaultPath) != null 
                && AppConfiguration.GetAppConfig(OptionKeys.DefaultPath).Length > 1)
            {
                SaveRules.Path = AppConfiguration.GetAppConfig(OptionKeys.DefaultPath);
            }
            if(AppConfiguration.GetAppConfig(OptionKeys.DefaultExt) != null)
            {
                string s = AppConfiguration.GetAppConfig(OptionKeys.DefaultExt);
                if (Enum.TryParse(s, true, out FileSaveRules.ImageExt val))
                {
                    if (Enum.IsDefined(typeof(FileSaveRules.ImageExt), val))
                    {
                        SaveRules.defaultExt = val;
                    }
                }
            }
            if(AppConfiguration.GetAppConfig(OptionKeys.NamePrefix) != null)
            {
                NameRules.prefix = AppConfiguration.GetAppConfig(OptionKeys.NamePrefix);
            }
            if(AppConfiguration.GetAppConfig(OptionKeys.NameSuffix) != null)
            {
                NameRules.suffix = AppConfiguration.GetAppConfig(OptionKeys.NameSuffix);
            }
            if(AppConfiguration.GetAppConfig(OptionKeys.NameAddsetFormat) != null 
                && AppConfiguration.GetAppConfig(OptionKeys.NameAddsetFormat).Length > 1)
            {
                NameRules.addsetFormat = AppConfiguration.GetAppConfig(OptionKeys.NameAddsetFormat);
            }
            if (AppConfiguration.GetAppConfig(OptionKeys.NameAddsetPosition) != null)
            {
                string s = AppConfiguration.GetAppConfig(OptionKeys.NameAddsetPosition);
                if (Enum.TryParse(s, true, out FileNameRules.AddsetPosCode val))
                {
                    if (Enum.IsDefined(typeof(FileNameRules.AddsetPosCode), val))
                    {
                        NameRules.AddsetPosition = val;
                    }
                }
            }
        }

        /// <summary>
        /// 현재 설정을 저장
        /// </summary>
        public void Save()
        {
            AppConfiguration.SetAppConfig(OptionKeys.DefaultPath, SaveRules.Path);
            AppConfiguration.SetAppConfig(OptionKeys.DefaultExt, SaveRules.defaultExt.ToString());
            AppConfiguration.SetAppConfig(OptionKeys.NamePrefix, NameRules.prefix);
            AppConfiguration.SetAppConfig(OptionKeys.NameSuffix, NameRules.suffix);
            AppConfiguration.SetAppConfig(OptionKeys.NameAddsetFormat, NameRules.addsetFormat);
            AppConfiguration.SetAppConfig(OptionKeys.NameAddsetPosition, NameRules.AddsetPosition.ToString());
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

        public class OptionKeys
        {
            public const string DefaultPath = "DefaultPath";
            public const string DefaultExt = "DefaultExtension";
            public const string NamePrefix = "NamePrefix";
            public const string NameSuffix = "NameSuffix";
            public const string NameAddsetFormat = "NameAddsetFormat";
            public const string NameAddsetPosition = "NameAddsetPosition";
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
