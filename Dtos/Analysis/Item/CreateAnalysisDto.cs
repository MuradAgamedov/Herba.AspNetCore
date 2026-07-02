using Herba.Dtos.Analysis.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Analysis.Item
{
    public class CreateAnalysisDto
    {
        public IFormFile? IconFile { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public ICollection<UpdateAnalysisTranslationDto> Translations { get; set; }
    }
}
