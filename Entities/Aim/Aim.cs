namespace Herba.Entities.Aim
{
    public class Aim
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<AimTranslation> Translations { get; set; }
    }
}
