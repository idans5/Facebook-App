using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DP_HIT_2020A_Ex03
{
    public static class LoginInformation
    {
        private static readonly string sr_LoginId = "2576465782635565";

        private static readonly string[] sr_Permissions =
            {
            "public_profile",
            "email",
            "publish_to_groups",
            "user_birthday",
            "user_age_range",
            "user_gender",
            "user_link",
            "user_tagged_places",
            "user_videos",
            "publish_to_groups",
            "groups_access_member_info",
            "user_friends",
            "user_events",
            "user_likes",
            "user_location",
            "user_photos",
            "user_posts",
            "user_hometown"
        };

        private static User s_User;

        public static string LoginId => sr_LoginId;

        public static string[] Permissions => sr_Permissions;

        public static User User { get => s_User; set => s_User = value; }
    }
}
