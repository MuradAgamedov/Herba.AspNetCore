using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Blog.Translation
{
    public class CreateBlogTranslationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoKeywords { get; set; }
        public string? SeoDescription { get; set; }
        public string? ImageAltText { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}
