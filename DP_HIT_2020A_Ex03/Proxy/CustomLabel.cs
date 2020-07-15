using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DP_HIT_2020A_Ex03.Proxy
{
    public class CustomLabel : Label
    {
        private Color m_Color;

        public CustomLabel()
        {
            m_Color = Color.White;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Random rnd = new Random();
            this.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.ForeColor = m_Color;
        }
    }
}
