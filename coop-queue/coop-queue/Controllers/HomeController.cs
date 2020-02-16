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

            List<GameModel> viewModel = await coopQueue.GetFeedGame(UserID);

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

            FriendsPageViewModel viewModel = new FriendsPageViewModel
            {
                Friends = await coopQueue.GetUserFriend(UserID),
                PendingFriends = await coopQueue.GetPendingFriends(UserID)
            };

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

        public async Task<ActionResult> GameDetails(int GameID, bool isLiked)
        {
            GameModel gameModel = await coopQueue.GetGameByID(GameID);

            GameDetailsViewModel viewModel = new GameDetailsViewModel
            {
                GameModel = gameModel,
                News = await coopQueue.GetNewsByID(GameID),
                Reviews = await coopQueue.GetReviewsByID(GameID),
                Screenshots = await coopQueue.GetScreenshotsByID(GameID),
                Trailers = await coopQueue.GetTrailersByID(GameID),
                IsLiked = isLiked,
                UserID = 1
            };

            return View(viewModel);
        }

        public async Task<ActionResult> UserDetails(int UserID)
        {
            ProfileViewModel viewModel = new ProfileViewModel
            {
                User = await coopQueue.GetUserProfile(UserID),
                LikedGames = await coopQueue.GetLikedGame(UserID)
            };

            return View(viewModel);
        }

        public async Task<ActionResult> PotentialFriends(int GameID, int UserID)
        {
            UserID = 1;
            List<UserModel> viewModel = await coopQueue.GetUsersByGame(GameID, UserID);

            return View(viewModel);
        }

        public async Task<ActionResult> AddFriend(int UserID, int FriendID)
        {
            UserModel addedFriend = await coopQueue.PostAddFriend(UserID, FriendID);

            return Json(new { success = true });
        }

        public async Task<ActionResult> AcceptFriend(int UserID, int FriendID)
        {
            UserModel acceptedFriend = await coopQueue.PutAcceptFriend(UserID, FriendID);

            return Json(new { success = true });
        }

        public ActionResult UploadTest()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile()
        {
            int UserID = 1;

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
            ImageModel returnImage = await coopQueue.PostImage(image, UserID);

            return RedirectToAction("TestView", "Home", returnImage);
        }

        [HttpPost]
        public async Task<ActionResult> DislikeGame(int UserID, int GameID)
        {
            GameModel dislikedGame = await coopQueue.PostDislikedGame(UserID, GameID);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> LikeGame(int UserID, int GameID)
        {
            GameModel likedGame = await coopQueue.PostLikedGame(UserID, GameID);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> RemoveFriend(int UserID, int FriendID)
        {
            FriendshipModel deletedFriendship = await coopQueue.PostRemoveFriend(UserID, FriendID);

            return Json(new { success = true });
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
    }
}
