using CoQ.Domain.Entities;
using CoQ.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoQ.Domain.Abstracts
{
    public interface ICoopQueue
    {
        
        Task<SPGetUserAccount> GetUserProfile(int UserID);
        Task<List<FriendshipModel>> GetUserFriend(int UserID);
        Task<List<LikedGameModel>> GetLikedGame(int UserID);
        Task<List<GameModel>> GetFeedGame(int UserID);
        Task<GameModel> GetGameByID(int GameID);
        Task<List<GameNews>> GetNewsByID(int GameID);
        Task<List<GameReview>> GetReviewsByID(int GameID);
        Task<List<GameScreenshot>> GetScreenshotsByID(int GameID);
        Task<List<GameTrailer>> GetTrailersByID(int GameID);
        Task<List<UserModel>> GetUsersByGame(int GameID, int UserID);
        Task<List<FriendshipModel>> GetPendingFriends(int UserID);

        Task<ImageModel> PostImage(ImageModel image, int UserID);
        Task<GameModel> PostDislikedGame(int UserID, int GameID);
        Task<GameModel> PostLikedGame(int UserID, int GameID);
        Task<FriendshipModel> PostRemoveFriend(int UserID, int FriendID);
        Task<UserModel> PostAddFriend(int UserID, int FriendID);
        Task<UserModel> PutAcceptFriend(int UserID, int FriendID);

        /// NOTE: THIS IS FOR ADMIN USE ONLY. USERS CANT ADD GAMES
        Task<ImageModel> PostGameImage(ImageModel image, int GameID);
    }
}
