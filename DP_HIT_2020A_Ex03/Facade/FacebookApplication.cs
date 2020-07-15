using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP_HIT_2020A_Ex03
{
    public class FacebookApplication
    {
        private readonly BestFriendsFolder.FetchInformation r_BestFriendsFetchInformation = new BestFriendsFolder.FetchInformation();
        private readonly SmartCalendarFolder.FetchInformation r_SmartCalendarFetchInformation = new SmartCalendarFolder.FetchInformation();
        private AppSettings m_AppSettings;
        private LoginResult m_LoginResult;

        public FacebookApplication()
        {
            FacebookService.s_CollectionLimit = 2;

            try
            {
                m_AppSettings = AppSettings.LoadFromFile();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CreateMenuItems()
        {
            r_SmartCalendarFetchInformation.CreateMenuItems();
        }

        public CommandFolder.Menu GetMenuItems()
        {
            return r_SmartCalendarFetchInformation.GetMenuComboBox();
        }

        public IEnumerator GetBestFriends(int i_NumberOfFriends)
        {
            try
            {                
                return r_BestFriendsFetchInformation.GetBestFriends(LoginInformation.User, i_NumberOfFriends);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public LinkedList<User> GetFriendsLinkedList()
        {
            try
            {
                return r_BestFriendsFetchInformation.GetFriendsLinkedList(LoginInformation.User);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerator SearchWithDate(DateTime i_Date, string i_Type)
        {
            try
            {
                return r_SmartCalendarFetchInformation.SearchWithDate(i_Date, i_Type);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void LogIn()
        {
            try
            {
                if (SavedLogin())
                {
                    m_LoginResult = FacebookService.Connect(m_AppSettings.LastAccessToken);
                }
                else
                {
                    m_LoginResult = FacebookService.Login(LoginInformation.LoginId, LoginInformation.Permissions);
                }

                LoginInformation.User = m_LoginResult.LoggedInUser;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool SavedLogin()
        {
            return m_AppSettings.RememberUser && 
                !string.IsNullOrEmpty(m_AppSettings.LastAccessToken);
        }

        public User GetUser()
        {
            if (LoginInformation.User != null)
            {
                return LoginInformation.User;
            }
            else
            {
                throw new Exception("Null User");
            }
        }

        public void Reset()
        {
            m_LoginResult = null;
            LoginInformation.User = null;
        }

        public AppSettings AppSettings
        {
            get
            {
                return m_AppSettings;
            }

            set
            {
                m_AppSettings = value;
            }
        }

        public string GetAccessToken()
        {
            return m_LoginResult.AccessToken;
        }

        public void LogOut()
        {
            try
            {
                FacebookService.Logout(() => { });
                Reset();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
