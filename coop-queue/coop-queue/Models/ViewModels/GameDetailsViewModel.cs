using CoQ.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoQ.Web.Models.ViewModels
{
    public class GameDetailsViewModel
    {
        public GameModel GameModel { get; set; }

        public List<GameTrailer> Trailers { get; set; }

        public List<GameReview> Reviews { get; set; }

        public List<GameNews> News { get; set; }

        public List<GameScreenshot> Screenshots { get; set; }

        public int? UserID { get; set; }

        public bool IsLiked { get; set; }
    }
}
