using System;
using System.Collections.Generic;
using System.Text;

namespace CoQ.Models.Models
{
    public class LikedGameModel
    {
        public int LikedGameID { get; set; }

        public int UserID { get; set; }

        public GameModel Game { get; set; }

        public DateTime LikedOnDate { get; set; }

        public bool IsActive { get; set; }
    }
}
