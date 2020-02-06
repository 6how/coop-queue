using System;
using System.Collections.Generic;
using System.Text;

namespace CoQ.Models.Models
{
    public class FriendshipModel
    {
        public int FriendshipID { get; set; }

        public int FriendFromID { get; set; }

        public int FriendToID { get; set; }

        public DateTime FriendAddedOn { get; set; }

        public bool IsActive { get; set; }

        // Image ?
    }
}
