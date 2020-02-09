using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoQ.Models.Models
{
    public class CacheUserIDModel
    {
        [Key]
        public int UserID { get; set; }
    }
}
