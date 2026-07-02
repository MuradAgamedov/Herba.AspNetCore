using AutoMapper;
using Herba.Context;
using Herba.Dtos.FeaturedProduct.Item;
using Herba.Dtos.Common;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.FeaturedProduct
{
    public class FeaturedProductRepository : IFeaturedProductRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public FeaturedProductRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateAsync(CreateFeaturedProductDto dto)
        {
            var productExists = await _context.Products.AnyAsync(x => x.Id == dto.ProductId);
            if (!productExists) throw new ArgumentException("Seçilmiş məhsul mövcud deyil");

            var alreadyFeatured = await _context.FeaturedProducts.AnyAsync(x => x.ProductId == dto.ProductId);
            if (alreadyFeatured) throw new ArgumentException("Bu məhsul artıq ən çox seçilənlər siyahısındadır");

            var value = _mapper.Map<Herba.Entities.FeaturedProduct.FeaturedProduct>(dto);
            var lastOrder = await _context.FeaturedProducts.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;

            await _context.FeaturedProducts.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultFeaturedProductDto>> GetAsync(FeaturedProductFilterDto dto)
        {
            var query = _context.FeaturedProducts
                .Include(x => x.Product)
                    .ThenInclude(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultFeaturedProductDto>
            {
                Items = _mapper.Map<List<ResultFeaturedProductDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.FeaturedProducts
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _context.FeaturedProducts.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var affectedRows = await _context.FeaturedProducts.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
