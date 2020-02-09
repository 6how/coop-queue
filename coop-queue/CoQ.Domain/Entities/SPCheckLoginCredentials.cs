using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoQ.Domain.Entities
{
    public class SPCheckLoginCredentials
    {
        [Key]
        public int UserID { get; set; }

        public string EmailAddress { get; set; }
    }
}
