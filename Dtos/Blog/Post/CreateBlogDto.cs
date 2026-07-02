using Herba.Dtos.Blog.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Blog.Post
{
    public class CreateBlogDto
    {
        [Required]
        public string Slug { get; set; }
        public int? ReadMinutes { get; set; }
        [Required]
        public DateTime PublishedAt { get; set; }
        public IFormFile? ImageFile { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public ICollection<UpdateBlogTranslationDto> Translations { get; set; }
    }
}
