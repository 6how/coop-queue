using CoQ.Domain.Abstracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CoQ.Domain.Services
{
    public class CoQService
    {
        private readonly string userIdCacheKeyPrefix = "CurrentUser";

        public CoQService(ICoopQueue queue)
        {
            MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

            var key = $"{userIdCacheKeyPrefix}";
            if (!cache.TryGetValue(key, out int? userID))
            {
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                if (!String.IsNullOrWhiteSpace(EmailAddress))
                {
                    userID = queue.GetUserID(EmailAddress);
                    cache.Set(key, userID, options);
                }

                UserID = userID != null ? (int)userID : 0;
            }
        }

        public int UserID { get; set; }

        public string EmailAddress { get; set; }
    }
}

