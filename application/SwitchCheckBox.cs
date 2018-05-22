using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Image_Capture
{
    public partial class SwitchCheckBox : CheckBox
    {
        public SwitchCheckBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            Padding = new Padding(1);
            Width = 50;
            ForeColor = Color.DodgerBlue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;

                // 영역을 그리는 부분
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                e.Graphics.FillPath(Checked ? new SolidBrush(ForeColor) : Brushes.LightGray, path);

                // 움직이는 원형을 그리는 부분
                r = r - 2;
                var rect = Checked ? new Rectangle(Width-(d+1)-r, d+1, r, r)
                                   : new Rectangle(d+1, d+1, r, r);


                e.Graphics.FillEllipse(Checked ? Brushes.WhiteSmoke : Brushes.WhiteSmoke, rect);
            }
        }
    }
}
