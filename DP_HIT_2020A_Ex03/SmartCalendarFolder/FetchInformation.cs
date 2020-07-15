using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FacebookWrapper.ObjectModel;
using DP_HIT_2020A_Ex03.CommandFolder;

namespace DP_HIT_2020A_Ex03.SmartCalendarFolder
{
    public class FetchInformation
    {
        private readonly ServerInformation r_ServerInformation = Singleton<ServerInformation>.Instance;
        private DateTime m_DateTime;
        private List<User> m_UsersToAdd;
        private CommandFolder.Menu m_Menu;

        public void CreateMenuItems()
        {
            m_Menu = new CommandFolder.Menu()
            {
                new CommandFolder.MenuItem("Photos", searchPhotosWithDate ),
                new CommandFolder.MenuItem("Birthdays", searchBirthdayWithDate ),
                new CommandFolder.MenuItem("Posts", searchPostsWithDate )
            };
        }

        public CommandFolder.Menu GetMenuComboBox()
        {
            return m_Menu;
        }

        public IEnumerator SearchWithDate(DateTime i_Date, string i_Type)
        {
            m_DateTime = i_Date;
            IteratorFolder.Iterator iterator = null;

            try
            {
                if (r_ServerInformation.CheckIfNeedToRefresh())
                {
                    r_ServerInformation.ClearAll();
                }

                getUsers();
                m_Menu.StringAnalysisAndRunFunction(i_Type);
                iterator = new IteratorFolder.Iterator(m_UsersToAdd);
            }
            catch (Exception e)
            {
                throw e;
            }

            return (iterator as IEnumerable).GetEnumerator();
        }

        private void searchPhotosWithDate()
        {
            bool checkIfUserEnterToTheTable = false;
            m_UsersToAdd = new List<User>();

            foreach (User friend in r_ServerInformation.GetFriendsList())
            {
                checkIfUserEnterToTheTable = false;

                foreach (Album album in friend.Albums)
                {
                    if (!checkIfUserEnterToTheTable)
                    {
                        foreach (Photo photo in album.Photos)
                        {
                            DateTime dateTime = photo.CreatedTime.Value.Date;

                            if (m_DateTime.Day == dateTime.Day &&
                            m_DateTime.Month == dateTime.Month)
                            {
                                m_UsersToAdd.Add(friend);
                                checkIfUserEnterToTheTable = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void searchBirthdayWithDate()
        {
            m_UsersToAdd = new List<User>();

            foreach (User friend in r_ServerInformation.GetFriendsList())
            {
                DateTime birthdayFriend;
                string[] formats = { "MM/dd", "MM/dd/yy", "MM/dd/yyyy" };
                DateTime.TryParseExact(
                    friend.Birthday,
                    formats,
                    CultureInfo.InvariantCulture,
                          DateTimeStyles.None,
                          out birthdayFriend);

                if (m_DateTime.Day == birthdayFriend.Day &&
                    m_DateTime.Month == birthdayFriend.Month)
                {
                    m_UsersToAdd.Add(friend);
                }
            }
        }

        private void searchPostsWithDate()
        {
            m_UsersToAdd = new List<User>();

            foreach (User friend in r_ServerInformation.GetFriendsList())
            {
                foreach (Post post in friend.Posts)
                {
                    DateTime dateTime = post.CreatedTime.Value.Date;
                    if (m_DateTime.Day == dateTime.Day &&
                            m_DateTime.Month == dateTime.Month)
                    {
                        m_UsersToAdd.Add(friend);
                        break;
                    }
                }
            }
        }

        private void getUsers()
        {
            if (r_ServerInformation.IsFriendsListEmpty())
            {
                try
                {
                    foreach (User friend in LoginInformation.User.Friends)
                    {
                        r_ServerInformation.AddFriendToList(friend);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}