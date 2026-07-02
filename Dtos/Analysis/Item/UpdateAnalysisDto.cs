using Herba.Dtos.Analysis.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Analysis.Item
{
    public class UpdateAnalysisDto
    {
        public IFormFile? IconFile { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<UpdateAnalysisTranslationDto> Translations { get; set; }
    }
}
