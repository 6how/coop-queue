using System;
using System.Collections.Generic;
using System.Text;

namespace CoQ.Models.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserDescription { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public int? ImageID { get; set; }
    }
}
