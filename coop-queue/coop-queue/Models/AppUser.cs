using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoQ.Web.Models
{
    public class AppUser : IdentityUser<int>
    {  
        public string UserDescription { get; set; }

        public int UserImageID { get; set; }
    }
}
