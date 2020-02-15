using System;
using System.ComponentModel.DataAnnotations;

namespace CoQ.Domain.Entities
{
    public class SPGetUserAccount
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string UserDescription { get; set; }

        public int? ImageID { get; set; }

        public string ImageName { get; set; }

        public Int64? FileSize { get; set; }

        public string Base64String { get; set; }

        public string ContentType { get; set; }
    }
}
