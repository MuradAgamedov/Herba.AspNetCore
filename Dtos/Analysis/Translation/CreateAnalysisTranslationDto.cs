using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Analysis.Translation
{
    public class CreateAnalysisTranslationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ButtonText { get; set; }
        public string? IconAltText { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public int AnalysisId { get; set; }
    }
}
