using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coop_queue.Models;
using CoQ.Web.Models.ViewModels;
using CoQ.Models.Models;

namespace coop_queue.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Profile()
        {
            List<FriendshipModel> testFriends = new List<FriendshipModel>();
            testFriends.Add(coleAbdou);
            testFriends.Add(coleTest);

            List<LikedGameModel> testLikedGames = new List<LikedGameModel>();
            testLikedGames.Add(coleHalo);
            testLikedGames.Add(coleLast);

            ProfileViewModel viewModel = new ProfileViewModel
            {
                User = coleGlaser,
                Friends = testFriends,
                LikedGames = testLikedGames
            };

            return View(viewModel);
        }

        public ActionResult Friends()
        {
            return View();
        }

        public ActionResult Likes()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult MessageThread()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        #region TestData
        public UserModel testUser1 = new UserModel
        {
            Email = "testUser1@gmail.com",
            UserDescription = "I am a test user. The first of my line. Come play games with me!",
            UserID = 1,
            UserName = "Test User",
            IsActive = true
        };

        public UserModel coleGlaser = new UserModel
        {
            Email = "glasercr@mail.uc.edu",
            UserDescription = "I am me. Nothing really else to say.",
            UserID = 2,
            UserName = "Cole Glaser",
            IsActive = true
        };

        public UserModel abdouFall = new UserModel
        {
            Email = "fallal@mail.uc.edu",
            UserDescription = "My name is Abdou and I am the homie!",
            UserID = 3,
            UserName = "Abdou Fall",
            IsActive = true
        };

        public FriendshipModel coleAbdou = new FriendshipModel
        {
            FriendAddedOn = DateTime.Now.AddDays(-4),
            FriendFromID = 2,
            FriendToID = 3,
            FriendshipID = 1,
            IsActive = true
        };

        public FriendshipModel coleTest = new FriendshipModel
        {
            FriendAddedOn = DateTime.Now.AddDays(-7),
            FriendFromID = 1,
            FriendToID = 2,
            FriendshipID = 2,
            IsActive = true
        };

        public GameModel haloMCC = new GameModel
        {
            GameID = 1,
            GameName = "Halo: The Master Chief Collection",
            GameScore = 8,
            GameSystem = "PC",
            IsActive = true
        };

        public GameModel lastOfUS = new GameModel
        {
            GameID = 2,
            GameName = "The Last Of Us",
            GameScore = 9.75,
            GameSystem = "Playstation",
            IsActive = true
        };

        public LikedGameModel coleHalo = new LikedGameModel
        {
            LikedGameID = 1,
            UserID = 2,
            LikedOnDate = DateTime.Now.AddDays(-16),
            Game = new GameModel
            {
                GameID = 1,
                GameName = "Halo: The Master Chief Collection",
                GameScore = 8,
                GameSystem = "PC",
                IsActive = true
            },
            IsActive = true
        };

        public LikedGameModel coleLast = new LikedGameModel
        {
            LikedGameID = 2,
            UserID = 2,
            LikedOnDate = DateTime.Now.AddDays(-700),
            Game = new GameModel
            {
                GameID = 2,
                GameName = "The Last Of Us",
                GameScore = 9.75,
                GameSystem = "Playstation",
                IsActive = true
            },
            IsActive = true
        };

        #endregion
    }
}
