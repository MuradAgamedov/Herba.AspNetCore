using Herba.Dtos.Testimonial.Item;
using Herba.Dtos.Common;
using Herba.Repositories.Testimonial;

namespace Herba.Services.Testimonial
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<PaginatedResultDto<ResultTestimonialDto>> GetAllAsync(TestimonialFilterDto dto)
        {
            return await _testimonialRepository.GetAllAsync(dto);
        }

        public async Task CreateAsync(CreateTestimonialDto dto)
        {
            await _testimonialRepository.CreateAsync(dto);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateTestimonialDto dto)
        {
            return await _testimonialRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdTestimonialDto?> GetById(int id)
        {
            return await _testimonialRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _testimonialRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _testimonialRepository.DeleteRangeAsync(ids);
        }
    }
}
