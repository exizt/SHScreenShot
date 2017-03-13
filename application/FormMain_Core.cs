using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SHColorPicker
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 미리보기 이미지 비트맵
        /// </summary>
        public Bitmap bitmapPreview;

        /// <summary>
        /// R, G, B 코드, #FFF 코드 등을 생성해서 화면에 적용시킨다. 
        /// </summary>
        /// <param name="colorR"></param>
        /// <param name="colorG"></param>
        /// <param name="colorB"></param>
        public void getnerateView_formColor(int colorR,int colorG,int colorB)
        {
            if (colorR > 255) colorR = 255;
            if (colorG > 255) colorG = 255;
            if (colorB > 255) colorB = 255;
            if (colorR < 0) colorR = 0;
            if (colorG < 0) colorG = 0;
            if (colorB < 0) colorB = 0;
            generateView_fromColor(Color.FromArgb(colorR, colorG, colorB));
        }

        /// <summary>
        /// R, G, B 코드, #FFF 코드 등을 생성해서 화면에 적용시킨다.
        /// </summary>
        /// <param name="color"></param>
        public void generateView_fromColor(Color color)
        {
            if(picboxResultColor.BackColor == color)
            {
                return;
            }
            debug("generateView_fromColor",color.ToString());
            tboxColorCodeR.Text = color.R.ToString();
            tboxColorCodeG.Text = color.G.ToString();
            tboxColorCodeB.Text = color.B.ToString();
            tboxColorCodeFF.Text = getHEX_fromColor(color);
            tboxColorCodeRGB.Text = getRGB_fromColor(color);
            picboxResultColor.BackColor = color;
        }

        /// <summary>
        /// 문자열을 int 로 전환. 문제가 발생시 0 을 강제로 리턴.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private int forcedStrtoInt(string str)
        {
            try
            {
                return Int32.Parse(str);
            }
            catch (Exception ex)
            {
                debug("[Exception][forcedStrtoInt]",ex.ToString());
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void changeColorRGBText()
        {
            int colorR = forcedStrtoInt(tboxColorCodeR.Text);
            int colorG = forcedStrtoInt(tboxColorCodeG.Text);
            int colorB = forcedStrtoInt(tboxColorCodeB.Text);

            try
            {
                //color = Color.FromArgb(colorR, colorG, colorB);
                generateView_fromColor(Color.FromArgb(colorR, colorG, colorB));
            }
            catch (Exception ex)
            {
                //color = Color.Black;
                generateView_fromColor(Color.Black);
                debug("[Exception][changeColorRGBText]", ex.ToString());
            }
            
        }

        /// <summary>
        /// Color 를 Hex 로 변환
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private String getHEX_fromColor(Color color)
        {
            String hex = String.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("#");
                sb.Append(color.R.ToString("X2"));
                sb.Append(color.G.ToString("X2"));
                sb.Append(color.B.ToString("X2"));
                hex = sb.ToString();
                sb.Length = 0;
            }
            catch (Exception ex)
            {
                debug("[Exception][getHEX_fromColor]", ex.ToString());
            }
            return hex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private String getRGB_fromColor(Color color)
        {
            String rgb = String.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("RGB(");
                sb.Append(color.R.ToString());
                sb.Append(", ");
                sb.Append(color.G.ToString());
                sb.Append(", ");
                sb.Append(color.B.ToString());
                sb.Append(")");
                rgb = sb.ToString();
                //sb.Length = 0;
                sb.Clear();
            }
            catch (Exception ex)
            {
                debug("[Exception][getRGB_fromColor]", ex.ToString());
            }
            return rgb;
        }

        /// <summary>
        /// 숫자만 입력받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPress_onlyNumeric(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            //숫자와 백스페이스를 제외한 나머지를 바로 처리
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 숫자, 영문 만 입력받음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyPress_onlyAlphaNumeric(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg)
        {
            if(isDebug) System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// debug 용 메서드
        /// </summary>
        /// <param name="msg"></param>
        private void debug(string msg, string msg2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(msg);
            sb.Append(msg2);
            debug(sb.ToString());
            sb.Clear();
        }
    }
}
