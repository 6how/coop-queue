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

        public virtual DbSet<UserModel> GetUserByGame { get; set; }

        public virtual DbSet<FriendshipModel> GetPendingFriend { get; set; }

        public virtual DbSet<ImageModel> PostImages { get; set; }

        public virtual DbSet<GameModel> PostDislikedGames { get; set; }

        public virtual DbSet<GameModel> PostLikedGames { get; set; }

        public virtual DbSet<FriendshipModel> PostRemoveFriends { get; set; }

        public virtual DbSet<UserModel> PostAddFriends { get; set; }

        public virtual DbSet<UserModel> PostAcceptFriends { get; set; }

        #endregion

        #region Gets

        public async Task<SPGetUserAccount> GetUserProfile(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetUserAccount.FromSql("EXEC CoQ.GetUserAccount @UserID", userParam)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<FriendshipModel>> GetUserFriend(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetUserFriends.FromSql("EXEC CoQ.GetFriendsList @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<LikedGameModel>> GetLikedGame(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetLikedGames.FromSql("EXEC CoQ.GetLikedGamesByUser @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<GameModel>> GetFeedGame(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetFeedGames.FromSql("EXEC CoQ.GetFeedForUser @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<GameModel> GetGameByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetGames.FromSql("EXEC CoQ.GetGameByID @GameID", gameParam)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<GameNews>> GetNewsByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetNews.FromSql("Exec CoQ.GetNewsByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<GameReview>> GetReviewsByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetReviews.FromSql("Exec CoQ.GetReviewsByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<GameScreenshot>> GetScreenshotsByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetScreenshots.FromSql("Exec CoQ.GetScreenshotsByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<GameTrailer>> GetTrailersByID(int GameID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };

            return await GetTrailers.FromSql("Exec CoQ.GetTrailersByID @GameID", gameParam)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<UserModel>> GetUsersByGame(int GameID, int UserID)
        {
            SqlParameter gameParam = new SqlParameter { ParameterName = "@GameID", SqlDbType = SqlDbType.Int, Value = GameID };
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };


            return await GetUserByGame.FromSql("EXEC CoQ.GetUsersByGame @GameID, @UserID", 
                new[] {
                    gameParam,
                    userParam
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<FriendshipModel>> GetPendingFriends(int UserID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };

            return await GetPendingFriend.FromSql("EXEC CoQ.GetPendingFriends @UserID", userParam)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion

        #region Posts/Puts

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

        public async Task<FriendshipModel> PostRemoveFriend(int UserID, int FriendID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };
            SqlParameter friendParam = new SqlParameter { ParameterName = "@FriendID", SqlDbType = SqlDbType.Int, Value = FriendID };

            return await PostRemoveFriends.FromSql("EXEC CoQ.PostRemoveFriend @UserID, @FriendID",
                new[] {
                    userParam,
                    friendParam
                }).FirstOrDefaultAsync();
        }

        public async Task<UserModel> PostAddFriend(int UserID, int FriendID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };
            SqlParameter friendParam = new SqlParameter { ParameterName = "@FriendID", SqlDbType = SqlDbType.Int, Value = FriendID };

            return await PostAddFriends.FromSql("EXEC CoQ.PostAddFriend @UserID, @FriendID",
                new[]{
                    userParam,
                    friendParam
                }).FirstOrDefaultAsync();
        }

        public async Task<UserModel> PutAcceptFriend(int UserID, int FriendID)
        {
            SqlParameter userParam = new SqlParameter { ParameterName = "@UserID", SqlDbType = SqlDbType.Int, Value = UserID };
            SqlParameter friendParam = new SqlParameter { ParameterName = "@FriendID", SqlDbType = SqlDbType.Int, Value = FriendID };

            return await PostAcceptFriends.FromSql("EXEC CoQ.PutAcceptFriend @UserID, @FriendID",
                new[]{
                    userParam,
                    friendParam
                }).FirstOrDefaultAsync();
        }

        #endregion

        #region Admin Ignore

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
