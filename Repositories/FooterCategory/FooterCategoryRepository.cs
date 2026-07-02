using AutoMapper;
using Herba.Context;
using Herba.Dtos.FooterCategory.Item;
using Herba.Dtos.Common;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.FooterCategory
{
    public class FooterCategoryRepository : IFooterCategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public FooterCategoryRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(CreateFooterCategoryDto dto)
        {
            var categoryExists = await _context.BlogCategories.AnyAsync(x => x.Id == dto.BlogCategoryId);
            if (!categoryExists) throw new ArgumentException("Seçilmiş bloq kateqoriyası mövcud deyil");

            var alreadyAdded = await _context.FooterCategories.AnyAsync(x => x.BlogCategoryId == dto.BlogCategoryId);
            if (alreadyAdded) throw new ArgumentException("Bu kateqoriya artıq footer siyahısındadır");

            var value = _mapper.Map<Herba.Entities.FooterCategory.FooterCategory>(dto);
            var lastOrder = await _context.FooterCategories.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;

            await _context.FooterCategories.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultFooterCategoryDto>> GetAsync(FooterCategoryFilterDto dto)
        {
            var query = _context.FooterCategories
                .Include(x => x.BlogCategory)
                    .ThenInclude(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultFooterCategoryDto>
            {
                Items = _mapper.Map<List<ResultFooterCategoryDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.FooterCategories
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _context.FooterCategories.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var affectedRows = await _context.FooterCategories.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
