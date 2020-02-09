using coop_queue.Models;
using CoQ.Domain.Abstracts;
using CoQ.Domain.Entities;
using CoQ.Domain.Services;
using CoQ.Models.Models;
using CoQ.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace coop_queue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoopQueue coopQueue;
        private readonly CoQService coqService;
        private readonly string userIdCacheKeyPrefix = "CurrentUser";
        private IMemoryCache memoryCache;
        private int UserID;

        public HomeController(ICoopQueue coopQueue, CoQService coqService, IMemoryCache memoryCache)
        {
            this.coopQueue = coopQueue;
            this.coqService = coqService;
            this.memoryCache = memoryCache;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Preferences()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Profile()
        {
            ProfileViewModel viewModel = new ProfileViewModel
            {
                User = await coopQueue.GetUserProfile(UserID),
                Friends = await coopQueue.GetUserFriend(UserID),
                LikedGames = await coopQueue.GetLikedGame(UserID)
            };

            return View(viewModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        public async Task<ActionResult> Friends()
        {
            List<FriendshipModel> viewModel = await coopQueue.GetUserFriend(UserID);

            return View(viewModel);
        }

        public ActionResult Likes()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult Login(string enteredEmail = "glasercr@mail.uc.edu", string enteredPassword = "PASSWORD")
        {
            SPCheckLoginCredentials credentials = coopQueue.GetCredentials(enteredEmail, enteredPassword);

            MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

            var key = $"{userIdCacheKeyPrefix}";
            if (!cache.TryGetValue(key, out int userID))
            {
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                userID = coopQueue.GetUserID(credentials.EmailAddress);
                this.UserID = userID;
                cache.Set(key, userID, options);
            }

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
            FriendshipID = 1
        };

        public FriendshipModel coleTest = new FriendshipModel
        {
            FriendAddedOn = DateTime.Now.AddDays(-7),
            FriendFromID = 1,
            FriendToID = 2,
            FriendshipID = 2
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

        //public LikedGameModel coleHalo = new LikedGameModel
        //{
        //    LikedGameID = 1,
        //    LikedOnDate = DateTime.Now.AddDays(-16),
        //    Game = new GameModel
        //    {
        //        GameID = 1,
        //        GameName = "Halo: The Master Chief Collection",
        //        GameScore = 8,
        //        GameSystem = "PC",
        //        IsActive = true
        //    },
        //    IsActive = true
        //};

        //public LikedGameModel coleLast = new LikedGameModel
        //{
        //    LikedGameID = 2,
        //    LikedOnDate = DateTime.Now.AddDays(-700),
        //    Game = new GameModel
        //    {
        //        GameID = 2,
        //        GameName = "The Last Of Us",
        //        GameScore = 9.75,
        //        GameSystem = "Playstation",
        //        IsActive = true
        //    },
        //    IsActive = true
        //};

        #endregion
    }
}
