using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 참고 주소 https://msdn.microsoft.com/en-us/library/dd997001.aspx
/// 참고 주소 2 http://oshyn.com/software-development/clickonce-deployment-creating-a-custom-installer
/// 
/// </summary>
namespace CustomClickOnceInstaller
{
    class CustomInstaller
    {
        InPlaceHostingManager iphm = null;
        bool preparedDownload = false;
        Form1 mParentForm;
        string ProductName = null;
        string ShortcutAppId = null;
        string ShortcutFileName = null;
        string ShortcutFolderName = null;

        public CustomInstaller(Form1 _parentForm)
        {
            mParentForm = _parentForm;
        }

        /// <summary>
        /// Installs a ClickOnce application.
        /// 원본 소스에서는 InstallApplication 메서드 입니다.
        /// </summary>
        /// <param name="deployManifestUriStr"></param>
        public void PrepareApplication(string deployManifestUriStr)
        {
            initializeForm();

            try
            {
                var deploymentUri = new Uri(deployManifestUriStr);
                iphm = new InPlaceHostingManager(deploymentUri, false);
            }
            catch (UriFormatException uriEx)
            {
                MessageBox.Show("Cannot install the application: " + "The deployment manifest URL supplied is not a valid URL. " + "Error: " + uriEx.Message);
                return;
            }
            catch (PlatformNotSupportedException platformEx)
            {
                MessageBox.Show("Cannot install the application: " + "This program requires Windows XP or higher. " + "Error: " + platformEx.Message);
                return;
            }
            catch (ArgumentException argumentEx)
            {
                MessageBox.Show("Cannot install the application: " + "The deployment manifest URL supplied is not a valid URL. " + "Error: " + argumentEx.Message);
                return;
            }

            iphm.GetManifestCompleted += new EventHandler<GetManifestCompletedEventArgs>(iphm_GetManifestCompleted); ;
            iphm.GetManifestAsync();
        }
        /// <summary>
        /// 초기 화면 셋팅
        /// </summary>
        public void initializeForm()
        {
            //초기 라벨 지정
            mParentForm.label1.Text = "정보를 조회중입니다...";

            //초기 진행바 지정
            mParentForm.progressBar1.Step = 10;
            mParentForm.progressBar1.Style = ProgressBarStyle.Marquee;
            mParentForm.progressBar1.MarqueeAnimationSpeed = 30;

            //초기 버튼 설정
            mParentForm.button1.Visible = false;
        }

        /// <summary>
        /// Occurs when the deployment manifest has been downloaded to the local computer.
        /// </summary>
        void iphm_GetManifestCompleted(object sender, GetManifestCompletedEventArgs e)
        {
            // Check for an error.
            if (e.Error != null)
            {
                // Cancel download and install.
                MessageBox.Show("Could not download manifest. Error: " + e.Error.Message);
                prepareFailure();
                return;
            }
            // Verify this application can be installed.
            try
            {
                // The true parameter allows InPlaceHostingManager to grant the permissions requested in the applicaiton manifest.
                iphm.AssertApplicationRequirements(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while verifying the application. " + "Error: " + ex.Message);
                prepareFailure();
                return;
            }

            // Use the information from GetManifestCompleted() to confirm 
            // that the user wants to proceed.
            ProductName = e.ProductName;
            string appInfo = "Application Name: " + e.ProductName;
            
            appInfo += "\nVersion: " + e.Version;
            //appInfo += "\nSupport/Help Requests: " + (e.SupportUri != null ?
            //    e.SupportUri.ToString() : "N/A");
            //appInfo += "\n\nConfirmed that this application can run with its requested permissions.";
            // if (isFullTrust)
            // appInfo += "\n\nThis application requires full trust in order to run.";
            //appInfo += "\n\nProceed with installation?";

            mParentForm.label1.Text = appInfo;

            // Check if application already installed
            if (e.ActivationContext.Form == ActivationContext.ContextForm.StoreBounded)
            {
                mParentForm.label1.Text += "\n\n이미 설치되어 있습니다.";
                prepareFailure();
                return;
            }

            // Download the deployment manifest. 
            iphm.DownloadProgressChanged += new EventHandler<DownloadProgressChangedEventArgs>(iphm_DownloadProgressChanged);
            iphm.DownloadApplicationCompleted += new EventHandler<DownloadApplicationCompletedEventArgs>(iphm_DownloadApplicationCompleted);


            // 화면에 처리. 데이터 가져오기 완료.
            mParentForm.progressBar1.Style = ProgressBarStyle.Continuous;
            mParentForm.progressBar1.Value = 0;
            mParentForm.progressBar1.Step = 1;

            mParentForm.button1.Visible = true;


            //준비 완료
            preparedDownload = true;
        }
        /// <summary>
        /// Manifest 확보에 실패하거나, 준비과정에서 실패한 경우.
        /// </summary>
        void prepareFailure()
        {
            mParentForm.progressBar1.Style = ProgressBarStyle.Continuous;
            mParentForm.progressBar1.Value = 0;
            mParentForm.progressBar1.Step = 1;
            mParentForm.button1.Visible = false;
        }
        /// <summary>
        /// 다운로드 시작 및 설치작업
        /// </summary>
        public void InstallApplication()
        {
            if(!preparedDownload)
            {
                MessageBox.Show("다운로드가 준비되지 않았습니다.");
                return;
            }

            DialogResult dr = MessageBox.Show("설치하시겠습니까?", "Confirm Application Install", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                // Usually this shouldn't throw an exception unless AssertApplicationRequirements() failed, 
                // or you did not call that method before calling this one.
                iphm.DownloadApplicationAsync();
            }
            catch (Exception downloadEx)
            {
                MessageBox.Show("Cannot initiate download of application. Error: " + downloadEx.Message);
                return;
            }
        }

        /// <summary>
        /// Occurs when the application has finished downloading to the local computer.
        /// </summary>
        void iphm_DownloadApplicationCompleted(object sender, DownloadApplicationCompletedEventArgs e)
        {
            // Check for an error.
            if (e.Error != null)
            {
                // Cancel download and install.
                MessageBox.Show("Could not download and install application. Error: " + e.Error.Message);
                return;
            }

            ShortcutAppId = e.ShortcutAppId;

            mParentForm.label1.Text = "설치가 완료되었습니다.";
            mParentForm.button1.Visible = false;

            //프로세스 실행
            processRun();

            //설치관리자 종료
            Application.Exit();
        }

        void processRun()
        {
            //mParentForm.label1.Text += "process";
            //only run if deployed
            //clickonce 의 경우에만, currentdeployment 값을 가진다고 한다.
            //clickOnce 여부는 isNetworkDeployed 값으로 판단한다.
            try
            {
                //Uninstall 레지스트리 에서 폴더명과 파일명을 검색한다.
                Microsoft.Win32.RegistryKey myUninstallKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                for (int i = 0; i < mySubKeyNames.Length; i++)
                {
                    Microsoft.Win32.RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                    object myValue = myKey.GetValue("ShortcutAppId");
                    if (myValue != null)
                    {
                        if (myValue.ToString() == ShortcutAppId)
                        {
                            ShortcutFileName = myKey.GetValue("ShortcutFileName").ToString();
                            ShortcutFolderName = myKey.GetValue("ShortcutFolderName").ToString();
                            break;
                        }
                    }
                }

                //C:\Users\Administrator\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\E2X Software
                string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                startupPath = Path.Combine(startupPath, ShortcutFolderName, ShortcutFileName) + ".appref-ms";
                if (File.Exists(startupPath))
                {
                    Process.Start(startupPath);
                }
                else
                {
                    //MessageBox.Show("Application installed!\nYou may now run it from the Start menu.");
                    MessageBox.Show("설치가 완료되었습니다. \n 시작메뉴에서 실행시켜주세요.");
                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Occurs when there is a change in the status of an application or manifest download.
        /// </summary>
        void iphm_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // you can show percentage of task completed using e.ProgressPercentage
            // Show % of task completed 
            ((Form1)Application.OpenForms[0]).progressBar1.Value = e.ProgressPercentage;
            
            //mParentForm.progressBar1.Value= e.ProgressPercentage;
        }
    }
}
