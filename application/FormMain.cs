using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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
            this.tboxColorCodeR.KeyPress += new KeyPressEventHandler(this.KeyPress_onlyNumeric);
            this.tboxColorCodeG.KeyPress += new KeyPressEventHandler(this.KeyPress_onlyNumeric);
            this.tboxColorCodeB.KeyPress += new KeyPressEventHandler(this.KeyPress_onlyNumeric);
            bitmapPreview = new Bitmap(picboxPreview.Width, picboxPreview.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
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
            using (FormColorPickup form = new FormColorPickup(this))
            {
                form.ShowDialog();
            }
        }

        /// <summary>
        /// [이벤트] 팔레트 버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColorPaletteDialog_Click(object sender, EventArgs e)
        {
            Color color = getColor_fromColorDialog();
            generateView_fromColor(color);
        }

        /// <summary>
        /// 입력된 값으로 색상코드 추출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCode_KeyUp(object sender, KeyEventArgs e)
        {
            changeColorRGBText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int code = Int32.Parse((sender as TextBox).Text);
                if (code > 255) code = 255;
                if (code < 0) code = 0;

                (sender as TextBox).Text = code.ToString();
            }
            catch (Exception ex)
            {
                (sender as TextBox).Text = "0";
                debug("[Exception][txtColorCode_TextChanged]", ex.ToString());
            }
        }

        /// <summary>
        /// RGB () 형태의 입력값 으로 color 전환
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeRGB_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                return;
            }
            Regex reg = new Regex(@"rgb\((\d+),(\d+),(\d+)\)");
            Match match = reg.Match((sender as TextBox).Text.Replace(" ", "").ToLower());
            if (match.Success)
            {
                try
                {
                    int colorR, colorG, colorB;
                    string[] strs = (sender as TextBox).Text.Replace("RGB(", "").Replace(")", "").Split(new char[] { ',' });
                    colorR = forcedStrtoInt(strs[0]);
                    colorG = forcedStrtoInt(strs[1]);
                    colorB = forcedStrtoInt(strs[2]);

                    getnerateView_formColor(colorR, colorG, colorB);
                }
                catch (Exception ex)
                {
                    generateView_fromColor(Color.Black);
                    debug("[Exception][txtColorCodeRGB_KeyUp]", ex.ToString());
                }

            }
            else
            {
                debug("[txtColorCodeRGB_KeyUp] ColorCode [Hex] 입력값이 양식과 일치하지 않음");
            }

        }

        /// <summary>
        /// 입력된 값으로 색상코드 추출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeFF_KeyUp(object sender, KeyEventArgs e)
        {
            //debug("[txtColorCodeFF_KeyUp]");
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                return;
            }

            Regex reg = new Regex(@"^#(([0-9a-fA-F]{2}){3}|([0-9a-fA-F]){3})$");
            Match match = reg.Match((sender as TextBox).Text.Replace(" ", "").ToLower());
            if (match.Success)
            {
                try
                {
                    Color color = ColorTranslator.FromHtml((sender as TextBox).Text);
                    generateView_fromColor(color);
                }
                catch (Exception ex)
                {
                    generateView_fromColor(Color.Black);
                    debug("[Exception][txtColorCodeFF_KeyUp]", ex.ToString());
                }
            }
            else
            {
                debug("[txtColorCodeFF_KeyUp] ColorCode [Hex] 입력값이 양식과 일치하지 않음");
            }
        }

        /// <summary>
        /// #00FF11 과 같은 형태 입력받음. 입력문자 를 제한.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColorCodeFF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //debug("[txtColorCodeFF_KeyPress]");
            char c = e.KeyChar;

            if (
                !(char.IsDigit(e.KeyChar) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f') || (c == Convert.ToChar(35)) || c == Convert.ToChar(Keys.Back))
               )
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 색상 팔레트 다이얼로그 열기.
        /// </summary>
        /// <returns></returns>
        private Color getColor_fromColorDialog()
        {
            try
            {
                if (colordialog1.ShowDialog() == DialogResult.OK)
                {
                    return colordialog1.Color;
                }
                else
                {
                    return Color.Black;
                }
            } catch (Exception  ex)
            {
                debug("[Exception][getColor_fromColorDialog]", ex.ToString());
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
        /// ClickOnce 설치 의 경우, 제어판-프로그램추가/삭제 에서 아이콘 표시가 안 나온다.
        /// 그 부분을 보정하는 소스.
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
                    string iconSourcePath = Path.Combine(Application.StartupPath, "MainIcon.ico");

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