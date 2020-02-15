using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoQ.Models.Models
{
    public class FriendshipModel
    {
        [Key]
        public int FriendshipID { get; set; }

        public int FriendFromID { get; set; }

        public int FriendToID { get; set; }

        public DateTime FriendAddedOn { get; set; }

        public string FriendImageName { get; set; }

        public string FriendName { get; set; }

        public int OtherFriendID { get; set; }

        public string FriendImagePath { get; set; }
    }
}
