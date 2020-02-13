using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoQ.Models.Models
{
    public class LikedGameModel
    {
        [Key]
        public int LikedGameID { get; set; }

        public int GameID { get; set; }

        public string GameName { get; set; }
        
        public int Score { get; set; }

        public string System { get; set; }

        public DateTime LikedOn { get; set; }
    }
}
