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
        /// Gets the user's identifier for caching. NOTE: Uses the email address entered.
        /// </summary>
        /// <param name="emailAddress">The email address used to verify</param>
        /// <returns>The user's identifer.</returns>
        int GetUserID(string emailAddress);

        SPCheckLoginCredentials GetCredentials(string enteredEmail, string enteredPassword);
    }
}
