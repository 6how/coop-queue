using CoQ.Domain.Abstracts;
using CoQ.Domain.Entities;
using CoQ.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
        /// <summary>
        /// Gets a user account.
        /// </summary>
        public virtual DbSet<SPGetUserAccount> GetUserAccount { get; set; }

        /// <summary>
        /// Gets all of a user's friends.
        /// </summary>
        public virtual DbSet<FriendshipModel> GetUserFriends { get; set; }

        /// <summary>
        /// Gets all of a user's liked games.
        /// </summary>
        public virtual DbSet<LikedGameModel> GetLikedGames { get; set; }

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
    }
}
