using AutoMapper;
using Herba.Context;
using Herba.Dtos.Testimonial.Item;
using Herba.Dtos.Common;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.Testimonial
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestimonialRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateTestimonialDto dto)
        {
            var value = _mapper.Map<Herba.Entities.Testimonial.Testimonial>(dto);
            var lastOrder = await _context.Testimonials.MaxAsync(x => (int?)x.Order) ?? -1;
            value.Order = lastOrder + 1;
            await _context.Testimonials.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultTestimonialDto>> GetAllAsync(TestimonialFilterDto dto)
        {
            var query = _context.Testimonials
                .Include(x => x.Translations)
                .OrderBy(x => x.Order)
                .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Search))
            {
                query = query.Where(x => x.CustomerName.Contains(dto.Search) || x.Translations.Any(t => t.Quote.Contains(dto.Search)));
            }

            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultTestimonialDto>
            {
                Items = _mapper.Map<List<ResultTestimonialDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<GetByIdTestimonialDto?> GetById(int id)
        {
            var value = await _context.Testimonials
               .Include(x => x.Translations)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<GetByIdTestimonialDto>(value);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.Testimonials
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _context.Testimonials.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateAsync(int id, UpdateTestimonialDto dto)
        {
            var value = await _context.Testimonials
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }

            value.CustomerName = dto.CustomerName;
            value.Rating = dto.Rating;
            value.Status = dto.Status;

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new Herba.Entities.Testimonial.TestimonialTranslation
                    {
                        Quote = translationDto.Quote,
                        Role = translationDto.Role,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Quote = translationDto.Quote;
                    translation.Role = translationDto.Role;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var affectedRows = await _context.Testimonials.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
