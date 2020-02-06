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

        public double GameScore { get; set; }

        // Might get changed to an enum
        public string GameSystem { get; set; }

        public bool IsActive { get; set; }

        // Image ?
    }
}
