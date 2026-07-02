using AutoMapper;
using Herba.Context;
using Herba.Dtos.Analysis.Item;
using Herba.Dtos.Common;
using Herba.Services.File;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.Analysis
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public AnalysisRepository(IMapper mapper, AppDbContext context, IFileService fileService)
        {
            _mapper = mapper;
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(CreateAnalysisDto dto)
        {
            var value = _mapper.Map<Herba.Entities.Analysis.Analysis>(dto);
            var lastOrder = await _context.Analyses.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;

            if (dto.IconFile != null)
            {
                value.Icon = await _fileService.SaveFileAsync(dto.IconFile, "analyses");
            }

            await _context.Analyses.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultAnalysisDto>> GetAsync(AnalysisFilterDto dto)
        {
            var query = _context.Analyses
                .Include(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Search))
            {
                query = query.Where(x => x.Translations.Any(t => t.Title.Contains(dto.Search)));
            }

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultAnalysisDto>
            {
                Items = _mapper.Map<List<ResultAnalysisDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<GetByIdAnalysisDto?> GetById(int id)
        {
            var value = await _context.Analyses
               .Include(x => x.Translations)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<GetByIdAnalysisDto>(value);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateAnalysisDto dto)
        {
            var value = await _context.Analyses
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }

            if (dto.IconFile != null)
            {
                _fileService.DeleteFile(value.Icon);
                value.Icon = await _fileService.SaveFileAsync(dto.IconFile, "analyses");
            }

            value.Url = dto.Url;
            value.Status = dto.Status;

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new Herba.Entities.Analysis.AnalysisTranslation
                    {
                        Title = translationDto.Title,
                        Description = translationDto.Description,
                        ButtonText = translationDto.ButtonText,
                        IconAltText = translationDto.IconAltText,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Title = translationDto.Title;
                    translation.Description = translationDto.Description;
                    translation.ButtonText = translationDto.ButtonText;
                    translation.IconAltText = translationDto.IconAltText;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.Analyses
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _fileService.DeleteFile(value.Icon);
            _context.Analyses.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var icons = await _context.Analyses
                .Where(x => ids.Contains(x.Id))
                .Select(x => x.Icon)
                .ToListAsync();

            foreach (var icon in icons)
            {
                _fileService.DeleteFile(icon);
            }

            var affectedRows = await _context.Analyses.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
