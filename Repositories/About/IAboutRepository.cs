using Herba.Dtos.About.Item;

namespace Herba.Repositories.About
{
    public interface IAboutRepository
    {
        Task<ResultAboutDto?> GetAsync();
        Task<bool?> UpdateAsync(UpdateAboutDto dto);
    }
}
