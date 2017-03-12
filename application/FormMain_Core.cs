using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SHColorPicker
{
    public partial class FormMain : Form
    {
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
            if(imgResultColor.BackColor == color)
            {
                return;
            }
            debug("generateView_fromColor",color.ToString());
            txtColorCodeR.Text = color.R.ToString();
            txtColorCodeG.Text = color.G.ToString();
            txtColorCodeB.Text = color.B.ToString();
            txtColorCodeFF.Text = getHEX_fromColor(color);
            txtColorCodeRGB.Text = getRGB_fromColor(color);
            imgResultColor.BackColor = color;
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
            int colorR = forcedStrtoInt(txtColorCodeR.Text);
            int colorG = forcedStrtoInt(txtColorCodeG.Text);
            int colorB = forcedStrtoInt(txtColorCodeB.Text);

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
