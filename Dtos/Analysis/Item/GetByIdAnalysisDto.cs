using Herba.Dtos.Analysis.Translation;

namespace Herba.Dtos.Analysis.Item
{
    public class GetByIdAnalysisDto
    {
        public int Id { get; set; }
        public string? IconUrl { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultAnalysisTranslationDto> Translations { get; set; }
    }
}
