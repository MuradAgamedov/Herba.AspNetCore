using Herba.Services.File;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Herba.Services.Files  
{
    public class FileService : IFileService
    {
        private readonly string _webRootPath;

        public FileService(IWebHostEnvironment env)
        {
            _webRootPath = env.WebRootPath
                ?? Path.Combine(env.ContentRootPath, "wwwroot");

            if (!Directory.Exists(_webRootPath))
                Directory.CreateDirectory(_webRootPath);
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Fayl boşdur");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Yalnız jpg, jpeg, png, webp formatları qəbul olunur");

            if (file.Length > 5 * 1024 * 1024)
                throw new ArgumentException("Fayl ölçüsü 5MB-dan çox ola bilməz");

            var uploadsFolder = Path.Combine(_webRootPath, "uploads", folder);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{folder}/{fileName}";
        }

        public void DeleteFile(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return;

            var fullPath = Path.Combine(_webRootPath, filePath.TrimStart('/'));

            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);
        }
    }
}