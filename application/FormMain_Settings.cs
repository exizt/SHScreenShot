using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Collections.Generic;

namespace Image_Capture
{
    public partial class FormMain : Form
    {
        private bool isSettingsPanelInit = false;

        /// <summary>
        /// 한번만 호출된다.
        /// </summary>
        private void SettingPanelInit()
        {
            isSettingsPanelInit = true;

            // 콤보박스 바인딩 (text, value)
            List<CustomComboboxItem> list = new List<CustomComboboxItem>();
            list.Add(new CustomComboboxItem("연월일시분초밀리초", "yyyyMMddHHmmssfff"));
            list.Add(new CustomComboboxItem("연월일.시분초밀리초", "yyyyMMdd.HHmmssfff"));
            list.Add(new CustomComboboxItem("연월일시분초.밀리초", "yyyyMMddHHmmss.fff"));
            list.Add(new CustomComboboxItem("연월일.시분초.밀리초", "yyyyMMdd.HHmmss.fff"));
            list.Add(new CustomComboboxItem("연월일.시분초", "yyyyMMdd.HHmmss"));
            list.Add(new CustomComboboxItem("연-월-일.시분초밀리초", "yyyy-MM-dd.HHmmssfff"));
            list.Add(new CustomComboboxItem("연월일-시분초밀리초", "yyyyMMdd-HHmmssfff"));

            //cboxAddsetTypes.
            cboxAddsetTypes.DisplayMember = "Text";
            cboxAddsetTypes.ValueMember = "Value";
            cboxAddsetTypes.DataSource = list;

            
        }

        private void SettingPanelLoad()
        {
            if (!isSettingsPanelInit)
            {
                SettingPanelInit();
            }
            // 저장 이미지 형식
            switch (AppConfig.SaveRules.defaultExt)
            {
                case AppConfig.FileSaveRules.ImageExt.Png:
                    rbImageExtPng.Checked = true;
                    rbImageExtJpg.Checked = false;
                    rbImageExtBmp.Checked = false;
                    rbImageExtGif.Checked = false;
                    break;
                case AppConfig.FileSaveRules.ImageExt.Jpg:
                    rbImageExtPng.Checked = false;
                    rbImageExtJpg.Checked = true;
                    rbImageExtBmp.Checked = false;
                    rbImageExtGif.Checked = false;
                    break;
                case AppConfig.FileSaveRules.ImageExt.Bmp:
                    rbImageExtPng.Checked = false;
                    rbImageExtJpg.Checked = false;
                    rbImageExtBmp.Checked = true;
                    rbImageExtGif.Checked = false;
                    break;
                case AppConfig.FileSaveRules.ImageExt.Gif:
                    rbImageExtPng.Checked = false;
                    rbImageExtJpg.Checked = false;
                    rbImageExtBmp.Checked = false;
                    rbImageExtGif.Checked = true;
                    break;
                default:
                    break;
            }

            // 파일 저장 경로
            tboxDefaultPathOption.Text = AppConfig.SaveRules.Path;

            // 파일명 앞문자열, 뒷문자열
            tboxPrefix.Text = AppConfig.NameRules.prefix;
            tboxSuffix.Text = AppConfig.NameRules.suffix;

            // 추가 문자셋 위치
            switch (AppConfig.NameRules.AddsetPosition)
            {
                case AppConfig.FileNameRules.AddsetPosCode.Front:
                    rbAddsetPosFront.Checked = true;
                    rbAddsetPosMiddle.Checked = false;
                    rbAddsetPosEnd.Checked = false;
                    break;
                case AppConfig.FileNameRules.AddsetPosCode.Middle:
                    rbAddsetPosFront.Checked = false;
                    rbAddsetPosMiddle.Checked = true;
                    rbAddsetPosEnd.Checked = false;
                    break;
                case AppConfig.FileNameRules.AddsetPosCode.End:
                    rbAddsetPosFront.Checked = false;
                    rbAddsetPosMiddle.Checked = false;
                    rbAddsetPosEnd.Checked = true;
                    break;
                default:
                    break;
            }

            // 추가 문자셋 유형
            cboxAddsetTypes.SelectedValue = AppConfig.NameRules.addsetFormat;

        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = true;

            SettingPanelLoad();
        }


        private void BtnSettingSave_Click(object sender, EventArgs e)
        {
            Debug("btnSettingSave_Click");

            // 이미지 디폴트 확장자
            if (rbImageExtPng.Checked)
            {
                AppConfig.SaveRules.defaultExt = AppConfig.FileSaveRules.ImageExt.Png;
            } else if(rbImageExtJpg.Checked)
            {
                AppConfig.SaveRules.defaultExt = AppConfig.FileSaveRules.ImageExt.Jpg;
            }
            else if (rbImageExtBmp.Checked)
            {
                AppConfig.SaveRules.defaultExt = AppConfig.FileSaveRules.ImageExt.Bmp;
            }
            else if (rbImageExtGif.Checked)
            {
                AppConfig.SaveRules.defaultExt = AppConfig.FileSaveRules.ImageExt.Gif;
            }

            // 파일 저장 경로
            AppConfig.SaveRules.Path = tboxDefaultPathOption.Text;

            // 파일명 앞문자열, 뒷문자열
            AppConfig.NameRules.prefix = tboxPrefix.Text;
            AppConfig.NameRules.suffix = tboxSuffix.Text;

            // 추가 문자셋 위치
            if (rbAddsetPosFront.Checked)
            {
                AppConfig.NameRules.AddsetPosition = AppConfig.FileNameRules.AddsetPosCode.Front;
            }
            else if (rbAddsetPosMiddle.Checked)
            {
                AppConfig.NameRules.AddsetPosition = AppConfig.FileNameRules.AddsetPosCode.Middle;
            }
            else if (rbAddsetPosEnd.Checked)
            {
                AppConfig.NameRules.AddsetPosition = AppConfig.FileNameRules.AddsetPosCode.End;
            }

            AppConfig.NameRules.addsetFormat = cboxAddsetTypes.SelectedValue as string;

            AppConfig.Save();
            Debug("[btnSettingSave_Click]", AppConfig);

            MessageBox.Show("설정을 저장하였습니다.");
        }

        private void btnSettingCancel_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
            MainPanelLoad();
        }
        
        private void btnChangeDefaultPath_Click(object sender, EventArgs e)
        {
            string path = FolderBrowser();
            if (path.Length > 1)
            {
                tboxDefaultPathOption.Text = path;
            }
        }

        public class CustomComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public CustomComboboxItem()
            {

            }

            public CustomComboboxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}