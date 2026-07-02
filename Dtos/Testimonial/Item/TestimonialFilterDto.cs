using Herba.Dtos.Common;

namespace Herba.Dtos.Testimonial.Item
{
    public class TestimonialFilterDto : PaginationDto
    {
        public string? Search { get; set; }
    }
}
