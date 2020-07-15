using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DP_HIT_2020A_Ex03.IteratorFolder
{
    public class Iterator : IEnumerable
    {
        private readonly List<UserRates> r_UserRates;
        private readonly List<User> r_Users;

        public Iterator(List<UserRates> i_ListUserRate)
        {
            r_UserRates = i_ListUserRate;
        }

        public Iterator(List<User> i_ListUser)
        {
            r_Users = i_ListUser;
        }

        public IEnumerator GetEnumerator()
        {
            if (r_UserRates != null)
            {
                for(int i = 0; i < r_UserRates.Count; i++)
                {
                    yield return new UserIterator()
                    {
                        FirstName = r_UserRates[i].User.FirstName,
                        LastName = r_UserRates[i].User.LastName,
                        UserRate = r_UserRates[i].UserRate,
                        ImageNormal = r_UserRates[i].User.ImageNormal
                    };
                }
            }
            else if (r_Users != null)
            {
                for (int i = 0; i < r_Users.Count; i++)
                {
                    yield return new UserIterator()
                    {
                        FirstName = r_Users[i].FirstName,
                        LastName = r_Users[i].LastName,
                        ImageNormal = r_Users[i].ImageNormal
                    };
                }
            }
        }

        public class UserIterator
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int UserRate { get; set; }

            public Image ImageNormal { get; set; }
        }
    }
}
