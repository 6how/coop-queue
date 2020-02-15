using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coop_queue.Models;
using CoQ.Web.Models.ViewModels;
using CoQ.Models.Models;
using CoQ.Domain.Abstracts;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace coop_queue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoopQueue coopQueue;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ICoopQueue coopQueue, IHostingEnvironment hostingEnvironment)
        {
            this.coopQueue = coopQueue;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            int UserID = 1;

            List<FeedGameModel> viewModel = await coopQueue.GetFeedGame(UserID);

            return View(viewModel);
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
            int UserID = 1;

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Friends()
        {
            int UserID = 1;
            List<FriendshipModel> viewModel = await coopQueue.GetUserFriend(UserID);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Likes()
        {
            int UserID = 1;
            List<LikedGameModel> viewModel = await coopQueue.GetLikedGame(UserID);

            return View(viewModel);
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult MessageThread()
        {
            return View();
        }

        public async Task<ActionResult> GameDetails(int GameID)
        {
            GameModel viewModel = await coopQueue.GetGameByID(GameID);

            return View(viewModel);
        }

        public ActionResult UploadTest()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile()
        {
            int GameID = 5;

            IFormFile file = Request.Form.Files[0];
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + file.FileName;
            string filePath = Path.Combine(Path.Combine(hostingEnvironment.WebRootPath, "images"), fileName);

            using (var fileStream  = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            ImageModel image = new ImageModel
            {
                Base64String = filePath,
                ContentType = file.ContentType,
                FileSize = file.Length,
                Name = fileName
            };

            // Using the return image object to have the ID.
            ImageModel returnImage = await coopQueue.PostGameImage(image, GameID);

            return RedirectToAction("TestView", "Home", returnImage);
        }

        public ActionResult TestView(ImageModel image)
        {
            return View(image);
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
