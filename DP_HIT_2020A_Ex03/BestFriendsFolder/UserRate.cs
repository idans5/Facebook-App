using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DP_HIT_2020A_Ex03
{
    public class UserRates
    {
        private readonly User r_User;
        private int m_UserRate;

        public UserRates(User i_User)
        {
            UserRate = 0;
            r_User = i_User;
        }

        public User User { get => r_User; }

        public int UserRate { get => m_UserRate; set => m_UserRate = value; }
    }
}
