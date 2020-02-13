using System.ComponentModel.DataAnnotations;

namespace CoQ.Models.Models
{
    public class ImageModel
    {
        [Key]
        public int? ImageID { get; set; }

        public string Name { get; set; }

        public long FileSize { get; set; }

        public string Base64String { get; set; }

        public string ContentType { get; set; }
    }
}
