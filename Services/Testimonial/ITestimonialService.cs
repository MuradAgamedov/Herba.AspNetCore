using Herba.Dtos.Testimonial.Item;
using Herba.Dtos.Common;

namespace Herba.Services.Testimonial
{
    public interface ITestimonialService
    {
        Task<PaginatedResultDto<ResultTestimonialDto>> GetAllAsync(TestimonialFilterDto dto);
        Task CreateAsync(CreateTestimonialDto dto);
        Task<bool?> UpdateAsync(int id, UpdateTestimonialDto dto);
        Task<GetByIdTestimonialDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
