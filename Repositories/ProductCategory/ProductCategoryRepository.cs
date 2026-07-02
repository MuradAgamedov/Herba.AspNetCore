using AutoMapper;
using Herba.Context;
using Herba.Dtos.ProductCategory.Item;
using Herba.Dtos.Common;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.ProductCategory
{
    using Herba.Dtos.ProductCategory.Translation;
    using Herba.Entities.ProductCategory;

    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductCategoryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateProductCategoryDto dto)
        {
            var slugExists = await _context.ProductCategories.AnyAsync(x => x.Slug == dto.Slug);
            if (slugExists) throw new ArgumentException($"'{dto.Slug}' slug-ı artıq mövcuddur, başqa slug seçin");

            var value = _mapper.Map<ProductCategory>(dto);
            var lastOrder = await _context.ProductCategories.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;
            await _context.ProductCategories.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultProductCategoryDto>> GetAllAsync(ProductCategoryFilterDto dto)
        {
            var query = _context.ProductCategories
                .Include(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Search))
            {
                query = query.Where(x => x.Translations.Any(t => t.Name.Contains(dto.Search)));
            }

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultProductCategoryDto>
            {
                Items = _mapper.Map<List<ResultProductCategoryDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<GetByIdProductCategoryDto?> GetById(int id)
        {
            var value = await _context.ProductCategories
               .Include(x => x.Translations)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<GetByIdProductCategoryDto>(value);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.ProductCategories
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _context.ProductCategories.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateAsync(int id, UpdateProductCategoryDto dto)
        {
            var value = await _context.ProductCategories
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }

            var slugExists = await _context.ProductCategories.AnyAsync(x => x.Slug == dto.Slug && x.Id != id);
            if (slugExists) throw new ArgumentException($"'{dto.Slug}' slug-ı artıq mövcuddur, başqa slug seçin");

            value.Slug = dto.Slug;
            value.Icon = dto.Icon;
            value.Status = dto.Status;

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new ProductCategoryTranslation
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
            var affectedRows = await _context.ProductCategories.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
