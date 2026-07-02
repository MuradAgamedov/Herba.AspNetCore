namespace Herba.Entities.Testimonial
{
    public class TestimonialTranslation
    {
        public int Id { get; set; }
        public string Quote { get; set; }
        public string Role { get; set; }
        public string LanguageCode { get; set; }
        public int TestimonialId { get; set; }
        public Testimonial Testimonial { get; set; }
    }
}
