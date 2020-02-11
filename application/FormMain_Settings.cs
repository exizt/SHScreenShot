using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;

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

            // 콤보박스 바인딩 등
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
            tboxSaveDirSetting.Text = AppConfig.SaveRules.Path;

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
            switch (AppConfig.NameRules.AddsetType)
            {
                case AppConfig.FileNameRules.AddsetTypeCode.TypeA:
                    rbAddsetTypeA.Checked = true;
                    break;
                default:
                    break;
            }

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = true;

            SettingPanelLoad();
        }


        private void btnSettingSave_Click(object sender, EventArgs e)
        {
            // 저장 이미지 형식
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
            AppConfig.SaveRules.Path = tboxSaveDirSetting.Text;

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


        }

        private void btnSettingCancel_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = false;
        }
    }
}