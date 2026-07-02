using Herba.Dtos.Testimonial.Translation;

namespace Herba.Dtos.Testimonial.Item
{
    public class ResultTestimonialDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Rating { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultTestimonialTranslationDto> Translations { get; set; }
    }
}
