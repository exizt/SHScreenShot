using System;
using System.Deployment.Application;
using System.Diagnostics;//debug용
using System.IO;
using System.Windows.Forms;

namespace Image_Capture
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            SetAddRemoveProgramsIcon();
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
        }

        private void tester()
        {
            if (ApplicationDeployment.IsNetworkDeployed
                 && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                string result = "";
                result += "ActivationUri[" + ApplicationDeployment.CurrentDeployment.ActivationUri + "]";
                result += "CurrentVersion[" + ApplicationDeployment.CurrentDeployment.CurrentVersion + "]";
                result += "UpdatedVersion[" + ApplicationDeployment.CurrentDeployment.UpdatedVersion + "]";
                result += "UpdateLocation[" + ApplicationDeployment.CurrentDeployment.UpdateLocation + "]";


                MessageBox.Show(result);
            }
        }
        //=============================================================
        //이벤트 메서드들.
        /// <summary>
        /// 로드 되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //debug("FormMain Load 이벤트 발생!");
            //debug("imgPreview.Width : " + imgPreview.Width+","+imgPreview.Height);
            //debug("imgPreview.Size.Width" + imgPreview.Size.Width + "," + imgPreview.Size.Height);

            //커서가 안 보이는 환경일 때, 커서를 복귀.
            Cursor current = Cursor.Current;
            if (current == null)
            {
                Cursor.Show();
            }

        }

 
        /// <summary>
        /// 색상 추출 기능. 이벤트 메서드.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpoidColor_Click(object sender, EventArgs e)
        {
            //1. 커서를 숨긴다.
            //Cursor.Hide();

            //2. 커서의 좌표를 통하여 색상을 추출한다.
            FormColorPickup nForm = new FormColorPickup(this);
            nForm.Show();
        }

        //close of 이벤트 메서드들
        //=============================================================

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg)
        {
            Debug.WriteLine(msg);
        }




        private void MainForm_activated(object sender, EventArgs e)
        {
            //debug("[]MainForm_activated");
            //Cursor.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.showForm();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.Visible = false;
            //this.hide(sender, e);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.showForm();
        }

        private void hide(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.hideForm();
        }
        /// <summary>
        /// 
        /// </summary>
        private void showForm()
        {
            this.Visible = true;//활성화
            this.Opacity = 100;
            this.WindowState = FormWindowState.Normal;//폼의 상태를 일반 상태로 되돌림.
        }
        /// <summary>
        /// 
        /// </summary>
        private void hideForm()
        {
            this.Opacity = 0;
            this.Visible = false;
            //this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            //최소화 버튼 클릭시 이벤트
            if (this.WindowState == FormWindowState.Minimized)
            {
                //MessageBox.Show("창이 최소화되었습니다.");
                //창을 숨김 처리 한다.
                this.hideForm();
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                //MessageBox.Show("창이 최대화되었습니다.");
            }
        }
        /// <summary>
        /// 트레이 -> 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// ClickOnce 설치 의 경우, 제어판-프로그램추가/삭제 에서 아이콘 표시가 안 나온다. 그 부분을 보정하는 소스.
        /// </summary>
        private static void SetAddRemoveProgramsIcon()
        {
            //only run if deployed
            //clickonce 의 경우에만, currentdeployment 값을 가진다고 한다.
            //clickOnce 여부는 isNetworkDeployed 값으로 판단한다.
            if (ApplicationDeployment.IsNetworkDeployed
                 && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    //the icon is included in this program
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "MainIcon.ico");

                    if (!File.Exists(iconSourcePath))
                        return;

                    Microsoft.Win32.RegistryKey myUninstallKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        Microsoft.Win32.RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("UrlUpdateInfo");
                        if(myValue != null)
                        {
                            string updateinfo = myValue.ToString();
                            string updateLocation = ApplicationDeployment.CurrentDeployment.UpdateLocation.ToString();
                            if (updateinfo==updateLocation)
                            {
                                myKey.SetValue("DisplayIcon", iconSourcePath);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
