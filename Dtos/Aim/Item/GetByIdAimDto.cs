using Herba.Dtos.Aim.Translation;

namespace Herba.Dtos.Aim.Item
{
    public class GetByIdAimDto
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultAimTranslationDto> Translations { get; set; }
    }
}
