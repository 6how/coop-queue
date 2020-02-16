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
        
        /// <summary>
        /// Gets a user account for the profile page.
        /// </summary>
        /// <param name="UserID">User's identifier.</param>
        /// <returns>The user's account object.</returns>
        Task<SPGetUserAccount> GetUserProfile(int UserID);

        /// <summary>
        /// Gets all friends for a user.
        /// </summary>
        /// <param name="UserID">User's identifier.</param>
        /// <returns>IEnumerable of user's friends.</returns>
        Task<List<FriendshipModel>> GetUserFriend(int UserID);

        /// <summary>
        /// Gets all games a user liked.
        /// </summary>
        /// <param name="UserID">The user's identifier.</param>
        /// <returns>A list of all the user's liked games.</returns>
        Task<List<LikedGameModel>> GetLikedGame(int UserID);

        /// <summary>
        /// Gets all games that will show up on the user's feed.
        /// </summary>
        /// <param name="UserID">The user's identifier.</param>
        /// <returns>A list of all the user's liked games.</returns>
        Task<List<GameModel>> GetFeedGame(int UserID);

        /// <summary>
        /// Gets a game based off an ID.
        /// </summary>
        /// <param name="GameID">The ID of the game to get.</param>
        /// <returns>The GameModel object of the game.</returns>
        Task<GameModel> GetGameByID(int GameID);

        /// <summary>
        /// Gets all news for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of news for the given game.</returns>
        Task<List<GameNews>> GetNewsByID(int GameID);

        /// <summary>
        /// Gets all reviews for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of reviews for the given game.</returns>
        Task<List<GameReview>> GetReviewsByID(int GameID);

        /// <summary>
        /// Gets all screenshots for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of screenshots for the given game.</returns>
        Task<List<GameScreenshot>> GetScreenshotsByID(int GameID);

        /// <summary>
        /// Gets all trailers for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of trailers for the given game.</returns>
        Task<List<GameTrailer>> GetTrailersByID(int GameID);

        /// <summary>
        /// Posts an uploaded image.
        /// </summary>
        /// <param name="image">The object of the image to post.</param>
        /// <returns>The image object.</returns>
        Task<ImageModel> PostImage(ImageModel image, int UserID);

        /// <summary>
        /// Posts the disliked game.
        /// </summary>
        /// <param name="UserID">The user who disliked the game.</param>
        /// <param name="GameID">The id of the game.</param>
        /// <returns>The GameModel of the disliked game.</returns>
        Task<GameModel> PostDislikedGame(int UserID, int GameID);

        /// <summary>
        /// Posts the Liked game.
        /// </summary>
        /// <param name="UserID">The user who Liked the game.</param>
        /// <param name="GameID">The id of the game.</param>
        /// <returns>The GameModel of the Liked game.</returns>
        Task<GameModel> PostLikedGame(int UserID, int GameID);

        /// <summary>
        /// NOTE: THIS IS FOR ADMIN USE ONLY. USERS CANT ADD GAMES
        /// </summary>
        /// <param name="image"></param>
        /// <param name="GameID"></param>
        /// <returns></returns>
        Task<ImageModel> PostGameImage(ImageModel image, int GameID);
    }
}
