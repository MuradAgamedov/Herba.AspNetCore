using Herba.Dtos.Aim.Translation;

namespace Herba.Dtos.Aim.Item
{
    public class ResultAimDto
    {
        public int Id { get; set; }
        public string? IconUrl { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultAimTranslationDto> Translations { get; set; }
    }
}
