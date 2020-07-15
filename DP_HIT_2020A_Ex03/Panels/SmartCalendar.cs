using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using FacebookWrapper.ObjectModel;
using DP_HIT_2020A_Ex03.SmartCalendarFolder;
using static DP_HIT_2020A_Ex03.IteratorFolder.Iterator;

namespace DP_HIT_2020A_Ex03
{
    public partial class SmartCalendar : UserControl
    {
        private readonly FacebookApplication r_FacebookApplication = new FacebookApplication();

        public SmartCalendar()
        {
            InitializeComponent();
            updateDataInComboText();
        }

        private void updateDataInComboText()
        {
            r_FacebookApplication.CreateMenuItems();
            menuItemBindingSource.DataSource = r_FacebookApplication.GetMenuItems();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            messegeBoxHelp();
        }

        private void clearTable()
        {
            dataGridViewFriendsBirthdayInTheDate.Invoke(new Action(() => dataGridViewFriendsBirthdayInTheDate.Rows.Clear()));
            dataGridViewFriendsBirthdayInTheDate.Invoke(new Action(() => dataGridViewFriendsBirthdayInTheDate.Visible = false));
        }

        private void addRowToTable(IEnumerator i_UserToAdd)
        {
            dataGridViewFriendsBirthdayInTheDate.Invoke(new Action(() => dataGridViewFriendsBirthdayInTheDate.Visible = true));

            do
            {
                dataGridViewFriendsBirthdayInTheDate.Invoke(new Action(() =>
                dataGridViewFriendsBirthdayInTheDate.Rows.Add(
                    new object[]
                    {
                        (i_UserToAdd.Current as UserIterator).FirstName,
                        (i_UserToAdd.Current as UserIterator).LastName,
                        (i_UserToAdd.Current as UserIterator).ImageNormal
                })));
            }
            while (i_UserToAdd.MoveNext());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            new Thread(search).Start();
        }

        private void search()
        {
            IEnumerator user;

            clearTable();

            try
            {
                DateTime start = monthCalendarView.SelectionStart;
                string text = string.Empty;
                comboBoxCalendarSelection.Invoke(new Action(() => text = comboBoxCalendarSelection.Text));

                user = r_FacebookApplication.SearchWithDate(start, text);
                if (user.MoveNext())
                {
                    addRowToTable(user);
                }
                else
                {
                    MessageBox.Show("Search Finished Nothing Found.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("Cant Search: {0}", error.Message));
            }
        }

        private void monthCalendarView_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBoxCalenderDateText.Text = monthCalendarView.SelectionStart.ToString();
        }

        private void messegeBoxHelp()
        {
            string message =
@"'Photos' - Searches all your friends' albums and finds for you who uploaded a photo on the date you were looking for
'Birthday' - Showing you all friends that born on the date you entered
'Posts' - Shows you all the friends who uploaded a post on your chosen date";
            string title = "Help smart calender";
            MessageBox.Show(message, title);
        }

        public void Reset()
        {
            clearTable();
        }
    }
}
