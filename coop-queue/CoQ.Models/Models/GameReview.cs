using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoQ.Models.Models
{
    public class GameReview
    {
        [Key]
        public int MediaLinkID { get; set; }

        public string MediaURL { get; set; }

        public int GameID { get; set; }
    }
}
