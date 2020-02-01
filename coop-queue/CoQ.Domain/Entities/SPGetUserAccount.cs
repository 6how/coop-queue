using System;
using System.Collections.Generic;
using System.Text;

namespace CoQ.Domain.Entities
{
    public class SPGetUserAccount
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string ImageName { get; set; }

        public Int64? FileSize { get; set; }

        public string Blob { get; set; }

        public string ImageTypeName { get; set; }
    }
}
