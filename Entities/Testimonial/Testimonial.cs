namespace Herba.Entities.Testimonial
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Rating { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<TestimonialTranslation> Translations { get; set; }
    }
}
