using Herba.Dtos.Blog.Translation;

namespace Herba.Dtos.Blog.Post
{
    public class GetByIdBlogDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public int BlogCategoryId { get; set; }
        public int? ReadMinutes { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultBlogTranslationDto> Translations { get; set; }
    }
}
