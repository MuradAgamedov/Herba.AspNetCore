using Herba.Dtos.About.Item;

namespace Herba.Services.About
{
    public interface IAboutService
    {
        Task<ResultAboutDto?> GetAsync();
        Task<bool?> UpdateAsync(UpdateAboutDto dto);
    }
}
