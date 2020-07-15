using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FacebookWrapper.ObjectModel;

namespace DP_HIT_2020A_Ex03.BestFriendsFolder
{
    public class FetchInformation
    {
        private readonly CalculatorUserRate<User> r_CalculateUserRateByLikes =
            new CalculatorUserRate<User>((friend, userid) => friend.Id != userid);

        private readonly CalculatorUserRate<Comment> r_CalculateUserRateByComments =
            new CalculatorUserRate<Comment>((comment, userid) => comment.From.Id != userid);

        private readonly ServerInformation r_ServerInformation = Singleton<ServerInformation>.Instance;
        private User m_LoggedInUser;
        private Exception m_Exception;
        private List<UserRates> m_FriendsScoreList;
        private int m_NumberOfBestFriends;

        public IEnumerator GetBestFriends(User i_LoggedInUser, int i_NumberOfBestFriends)
        {
            m_FriendsScoreList = new List<UserRates>();
            m_NumberOfBestFriends = i_NumberOfBestFriends;
            m_Exception = null;
            IteratorFolder.Iterator iterator = null;

            onStart(i_LoggedInUser);

            try
            {
                r_ServerInformation.SetUsersToDictionary(getFriendsDictionary());
                fetchAllInformation();

                if (m_Exception != null)
                {
                    throw m_Exception;
                }

                if (r_ServerInformation.GetUsersDictionary().Count != 0)
                {
                    calculateFriendsScore();

                    if (m_Exception != null)
                    {
                        throw m_Exception;
                    }

                    m_FriendsScoreList = convertFriendsScoreToList();
                    m_FriendsScoreList.Sort(compare);
                    iterator = new IteratorFolder.Iterator(m_FriendsScoreList);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

           return (iterator as IEnumerable).GetEnumerator();
        }

        public LinkedList<User> GetFriendsLinkedList(User i_LoggedInUser)
        {
            LinkedList<User> friendLinkedList = new LinkedList<User>();
            onStart(i_LoggedInUser);

            try
            {
                friendLinkedList = getFriendsLinkedList();
            }
            catch (Exception e)
            {
                throw e;
            }

            return friendLinkedList;
        }

        private void onStart(User i_LoggedInUser)
        {
            m_LoggedInUser = i_LoggedInUser;

            if (r_ServerInformation.CheckIfNeedToRefresh())
            {
                r_ServerInformation.ClearAll();
            }
        }

        private int compare(UserRates i_First, UserRates i_Second)
        {
            int compareScore = i_First.UserRate.CompareTo(i_Second.UserRate);

            return compareScore;
        }

        private Dictionary<string, UserRates> getFriendsDictionary()
        {
            Dictionary<string, UserRates> friendsDicrionary = new Dictionary<string, UserRates>();

            try
            {
                if (r_ServerInformation.IsFriendsListEmpty())
                {
                    foreach (User user in m_LoggedInUser.Friends)
                    {
                        friendsDicrionary.Add(user.Id, new UserRates(user));
                        r_ServerInformation.AddFriendToList(user);
                    }
                }
                else
                {
                    foreach (User user in r_ServerInformation.GetFriendsList())
                    {
                        friendsDicrionary.Add(user.Id, new UserRates(user));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return friendsDicrionary;
        }

        private LinkedList<User> getFriendsLinkedList()
        {
            LinkedList<User> friendsList = new LinkedList<User>();

            if (r_ServerInformation.IsFriendsListEmpty())
            {
                if (m_LoggedInUser.Friends.Count != 0)
                {
                    foreach (User user in m_LoggedInUser.Friends)
                    {
                        friendsList.AddLast(user);
                        r_ServerInformation.AddFriendToList(user);
                    }
                }
            }
            else
            {
                friendsList = r_ServerInformation.GetFriendsList();
            }

            return friendsList;
        }

        private List<UserRates> convertFriendsScoreToList()
        {
            List<UserRates> friendsScoreList = new List<UserRates>();
            Dictionary<string, UserRates> friendsDictionary = r_ServerInformation.GetUsersDictionary();

            if (friendsDictionary.Count != 0)
            {
                foreach (KeyValuePair<string, UserRates> friend in friendsDictionary)
                {
                    friendsScoreList.Add(friend.Value);
                }
            }

            return friendsScoreList;
        }

        private void calculateFriendsScore()
        {
            if (!r_ServerInformation.IsFriendsEmpty())
            {
                try
                {                             
                    UserRateBy<Post, User> userRateByLikesPosts = new UserRateBy<Post, User>(
                        () => (r_ServerInformation.IsPostLikedByEmpty() && !r_ServerInformation.IsPostsEmpty()) == true,
                        (post) => r_ServerInformation.AddUserListPostLikedBy(post.LikedBy),
                        (likedByFriends, userId, value) => r_CalculateUserRateByLikes.CalculateUserRate(likedByFriends, userId, value),
                        r_ServerInformation.GetPosts(),
                        getUserId(),
                        1,
                        ref m_Exception);
                    UserRateBy<Album, User> userRateByLikesAlbums = new UserRateBy<Album, User>(
                        () => (r_ServerInformation.IsAlbumLikedByEmpty() && !r_ServerInformation.IsAlbumsEmpty()) == true,
                        (album) => r_ServerInformation.AddUserListAlbumLikedBy(album.LikedBy),
                        (likedByFriends, userId, value) => r_CalculateUserRateByLikes.CalculateUserRate(likedByFriends, userId, value),
                        r_ServerInformation.GetAlbums(),
                        getUserId(),
                        3,
                        ref m_Exception);
                    UserRateBy<Photo, User> userRateByLikesPhotos = new UserRateBy<Photo, User>(
                        () => (r_ServerInformation.IsPhotosLikedByEmpty() && !r_ServerInformation.IsPhotosEmpty()) == true,
                        (photo) => r_ServerInformation.AddUserListPhotoLikedBy(photo.LikedBy),
                        (likedByFriends, userId, value) => r_CalculateUserRateByLikes.CalculateUserRate(likedByFriends, userId, value),
                        r_ServerInformation.GetPhotos(),
                        getUserId(),
                        1,
                        ref m_Exception);
                    UserRateBy<Album, Comment> userRateByCommentsAlbums = new UserRateBy<Album, Comment>(
                        () => (r_ServerInformation.IsAlbumCommentsEmpty() && !r_ServerInformation.IsAlbumsEmpty()) == true,
                        (album) => r_ServerInformation.AddUserListAlbumComments(album.Comments),
                        (commentsByFriends, userId, value) => r_CalculateUserRateByComments.CalculateUserRate(commentsByFriends, userId, value),
                        r_ServerInformation.GetAlbums(),
                        getUserId(),
                        3,
                        ref m_Exception);
                    UserRateBy<Photo, Comment> userRateByCommentsPhotos = new UserRateBy<Photo, Comment>(
                        () => (r_ServerInformation.IsPhotoCommentsEmpty() && !r_ServerInformation.IsPhotosEmpty()) == true,
                        (photo) => r_ServerInformation.AddUserListPhotoComments(photo.Comments),
                        (commentsByFriends, userId, value) => r_CalculateUserRateByComments.CalculateUserRate(commentsByFriends, userId, value),
                        r_ServerInformation.GetPhotos(),
                        getUserId(),
                        2,
                        ref m_Exception);
                    UserRateBy<Post, Comment> userRateByCommentsPosts = new UserRateBy<Post, Comment>(
                        () => (r_ServerInformation.IsPostCommentsEmpty() && !r_ServerInformation.IsPostsEmpty()) == true,
                        (post) => r_ServerInformation.AddUserListPostComments(post.Comments),
                        (commentsByFriends, userId, value) => r_CalculateUserRateByComments.CalculateUserRate(commentsByFriends, userId, value),
                        r_ServerInformation.GetPosts(),
                        getUserId(),
                        2,
                        ref m_Exception);
                    Thread threadUserRateByLikesPosts = new Thread(userRateByLikesPosts.RateBy);
                    Thread threadUserRateByLikesAlbums = new Thread(userRateByLikesAlbums.RateBy);
                    Thread threadUserRateByLikesPhotos = new Thread(userRateByLikesPhotos.RateBy);
                    Thread threadUserRateByCommentsAlbums = new Thread(userRateByCommentsAlbums.RateBy);
                    Thread threadUserRateByCommentsPhotos = new Thread(userRateByCommentsPhotos.RateBy);
                    Thread threadUserRateByCommentsPosts = new Thread(userRateByCommentsPosts.RateBy);
                    Thread threadUserRateByGoingSameEvents = new Thread(userRateByGoingSameEvents);
                    threadUserRateByLikesPosts.Start();
                    threadUserRateByLikesAlbums.Start();
                    threadUserRateByLikesPhotos.Start();
                    threadUserRateByCommentsAlbums.Start();
                    threadUserRateByCommentsPhotos.Start();
                    threadUserRateByCommentsPosts.Start();
                    threadUserRateByGoingSameEvents.Start();
                    threadUserRateByLikesPosts.Join();
                    threadUserRateByLikesAlbums.Join();
                    threadUserRateByLikesPhotos.Join();
                    threadUserRateByCommentsAlbums.Join();
                    threadUserRateByCommentsPhotos.Join();
                    threadUserRateByCommentsPosts.Join();
                    threadUserRateByGoingSameEvents.Join();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private void userRateByGoingSameEvents()
        {
            if (r_ServerInformation.IsEventsEmpty())
            {
                string userId = getUserId();
                try
                {
                    foreach (Event events in r_ServerInformation.GetEvents())
                    {
                        FacebookObjectCollection<User> userEvent =
                                                r_ServerInformation.AddUserListEvents(events.AttendingUsers);
                        if (userEvent.Count != 0)
                        {
                            foreach (User user in userEvent)
                            {
                                if (user.Id != userId)
                                {
                                    r_ServerInformation.AddUserRateToDictinary(userId, 1);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    if (m_Exception == null)
                    {
                        m_Exception = e;
                    }
                }
            }              /* permission error */
        }

        private void getPosts()
        {
            try
            {
                foreach (Post post in m_LoggedInUser.Posts)
                {
                    r_ServerInformation.AddPosts(post);
                }
            }
            catch (Exception e)
            {
                if (m_Exception == null)
                {
                    m_Exception = e;
                }
            }
        }

        private void getEvents()
        {
            /*foreach (Event events in m_LoggedInUser.Events)
            {
                ServerInformation.AddEvents(events);
            }*/
            ////permission error
        }

        private void getAlbumsAndPhotos()
        {
            try
            {
                foreach (Album album in m_LoggedInUser.Albums)
                {
                    r_ServerInformation.AddAlbums(album);
                    foreach (Photo photo in album.Photos)
                    {
                        r_ServerInformation.AddPhoto(photo);
                    }
                }
            }
            catch (Exception e)
            {
                if (m_Exception == null)
                {
                    m_Exception = e;
                }
            }
        }

        private string getUserId()
        {
            string userId = string.Empty;
            try
            {
                userId = m_LoggedInUser.Id;
            }
            catch (Exception e)
            {
              throw e;
            }

            return userId;
        }

        private void fetchAllInformation()
        {
            try
            {
                Thread threadGetPost = new Thread(getPosts);
                Thread threadGetAlbumsAndPhotos = new Thread(getAlbumsAndPhotos);
                Thread threadGetEvents = new Thread(getEvents);

                if (r_ServerInformation.IsPostsEmpty())
                {
                    threadGetPost.Start();
                }

                if (r_ServerInformation.IsAlbumsEmpty())
                {
                    threadGetAlbumsAndPhotos.Start();
                }

                if (r_ServerInformation.IsEventsEmpty())
                {
                    threadGetEvents.Start();
                }
                
                if (threadGetPost.IsAlive)
                {
                    threadGetPost.Join();
                }

                if (threadGetAlbumsAndPhotos.IsAlive)
                {
                    threadGetAlbumsAndPhotos.Join();
                }

                if (threadGetEvents.IsAlive)
                {
                    threadGetEvents.Join();
                }
            }
            catch (Exception e)
            {
                if (m_Exception == null)
                {
                    m_Exception = e;
                }
            }
        }

        private class CalculatorUserRate<T>
        {
            public Func<T, string, bool> ComparerMethod { get; private set; }

            private readonly ServerInformation r_ServerInformation = Singleton<ServerInformation>.Instance;

            public CalculatorUserRate(Func<T, string, bool> i_Method)
            {
                ComparerMethod = i_Method;
            }

            public void CalculateUserRate(FacebookObjectCollection<T> i_ItemsByFriends, string i_UserId, int i_Rate)
            {
                foreach (T item in i_ItemsByFriends)
                {
                    if (ComparerMethod.Invoke(item, i_UserId))
                    {
                        r_ServerInformation.AddUserRateToDictinary(i_UserId, i_Rate);
                    }
                }
            }
        }

        private class UserRateBy<T1, T2>
        {
            public Func<bool> IsEmpty { get; private set; }

            public Func<T1, FacebookObjectCollection<T2>> MethodOne { get; private set; }

            public Exception Exception { get; private set; }

            public Action<FacebookObjectCollection<T2>, string, int> MethodTwo { get; private set; }

            private readonly ServerInformation r_ServerInformation = Singleton<ServerInformation>.Instance;
            private LinkedList<T1> m_Items;
            private string m_UserId;
            private int m_ScoreValue;

            public UserRateBy(Func<bool> i_IsEmpty, Func<T1, FacebookObjectCollection<T2>> i_MethodOne, Action<FacebookObjectCollection<T2>, string, int> i_MethodTwo, LinkedList<T1> i_Items, string i_UserId, int i_ScoreValue, ref Exception i_Exception)
            {
                IsEmpty = i_IsEmpty;
                MethodOne = i_MethodOne;
                MethodTwo = i_MethodTwo;
                m_Items = i_Items;
                m_ScoreValue = i_ScoreValue;
                m_UserId = i_UserId;
                Exception = i_Exception;
            }

            public void RateBy()
            {
                if (IsEmpty.Invoke())
                {
                        string userId = m_UserId;
                    try
                    {
                        foreach (T1 item in m_Items)
                        {
                            FacebookObjectCollection<T2> items = MethodOne(item);

                            if (items.Count != 0)
                            {
                                MethodTwo.Invoke(items, userId, m_ScoreValue);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (Exception == null)
                        {
                            Exception = e;
                        }
                    }
                }
            }
        }
    }    
}