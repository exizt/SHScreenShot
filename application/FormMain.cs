using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SHColorPicker
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 로그 디버깅 옵션.
        /// formColorPickup 도 영향을 받는다.
        /// </summary>
        public bool isDebug = false;

        /// <summary>
        /// 생성자 메서드
        /// </summary>
        public FormMain()
        {
            SetAddRemoveProgramsIcon();
            InitializeComponent();//컴포넌트 초기화 메서드(기본적으로 들어감)
            notifyIcon1.Text = "SH Color Picker";
        }

        /// <summary>
        /// [이벤트] 로드 되면서 발생되는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            //커서가 안 보이는 환경일 때, 커서를 복귀.
            Cursor current = Cursor.Current;
            if (current == null)
            {
                Cursor.Show();
            }

        }

        /// <summary>
        /// [이벤트] '색상 추출' 버튼 클릭시 발생 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpoidColor_Click(object sender, EventArgs e)
        {
            //1. 커서를 숨긴다.
            //Cursor.Hide();

            //2. 커서의 좌표를 통하여 색상을 추출한다.
            FormColorPickup form = new FormColorPickup(this);
            form.ShowDialog();

            /*
            using (FormColorPickup form = new FormColorPickup(this))
            {
                form.Show();
            }
            */
            
        }

        /// <summary>
        /// [이벤트] 팔레트 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Color color = getColor_fromColorDialog();
            generateView_fromColor(color);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeR_KeyDown(object sender, KeyEventArgs e)
        {
            changeColorRGBText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeG_KeyDown(object sender, KeyEventArgs e)
        {
            changeColorRGBText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeB_KeyDown(object sender, KeyEventArgs e)
        {
            changeColorRGBText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int code = Int32.Parse(txtColorCodeR.Text);
                if (code > 255) code = 255;
                if (code < 0) code = 0;

                txtColorCodeR.Text = code.ToString();
            }
            catch (Exception exc)
            {
                //colorR = 0;
                txtColorCodeR.Text = "0";
                debug("Exception : ", exc.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int code = Int32.Parse(txtColorCodeG.Text);
                if (code > 255) code = 255;
                if (code < 0) code = 0;

                txtColorCodeG.Text = code.ToString();
            }
            catch (Exception exc)
            {
                //colorR = 0;
                txtColorCodeG.Text = "0";
                debug("Exception : ", exc.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int code = Int32.Parse(txtColorCodeB.Text);
                if (code > 255) code = 255;
                if (code < 0) code = 0;

                txtColorCodeB.Text = code.ToString();
            }
            catch (Exception exc)
            {
                //colorR = 0;
                txtColorCodeB.Text = "0";
                debug("Exception : ", exc.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Color getColor_fromColorDialog()
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    return colorDialog1.Color;
                }
                else
                {
                    return Color.Black;
                }
            } catch (Exception  exc)
            {
                debug("Exception : ", exc.ToString());
                return Color.Black;
            }
        }

        /// <summary>
        /// [이벤트] 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.showForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.showForm();
        }


        private void MainForm_activated(object sender, EventArgs e)
        {
            //debug("[]MainForm_activated");
            //Cursor.Show();
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.Visible = false;
            //this.hide(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        if (myValue != null)
                        {
                            string updateinfo = myValue.ToString();
                            string updateLocation = ApplicationDeployment.CurrentDeployment.UpdateLocation.ToString();
                            if (updateinfo == updateLocation)
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
    }
}
