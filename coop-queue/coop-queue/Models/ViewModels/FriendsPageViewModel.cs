using CoQ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoQ.Web.Models.ViewModels
{
    public class FriendsPageViewModel
    {
        public List<FriendshipModel> Friends { get; set; }

        public List<FriendshipModel> PendingFriends { get; set; }
    }
}
