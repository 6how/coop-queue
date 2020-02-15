using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoQ.Models.Models
{
    public class GameModel
    {
        [Key]
        public int GameID { get; set; }

        public string GameName { get; set; }

        public string ImageName { get; set; }

        public int Score { get; set; }

        public string System { get; set; }
    }
}
