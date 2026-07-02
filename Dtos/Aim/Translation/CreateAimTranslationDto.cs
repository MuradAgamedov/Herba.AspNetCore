using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Aim.Translation
{
    public class CreateAimTranslationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? IconAltText { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public int AimId { get; set; }
    }
}
