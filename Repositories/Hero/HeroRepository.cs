using AutoMapper;
using Herba.Context;
using Herba.Dtos.Hero.Item;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.Hero
{
    public class HeroRepository : IHeroRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public HeroRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResultHeroDto?> GetAsync()
        {
            var value = await _context.Heroes
               .Include(x => x.Translations)
               .FirstOrDefaultAsync();
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<ResultHeroDto>(value);
        }

        public async Task<bool?> UpdateAsync(UpdateHeroDto dto)
        {
            var value = await _context.Heroes
                .Include(x => x.Translations)
                .FirstOrDefaultAsync();
            if (value == null)
            {
                return null;
            }

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new Herba.Entities.Hero.HeroTranslation
                    {
                        Badge = translationDto.Badge,
                        Title = translationDto.Title,
                        Description = translationDto.Description,
                        PrimaryButtonText = translationDto.PrimaryButtonText,
                        SecondaryButtonText = translationDto.SecondaryButtonText,
                        TrustBadge1 = translationDto.TrustBadge1,
                        TrustBadge2 = translationDto.TrustBadge2,
                        TrustBadge3 = translationDto.TrustBadge3,
                        SampleResultTitle = translationDto.SampleResultTitle,
                        Stat1Label = translationDto.Stat1Label,
                        Stat1Value = translationDto.Stat1Value,
                        Stat2Label = translationDto.Stat2Label,
                        Stat2Value = translationDto.Stat2Value,
                        Stat3Label = translationDto.Stat3Label,
                        Stat3Value = translationDto.Stat3Value,
                        RecommendationText = translationDto.RecommendationText,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Badge = translationDto.Badge;
                    translation.Title = translationDto.Title;
                    translation.Description = translationDto.Description;
                    translation.PrimaryButtonText = translationDto.PrimaryButtonText;
                    translation.SecondaryButtonText = translationDto.SecondaryButtonText;
                    translation.TrustBadge1 = translationDto.TrustBadge1;
                    translation.TrustBadge2 = translationDto.TrustBadge2;
                    translation.TrustBadge3 = translationDto.TrustBadge3;
                    translation.SampleResultTitle = translationDto.SampleResultTitle;
                    translation.Stat1Label = translationDto.Stat1Label;
                    translation.Stat1Value = translationDto.Stat1Value;
                    translation.Stat2Label = translationDto.Stat2Label;
                    translation.Stat2Value = translationDto.Stat2Value;
                    translation.Stat3Label = translationDto.Stat3Label;
                    translation.Stat3Value = translationDto.Stat3Value;
                    translation.RecommendationText = translationDto.RecommendationText;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
