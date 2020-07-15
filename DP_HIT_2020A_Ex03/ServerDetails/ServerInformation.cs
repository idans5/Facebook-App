using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DP_HIT_2020A_Ex03
{
    public class ServerInformation
    {
        private DateTime m_DateTimeBestFriends;
        private Dictionary<string, UserRates> m_UsersDictionary = new Dictionary<string, UserRates>();
        private LinkedList<User> m_FriendsList = new LinkedList<User>();
        private LinkedList<FacebookObjectCollection<User>> m_UserListPostLikedBy = new LinkedList<FacebookObjectCollection<User>>();
        private LinkedList<FacebookObjectCollection<User>> m_UserListAlbumLikedBy = new LinkedList<FacebookObjectCollection<User>>();
        private LinkedList<FacebookObjectCollection<User>> m_UserListPhotosLikedBy = new LinkedList<FacebookObjectCollection<User>>();
        private LinkedList<FacebookObjectCollection<Comment>> m_UserListPostComments = new LinkedList<FacebookObjectCollection<Comment>>();
        private LinkedList<FacebookObjectCollection<Comment>> m_UserListPhotoComments = new LinkedList<FacebookObjectCollection<Comment>>();
        private LinkedList<FacebookObjectCollection<Comment>> m_UserListAlbumComments = new LinkedList<FacebookObjectCollection<Comment>>();
        private LinkedList<FacebookObjectCollection<User>> m_UserListEvents = new LinkedList<FacebookObjectCollection<User>>();
        private LinkedList<Album> m_Albums = new LinkedList<Album>();
        private LinkedList<Post> m_Posts = new LinkedList<Post>();
        private LinkedList<Event> m_Events = new LinkedList<Event>();
        private LinkedList<Photo> m_Photos = new LinkedList<Photo>();

        private ServerInformation()
        {
            m_DateTimeBestFriends = DateTime.Now;
        }

        public void AddUserToDictionary(string i_UserId, UserRates i_UserRates)
        {
            m_UsersDictionary.Add(i_UserId, i_UserRates);
        }

        public void AddFriendToList(User i_User)
        {
            m_FriendsList.AddLast(i_User);
        }

        public void AddUserRateToDictinary(string i_UserId, int i_Rate)
        {
            m_UsersDictionary[i_UserId].UserRate += i_Rate;
        }

        public void SetUsersToDictionary(Dictionary<string, UserRates> i_Users)
        {
            m_UsersDictionary = i_Users;
        }

        public void AddAlbums(Album i_Album)
        {
            m_Albums.AddLast(i_Album);
        }

        public void AddEvents(Event i_Event)
        {
            m_Events.AddLast(i_Event);
        }

        public void AddPosts(Post i_Post)
        {
            m_Posts.AddLast(i_Post);
        }

        public void AddPhoto(Photo i_Photo)
        {
            m_Photos.AddLast(i_Photo);
        }

        public FacebookObjectCollection<User> AddUserListPostLikedBy(FacebookObjectCollection<User> i_User)
        {
            m_UserListPostLikedBy.AddLast(i_User);

            return i_User;
        }

        public FacebookObjectCollection<User> AddUserListAlbumLikedBy(FacebookObjectCollection<User> i_User)
        {
            m_UserListAlbumLikedBy.AddLast(i_User);

            return i_User;
        }

        public FacebookObjectCollection<User> AddUserListPhotoLikedBy(FacebookObjectCollection<User> i_User)
        {
            m_UserListPhotosLikedBy.AddLast(i_User);

            return i_User;
        }

        public FacebookObjectCollection<Comment> AddUserListPostComments(FacebookObjectCollection<Comment> i_Comments)
        {
            m_UserListPostComments.AddLast(i_Comments);

            return i_Comments;
        }

        public FacebookObjectCollection<Comment> AddUserListPhotoComments(FacebookObjectCollection<Comment> i_Comments)
        {
            m_UserListPhotoComments.AddLast(i_Comments);

            return i_Comments;
        }

        public FacebookObjectCollection<Comment> AddUserListAlbumComments(FacebookObjectCollection<Comment> i_Comments)
        {
            m_UserListAlbumComments.AddLast(i_Comments);

            return i_Comments;
        }

        public FacebookObjectCollection<User> AddUserListEvents(FacebookObjectCollection<User> i_User)
        {
            m_UserListEvents.AddLast(i_User);

            return i_User;
        }

        public Dictionary<string, UserRates> GetUsersDictionary()
        {
            return m_UsersDictionary;
        }

        public LinkedList<FacebookObjectCollection<User>> GetUserListPostLikedBy()
        {
            return m_UserListPostLikedBy;
        }

        public LinkedList<FacebookObjectCollection<User>> GetUserListAlbumLikedBy()
        {
            return m_UserListAlbumLikedBy;
        }

        public LinkedList<FacebookObjectCollection<Comment>> GetUserListPostComments()
        {
            return m_UserListPostComments;
        }

        public LinkedList<FacebookObjectCollection<Comment>> GetUserListAlbumComments()
        {
            return m_UserListAlbumComments;
        }

        public LinkedList<FacebookObjectCollection<User>> GetUserListEvents()
        {
            return m_UserListEvents;
        }

        public LinkedList<Post> GetPosts()
        {
            return m_Posts;
        }

        public LinkedList<Photo> GetPhotos()
        {
            return m_Photos;
        }

        public LinkedList<Event> GetEvents()
        {
            return m_Events;
        }

        public LinkedList<Album> GetAlbums()
        {
            return m_Albums;
        }

        public LinkedList<User> GetFriendsList()
        {
            return m_FriendsList;
        }

        public bool IsPostsEmpty()
        {
            return m_Posts.Count == 0;
        }

        public bool IsPhotosEmpty()
        {
            return m_Photos.Count == 0;
        }

        public bool IsAlbumsEmpty()
        {
            return m_Albums.Count == 0;
        }

        public bool IsFriendsEmpty()
        {
            return m_UsersDictionary.Count == 0;
        }

        public bool IsFriendsListEmpty()
        {
            return m_FriendsList.Count == 0;
        }

        public bool IsPostLikedByEmpty()
        {
            return m_UserListPostLikedBy.Count == 0;
        }

        public bool IsPhotosLikedByEmpty()
        {
            return m_UserListPhotosLikedBy.Count == 0;
        }

        public bool IsAlbumLikedByEmpty()
        {
            return m_UserListAlbumLikedBy.Count == 0;
        }

        public bool IsPostCommentsEmpty()
        {
            return m_UserListPostComments.Count == 0;
        }

        public bool IsPhotoCommentsEmpty()
        {
            return m_UserListPhotoComments.Count == 0;
        }

        public bool IsAlbumCommentsEmpty()
        {
            return m_UserListAlbumComments.Count == 0;
        }

        public bool IsEventsEmpty()
        {
            return m_Events.Count == 0;
        }

        public void ClearAll()
        {
            m_DateTimeBestFriends = DateTime.Now;
            m_UserListPostLikedBy = new LinkedList<FacebookObjectCollection<User>>();
            m_UserListAlbumLikedBy = new LinkedList<FacebookObjectCollection<User>>();
            m_UserListPostComments = new LinkedList<FacebookObjectCollection<Comment>>();
            m_UserListAlbumComments = new LinkedList<FacebookObjectCollection<Comment>>();
            m_UserListEvents = new LinkedList<FacebookObjectCollection<User>>();
            m_FriendsList = new LinkedList<User>();
            m_Photos = new LinkedList<Photo>();
            m_Albums = new LinkedList<Album>();
            m_Posts = new LinkedList<Post>();
            m_Events = new LinkedList<Event>();
        }

        public bool CheckIfNeedToRefresh()
        {
            DateTime currentTime = DateTime.Now;
            int lastTime = Convert.ToInt32((currentTime - m_DateTimeBestFriends).TotalMinutes);

            return lastTime >= 50;
        }
    }
}