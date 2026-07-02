using Herba.Dtos.Testimonial.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Testimonial.Item
{
    public class CreateTestimonialDto
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public ICollection<UpdateTestimonialTranslationDto> Translations { get; set; }
    }
}
