using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace DP_HIT_2020A_Ex03
{
    public partial class FormMain : Form
    {
        private readonly FacebookApplication r_FacebookApplication;
        private BestFriends m_BestFriends;
        private Developers m_Developers;
        private SmartCalendar m_SmartCalendar;

        public FormMain()
        {
            InitializeComponent();

            pictureBoxFacebookLogo.Visible = false;

            try
            {
                r_FacebookApplication = new FacebookApplication();                
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Cant LoadFromFile Error: {0}", e.Message));
            }             
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            try
            {
                r_FacebookApplication.AppSettings.LastWindowSize = this.Size;
                r_FacebookApplication.AppSettings.LastWindowLocation = this.Location;
                r_FacebookApplication.AppSettings.RememberUser = this.checkBoxRememberUser.Checked;

                if (r_FacebookApplication.AppSettings.RememberUser)
                {
                    r_FacebookApplication.AppSettings.LastAccessToken = r_FacebookApplication.GetAccessToken();
                }
                else
                {
                    r_FacebookApplication.AppSettings.LastAccessToken = null;
                }

                r_FacebookApplication.AppSettings.SaveToFile();
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Cant SaveToFile Error: {0}", error.Message));
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                if (r_FacebookApplication.SavedLogin())
                {
                    logInUser();
                    this.checkBoxRememberUser.Checked = r_FacebookApplication.AppSettings.RememberUser;
                }                
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Cant Connect Error: {0}", error.Message));
            }

            createAllPanels();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            logInUser();
        }

        private void logInUser()
        {
            try
            {
                r_FacebookApplication.LogIn();
                fetchLoggedInUser();
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Cant LogIn Error: {0}", error.Message));
            }
        }

        private void logOutUser()
        {
            clearInformation();
            try
            {
                r_FacebookApplication.LogOut();
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Logout Error: {0}", e.Message));
            }
        }

        private void fetchLoggedInUser()
        {
            this.Text = string.Format("Welcome {0}", r_FacebookApplication.GetUser().FirstName);
            this.labelWelcome.Text = 
                string.Format("  Hi {0} {1} !", r_FacebookApplication.GetUser().FirstName, r_FacebookApplication.GetUser().LastName);
            pictureProfileUser.LoadAsync(r_FacebookApplication.GetUser().PictureNormalURL);
            setVisibleAfterConnect();
        }               

        private void setVisibleAfterConnect()
        {
            panelContainer.Visible = true;
            panelRightView.Visible = true;
            pictureBoxFacebookLogo.Visible = true;
            buttonLogout.Visible = true;
            buttonLogin.Visible = false;
        }

        private void setVisibleAfterDisconnect()
        {
            panelContainer.Visible = false;
            panelRightView.Visible = false;
            pictureBoxFacebookLogo.Visible = false;
            buttonLogout.Visible = false;
            buttonLogin.Visible = true;
        }

        private void buttonBestFriends_Click(object sender, EventArgs e)
        {
            changeButtonPosition(buttonBestFriends.Height, buttonBestFriends.Top);
            panelContainer.Controls["BestFriends"].BringToFront();
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            changeButtonPosition(buttonCredits.Height, buttonCredits.Top);
            panelContainer.Controls["Developers"].BringToFront();
        }

        private void buttonSmartCalendar_Click(object sender, EventArgs e)
        {
            changeButtonPosition(buttonSmartCalendar.Height, buttonSmartCalendar.Top);
            panelContainer.Controls["SmartCalendar"].BringToFront();
        }

        private void changeButtonPosition(int i_Height, int i_Top)
        {
            panelRightView.Height = i_Height;
            panelRightView.Top = i_Top;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                logOutUser();
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Cant LogOut Error: {0}", error.Message));
            }
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {
        }

        private void createAllPanels()
        {
            try
            {
                m_BestFriends = new BestFriends();
                m_BestFriends.Dock = DockStyle.Fill;
                m_Developers = new Developers();
                m_Developers.Dock = DockStyle.Fill;
                m_SmartCalendar = new SmartCalendar();
                m_SmartCalendar.Dock = DockStyle.Fill;

                panelContainer.Controls.Add(m_BestFriends);
                panelContainer.Controls.Add(m_Developers);
                panelContainer.Controls.Add(m_SmartCalendar);
            } 
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Cant Load Panels Error: {0}", e.Message));
            }
        }

        private void clearInformation()
        {
            this.labelWelcome.Text = string.Empty;
            this.pictureProfileUser.Image = null;
            r_FacebookApplication.Reset();
            setVisibleAfterDisconnect();
            checkBoxRememberUser.Checked = false;
            m_BestFriends.Reset();
            m_SmartCalendar.Reset();
        }
    }
}