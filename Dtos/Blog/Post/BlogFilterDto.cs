using Herba.Dtos.Common;

namespace Herba.Dtos.Blog.Post
{
    public class BlogFilterDto : PaginationDto
    {
        public string? Search { get; set; }
    }
}
