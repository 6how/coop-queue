using coop_queue.Models;
using CoQ.Domain.Abstracts;
using CoQ.Models.Models;
using CoQ.Web.Models;
using CoQ.Web.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace coop_queue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoopQueue coopQueue;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public HomeController(ICoopQueue coopQueue, IHostingEnvironment hostingEnvironment,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.coopQueue = coopQueue;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult> Landing()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

            ProfileViewModel viewModel = new ProfileViewModel
            {
                User = await coopQueue.GetUserProfile(UserID),
                Friends = await coopQueue.GetUserFriend(UserID),
                LikedGames = await coopQueue.GetLikedGame(UserID)
            };

            return View(viewModel);
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        public async Task<ActionResult> RegisterAccount(string enteredUserName, string enteredEmail, string enteredPassword)
        {
            AppUser user = await userManager.FindByEmailAsync(enteredEmail);
            if (user == null)
            {
                user = new AppUser
                {
                    UserName = enteredUserName,
                    Email = enteredEmail
                };

                IdentityResult result = await userManager.CreateAsync(user, enteredPassword);
            }

            return RedirectToAction("Login");
        }

        public async Task<ActionResult> Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> ConfirmLogin(string enteredUserName, string enteredPassword)
        {
            var result = await signInManager.PasswordSignInAsync(enteredUserName, enteredPassword, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //error handling 
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<ActionResult> Friends()
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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

        public async Task<ActionResult> PotentialFriends(int GameID)
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

            List<UserModel> viewModel = await coopQueue.GetUsersByGame(GameID, UserID);

            return View(viewModel);
        }

        public async Task<ActionResult> AddFriend(int FriendID)
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

            UserModel addedFriend = await coopQueue.PostAddFriend(UserID, FriendID);

            return Json(new { success = true });
        }

        public async Task<ActionResult> AcceptFriend(int FriendID)
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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
        public async Task<ActionResult> DislikeGame(int GameID)
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

            GameModel dislikedGame = await coopQueue.PostDislikedGame(UserID, GameID);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> LikeGame(int GameID)
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

            GameModel likedGame = await coopQueue.PostLikedGame(UserID, GameID);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<ActionResult> RemoveFriend(int FriendID)
        {
            AppUser currentUser = await userManager.GetUserAsync(User);
            int UserID = currentUser.Id;

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
