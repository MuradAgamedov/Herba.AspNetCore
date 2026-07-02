using Herba.Dtos.Aim.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Aim.Item
{
    public class UpdateAimDto
    {
        public IFormFile? IconFile { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<UpdateAimTranslationDto> Translations { get; set; }
    }
}
