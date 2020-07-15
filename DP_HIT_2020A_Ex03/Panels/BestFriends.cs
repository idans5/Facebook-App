using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using FacebookWrapper.ObjectModel;
using DP_HIT_2020A_Ex03.BestFriendsFolder;
using static DP_HIT_2020A_Ex03.IteratorFolder.Iterator;

namespace DP_HIT_2020A_Ex03
{
    public partial class BestFriends : UserControl
    {
        private const int k_NumberOfBestFriends = 5;
        private readonly FacebookApplication r_FacebookApplication = new FacebookApplication();

        public BestFriends()
        {
            InitializeComponent();
        }

        private void viewAllFriends()
        {
            try
            {
                LinkedList<User> friendsLinkedList = r_FacebookApplication.GetFriendsLinkedList();

                if (friendsLinkedList != null)
                {
                    if (!friendsListBox.InvokeRequired)
                    {
                        userBindingSource.DataSource = friendsLinkedList;
                    }
                    else
                    {
                        friendsListBox.Invoke(new Action(() => userBindingSource.DataSource = friendsLinkedList));
                    }

                    panelInformation.Invoke(new Action(() => panelInformation.Visible = true));
                    friendsListBox.Invoke(new Action(() => friendsListBox.Visible = true));                    
                }
                else
                {
                    MessageBox.Show("Your Friends Not Found.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Error Filed To Fetch Friends: {0}", error.Message));
            }
        }

        private void buttonViewAllFriends_Click(object sender, EventArgs e)
        {
            new Thread(viewAllFriends).Start();
        }

        private void getBestFriends()
        {
            try
            {                
                IEnumerator friend = r_FacebookApplication.GetBestFriends(k_NumberOfBestFriends);
                
                if(friend.MoveNext())
                {
                    clearBestFriendsTable();
                    addBestFriendsToTable(friend);
                }
                else
                {
                    MessageBox.Show("Your Best Friends Not Found.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Error Filed To Fetch Best Friends: {0}", error.Message));
            }
        }

        private void buttonGetBestFriends_Click(object sender, EventArgs e)
        {
            new Thread(getBestFriends).Start();
        }

        private void addBestFriendsToTable(IEnumerator i_Friend)
        {
            try
            {
                do
                {
                    bestFriendsTable.Invoke(new Action(() =>
                    bestFriendsTable.Rows.Add(
                        new object[] 
                        {
                        (i_Friend.Current as UserIterator).FirstName,
                        (i_Friend.Current as UserIterator).LastName,
                        (i_Friend.Current as UserIterator).UserRate,
                        (i_Friend.Current as UserIterator).ImageNormal
                    })));
                }
                while (i_Friend.MoveNext());

                bestFriendsTable.Invoke(new Action(() => bestFriendsTable.Visible = true));
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error Filed To Add To Table BestFriends: {0}", e.Message));
            }
        }

        public void Reset()
        {
            clearBestFriendsTable();
            panelInformation.Invoke(new Action(() => panelInformation.Visible = false));
            friendsListBox.Invoke(new Action(() => friendsListBox.Visible = false));
        }

        private void clearBestFriendsTable()
        {
            bestFriendsTable.Invoke(new Action(() => bestFriendsTable.Rows.Clear()));
            bestFriendsTable.Invoke(new Action(() => bestFriendsTable.Visible = false));
        }
    }
}