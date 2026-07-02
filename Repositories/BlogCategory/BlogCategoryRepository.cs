
using AutoMapper;
using Herba.Context;
using Herba.Dtos.BlogCategory.Category;
using Herba.Dtos.Category;
using Microsoft.EntityFrameworkCore;
using Herba.Dtos.Common;
namespace Herba.Repositories.BlogCategory
{
    using Herba.Dtos.BlogCategory.Translation;
    using Herba.Dtos.Common;
    using Herba.Entities.BlogCategory;
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogCategoryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateBlogCategoryDto dto)
        {
            var value = _mapper.Map<BlogCategory>(dto);
            var lastOrder = await _context.BlogCategories.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;
            await _context.BlogCategories.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultBlogCategoryDto>> GetAllAsync(BlogCategoryFilterDto dto)
        {
            var query = _context.BlogCategories
                .Include(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            if(!string.IsNullOrEmpty(dto.Search))
            {
                query = query.Where(x=>x.Translations.Any(t=>t.Name.Contains(dto.Search)));
            }

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultBlogCategoryDto>
            {
                Items = _mapper.Map<List<ResultBlogCategoryDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<GetByIdBlogCategoryDto?> GetById(int id)
        {
            var value = await _context.BlogCategories
               .Include(x => x.Translations)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<GetByIdBlogCategoryDto>(value);

        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.BlogCategories
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _context.BlogCategories.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateAsync(int id, UpdateBlogCategoryDto dto)
        {
            var value = await _context.BlogCategories
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new BlogCategoryTranslation
                    {
                        Name = translationDto.Name,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Name = translationDto.Name;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var affectedRows = await _context.BlogCategories.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
