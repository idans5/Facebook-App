using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DP_HIT_2020A_Ex03.Proxy
{
    public class CustomPictueBox : PictureBox
    {
        Region m_GraphicsPath = new Region();

        public CustomPictueBox()
        {
            m_GraphicsPath = this.Region;
        }

        protected override void OnMouseEnter(EventArgs e)
        {            
            this.Region = m_GraphicsPath;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(-5, -5, this.Width + 3, this.Height + 3);
            Region region = new Region(graphicsPath);
            this.Region = region;
        }

        protected override void OnResize(EventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(this.DisplayRectangle);
           this.Region = new Region(graphicsPath);
        }
    }
}
