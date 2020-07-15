using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_HIT_2020A_Ex03.CommandFolder
{
    public class MenuItem
    {
        private Action m_CommandDelegate;
        private string m_Text;

        public string Text
        {
            get
            {
                return m_Text;
            }
        }

        public Action CommandDeleage
        {
            get
            {
                return m_CommandDelegate;
            }
        }

        public MenuItem(string i_Text, Action i_Command)
        {
            m_Text = i_Text;
            m_CommandDelegate = i_Command;
        }        
    }
}
