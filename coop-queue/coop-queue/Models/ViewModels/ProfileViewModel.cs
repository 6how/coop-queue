using CoQ.Domain.Entities;
using CoQ.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoQ.Web.Models.ViewModels
{
    public class ProfileViewModel
    {
        public SPGetUserAccount User { get; set; }

        public List<LikedGameModel> LikedGames { get; set; }

        public List<FriendshipModel> Friends { get; set; }
    }
}
