using AutoMapper;
using Herba.Context;
using Herba.Dtos.Product.Item;
using Herba.Dtos.Common;
using Herba.Services.File;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public ProductRepository(IMapper mapper, AppDbContext context, IFileService fileService)
        {
            _mapper = mapper;
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var slugExists = await _context.Products.AnyAsync(x => x.Slug == dto.Slug);
            if (slugExists) throw new ArgumentException($"'{dto.Slug}' slug-ı artıq mövcuddur, başqa slug seçin");

            var categoryExists = await _context.ProductCategories.AnyAsync(x => x.Id == dto.ProductCategoryId);
            if (!categoryExists) throw new ArgumentException("Seçilmiş məhsul kateqoriyası mövcud deyil");

            var value = _mapper.Map<Herba.Entities.Product.Product>(dto);
            var lastOrder = await _context.Products.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;

            if (dto.ImageFile != null)
            {
                value.Image = await _fileService.SaveFileAsync(dto.ImageFile, "products");
            }

            if (dto.HoverImageFile != null)
            {
                value.HoverImage = await _fileService.SaveFileAsync(dto.HoverImageFile, "products");
            }

            await _context.Products.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultProductDto>> GetAsync(ProductFilterDto dto)
        {
            var query = _context.Products
                .Include(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Search))
            {
                query = query.Where(x => x.Translations.Any(t => t.Name.Contains(dto.Search)));
            }

            if (dto.ProductCategoryId.HasValue)
            {
                query = query.Where(x => x.ProductCategoryId == dto.ProductCategoryId.Value);
            }

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultProductDto>
            {
                Items = _mapper.Map<List<ResultProductDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<GetByIdProductDto?> GetById(int id)
        {
            var value = await _context.Products
               .Include(x => x.Translations)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateProductDto dto)
        {
            var value = await _context.Products
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }

            var slugExists = await _context.Products.AnyAsync(x => x.Slug == dto.Slug && x.Id != id);
            if (slugExists) throw new ArgumentException($"'{dto.Slug}' slug-ı artıq mövcuddur, başqa slug seçin");

            var categoryExists = await _context.ProductCategories.AnyAsync(x => x.Id == dto.ProductCategoryId);
            if (!categoryExists) throw new ArgumentException("Seçilmiş məhsul kateqoriyası mövcud deyil");

            if (dto.ImageFile != null)
            {
                _fileService.DeleteFile(value.Image);
                value.Image = await _fileService.SaveFileAsync(dto.ImageFile, "products");
            }

            if (dto.HoverImageFile != null)
            {
                _fileService.DeleteFile(value.HoverImage);
                value.HoverImage = await _fileService.SaveFileAsync(dto.HoverImageFile, "products");
            }

            value.Slug = dto.Slug;
            value.ProductCategoryId = dto.ProductCategoryId;
            value.Status = dto.Status;

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new Herba.Entities.Product.ProductTranslation
                    {
                        Name = translationDto.Name,
                        ShortDescription = translationDto.ShortDescription,
                        Description = translationDto.Description,
                        ImageAltText = translationDto.ImageAltText,
                        HoverImageAltText = translationDto.HoverImageAltText,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Name = translationDto.Name;
                    translation.ShortDescription = translationDto.ShortDescription;
                    translation.Description = translationDto.Description;
                    translation.ImageAltText = translationDto.ImageAltText;
                    translation.HoverImageAltText = translationDto.HoverImageAltText;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _fileService.DeleteFile(value.Image);
            _fileService.DeleteFile(value.HoverImage);
            _context.Products.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var values = await _context.Products
                .Where(x => ids.Contains(x.Id))
                .Select(x => new { x.Image, x.HoverImage })
                .ToListAsync();

            foreach (var value in values)
            {
                _fileService.DeleteFile(value.Image);
                _fileService.DeleteFile(value.HoverImage);
            }

            var affectedRows = await _context.Products.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
