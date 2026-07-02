using AutoMapper;
using Herba.Context;
using Herba.Dtos.About.Item;
using Herba.Services.File;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.About
{
    public class AboutRepository : IAboutRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public AboutRepository(IMapper mapper, AppDbContext context, IFileService fileService)
        {
            _mapper = mapper;
            _context = context;
            _fileService = fileService;
        }

        public async Task<ResultAboutDto?> GetAsync()
        {
            var value = await _context.Abouts
               .Include(x => x.Translations)
               .FirstOrDefaultAsync();
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<ResultAboutDto>(value);
        }

        public async Task<bool?> UpdateAsync(UpdateAboutDto dto)
        {
            var value = await _context.Abouts
                .Include(x => x.Translations)
                .FirstOrDefaultAsync();
            if (value == null)
            {
                return null;
            }

            if (dto.ImageFile != null)
            {
                _fileService.DeleteFile(value.Image);
                value.Image = await _fileService.SaveFileAsync(dto.ImageFile, "about");
            }

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new Herba.Entities.About.AboutTranslation
                    {
                        Title = translationDto.Title,
                        Description = translationDto.Description,
                        ImageAltText = translationDto.ImageAltText,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Title = translationDto.Title;
                    translation.Description = translationDto.Description;
                    translation.ImageAltText = translationDto.ImageAltText;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
