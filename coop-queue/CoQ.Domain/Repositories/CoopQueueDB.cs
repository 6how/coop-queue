using CoQ.Domain.Abstracts;
using CoQ.Domain.Entities;
using CoQ.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CoQ.Domain.Repositories
{
    public class CoopQueueDB : DbContext, ICoopQueue
    {
        public CoopQueueDB(DbContextOptions<CoopQueueDB> options) : base(options)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CoQ");
        }

        #region DbSets

        public virtual DbSet<SPGetUserAccount> GetUserAccount { get; set; }

        public virtual DbSet<FriendshipModel> GetUserFriends { get; set; }

        public virtual DbSet<LikedGameModel> GetLikedGames { get; set; }

        public virtual DbSet<GameModel> GetFeedGames { get; set; }
        
        public virtual DbSet<GameModel> GetGames { get; set; }

        public virtual DbSet<GameNews> GetNews { get; set; }

        public virtual DbSet<GameReview> GetReviews { get; set; }

        public virtual DbSet<GameScreenshot> GetScreenshots { get; set; }

        public virtual DbSet<GameTrailer> GetTrailers { get; set; }

        public virtual DbSet<ImageModel> PostImages { get; set; }

        public virtual DbSet<GameModel> PostDislikedGames { get; set; }

        public virtual DbSet<GameModel> PostLikedGames { get; set; }

        #endregion

        #region Gets

        /// <summary>
        /// Gets a user account for the profile page.
        /// </summary>
        /// <param name="UserID">User's identifier.</param>
        /// <returns>The user's account object.</returns>
        public async Task<SPGetUserAccount> GetUserProfile(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetUserAccount.FromSql("EXEC CoQ.GetUserAccount @UserID", userParam)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all friends for a user.
        /// </summary>
        /// <param name="UserID">User's identifier.</param>
        /// <returns>List of user's friends.</returns>
        public async Task<List<FriendshipModel>> GetUserFriend(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetUserFriends.FromSql("EXEC CoQ.GetFriendsList @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets all games a user liked.
        /// </summary>
        /// <param name="UserID">The user's identifier.</param>
        /// <returns>A list of all the user's liked games.</returns>
        public async Task<List<LikedGameModel>> GetLikedGame(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetLikedGames.FromSql("EXEC CoQ.GetLikedGamesByUser @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets all games that will show up on the user's feed.
        /// </summary>
        /// <param name="UserID">The user's identifier.</param>
        /// <returns>A list of all the user's liked games.</returns>
        public async Task<List<GameModel>> GetFeedGame(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetFeedGames.FromSql("EXEC CoQ.GetFeedForUser @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets a game based off an ID.
        /// </summary>
        /// <param name="GameID">The ID of the game to get.</param>
        /// <returns>The GameModel object of the game.</returns>
        public async Task<GameModel> GetGameByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetGames.FromSql("EXEC CoQ.GetGameByID @GameID", gameParam)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all news for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of news for the given game.</returns>
        public async Task<List<GameNews>> GetNewsByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetNews.FromSql("Exec CoQ.GetNewsByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets all reviews for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of reviews for the given game.</returns>
        public async Task<List<GameReview>> GetReviewsByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetReviews.FromSql("Exec CoQ.GetReviewsByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets all screenshots for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of screenshots for the given game.</returns>
        public async Task<List<GameScreenshot>> GetScreenshotsByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetScreenshots.FromSql("Exec CoQ.GetScreenshotsByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

                /// <summary>
        /// Gets all trailers for a game based off ID.
        /// </summary>
        /// <param name="GameID">The ID of the game.</param>
        /// <returns>A list of trailers for the given game.</returns>
        public async Task<List<GameTrailer>> GetTrailersByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetTrailers.FromSql("Exec CoQ.GetTrailersByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion

        #region Posts/Puts

        /// <summary>
        /// Posts an uploaded image.
        /// </summary>
        /// <param name="image">The object of the image to post.</param>
        /// <returns>The image object.</returns>
        public async Task<ImageModel> PostImage(ImageModel image, int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };
            SqlParameter nameParam = new SqlParameter { ParameterName = "@ImageName", SqlDbType = SqlDbType.NVarChar, Value = image.Name };
            SqlParameter sizeParam = new SqlParameter { ParameterName = "@ImageSize", SqlDbType = SqlDbType.Int, Value = image.FileSize };
            SqlParameter base64Param = new SqlParameter { ParameterName = "@ImageBase64", SqlDbType = SqlDbType.VarChar, Value = image.Base64String};
            SqlParameter contentParam = new SqlParameter { ParameterName = "@ContentType", SqlDbType = SqlDbType.NVarChar, Value = image.ContentType};

            return await PostImages.FromSql("EXEC CoQ.PostImage @UserID, @ImageName, @ImageSize, @ImageBase64, @ContentType",
                new[] { 
                    userParam,
                    nameParam,
                    sizeParam,
                    base64Param,
                    contentParam 
                }).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Posts the disliked game.
        /// </summary>
        /// <param name="UserID">The user who disliked the game.</param>
        /// <param name="GameID">The id of the game.</param>
        /// <returns>The GameModel of the disliked game.</returns>
        public async Task<GameModel> PostDislikedGame(int UserID, int GameID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await PostDislikedGames.FromSql("EXEC CoQ.PostDislikedGame @UserID, @GameID",
                new[] {
                    userParam,
                    gameParam
                }).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Posts the Liked game.
        /// </summary>
        /// <param name="UserID">The user who Liked the game.</param>
        /// <param name="GameID">The id of the game.</param>
        /// <returns>The GameModel of the Liked game.</returns>
        public async Task<GameModel> PostLikedGame(int UserID, int GameID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await PostLikedGames.FromSql("EXEC CoQ.PostLikedGame @UserID, @GameID",
                new[] {
                    userParam,
                    gameParam
                }).FirstOrDefaultAsync();
        }

        #endregion

        #region Admin Ignore

        /// <summary>
        /// NOTE: THIS IS FOR ADMIN USE ONLY. USERS CANT ADD GAMES
        /// </summary>
        /// <param name="image"></param>
        /// <param name="GameID"></param>
        /// <returns></returns>
        public async Task<ImageModel> PostGameImage(ImageModel image, int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };
            SqlParameter nameParam = new SqlParameter { ParameterName = "@ImageName", SqlDbType = SqlDbType.NVarChar, Value = image.Name };
            SqlParameter sizeParam = new SqlParameter { ParameterName = "@ImageSize", SqlDbType = SqlDbType.Int, Value = image.FileSize };
            SqlParameter base64Param = new SqlParameter { ParameterName = "@ImageBase64", SqlDbType = SqlDbType.VarChar, Value = image.Base64String };
            SqlParameter contentParam = new SqlParameter { ParameterName = "@ContentType", SqlDbType = SqlDbType.NVarChar, Value = image.ContentType };

            return await PostImages.FromSql("EXEC CoQ.PostImage @GameID, @ImageName, @ImageSize, @ImageBase64, @ContentType",
                new[] {
                    gameParam,
                    nameParam,
                    sizeParam,
                    base64Param,
                    contentParam
                }).FirstOrDefaultAsync();
        }

        #endregion
    }
}
