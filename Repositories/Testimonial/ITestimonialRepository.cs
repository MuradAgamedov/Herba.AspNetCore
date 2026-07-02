using Herba.Dtos.Testimonial.Item;
using Herba.Dtos.Common;

namespace Herba.Repositories.Testimonial
{
    public interface ITestimonialRepository
    {
        Task<PaginatedResultDto<ResultTestimonialDto>> GetAllAsync(TestimonialFilterDto dto);
        Task CreateAsync(CreateTestimonialDto dto);
        Task<bool?> UpdateAsync(int id, UpdateTestimonialDto dto);
        Task<GetByIdTestimonialDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
