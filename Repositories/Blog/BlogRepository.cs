using AutoMapper;
using Herba.Context;
using Herba.Dtos.Blog.Post;
using Herba.Dtos.Category;
using Herba.Dtos.Common;
using Herba.Services.File;
using Microsoft.EntityFrameworkCore;

namespace Herba.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;


        public BlogRepository(IMapper mapper, AppDbContext context, IFileService fileService)
        {
            _mapper = mapper;
            _context = context;
            _fileService = fileService;

        }

        public async Task CreateAsync(CreateBlogDto dto)
        {
            var slugExists = await _context.Blogs.AnyAsync(x => x.Slug == dto.Slug);
            if (slugExists) throw new ArgumentException($"'{dto.Slug}' slug-ı artıq mövcuddur, başqa slug seçin");
            var value = _mapper.Map<Herba.Entities.Blog.Blog>(dto);
            if (dto.ImageFile != null)
            {
                value.Image = await _fileService.SaveFileAsync(dto.ImageFile, "blogs");
            }

            await _context.Blogs.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResultDto<ResultBlogDto>> GetAsync(BlogFilterDto dto)
        {
            var query = _context.Blogs
           .Include(x => x.Translations)
           .OrderBy(x => x.PublishedAt)
           .AsQueryable();

            if (!string.IsNullOrEmpty(dto.Search))
            {
                query = query.Where(x => x.Translations.Any(t => t.Title.Contains(dto.Search)));
            }
            var totalCount = await query.CountAsync();
            var values = await query
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToListAsync();

            return new PaginatedResultDto<ResultBlogDto>
            {
                Items = _mapper.Map<List<ResultBlogDto>>(values),
                TotalCount = totalCount,
                Page = dto.Page,
                Take = dto.Take,
                TotalPages = (int)Math.Ceiling(totalCount / (double)dto.Take)
            };
        }

        public async Task<GetByIdBlogDto?> GetById(int id)
        {
            var value = await _context.Blogs
               .Include(x => x.Translations)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            return _mapper.Map<GetByIdBlogDto>(value);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateBlogDto dto)
        {
            var value = await _context.Blogs
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            var slugExists = await _context.Blogs.AnyAsync(x => x.Slug == dto.Slug && x.Id != id);

            if (slugExists)  throw new ArgumentException($"'{dto.Slug}' slug-ı artıq mövcuddur, başqa slug seçin");

            if (dto.ImageFile != null)
            {
                _fileService.DeleteFile(value.Image); 
                value.Image = await _fileService.SaveFileAsync(dto.ImageFile, "blogs");
            }

            value.Slug = dto.Slug;
            value.ReadMinutes = dto.ReadMinutes;
            value.PublishedAt = dto.PublishedAt;
            value.Status = dto.Status;

            foreach (var translationDto in dto.Translations)
            {
                var translation = value.Translations.FirstOrDefault(x => x.LanguageCode == translationDto.LanguageCode);
                if (translation == null)
                {
                    value.Translations.Add(new Herba.Entities.Blog.BlogTranslation
                    {
                        Title = translationDto.Title,
                        ShortDescription = translationDto.ShortDescription,
                        Author = translationDto.Author,
                        Description = translationDto.Description,
                        SeoTitle = translationDto.SeoTitle,
                        SeoKeywords = translationDto.SeoKeywords,
                        SeoDescription = translationDto.SeoDescription,
                        ImageAltText = translationDto.ImageAltText,
                        LanguageCode = translationDto.LanguageCode
                    });
                }
                else
                {
                    translation.Title = translationDto.Title;
                    translation.ShortDescription = translationDto.ShortDescription;
                    translation.Author = translationDto.Author;
                    translation.Description = translationDto.Description;
                    translation.SeoTitle = translationDto.SeoTitle;
                    translation.SeoKeywords = translationDto.SeoKeywords;
                    translation.SeoDescription = translationDto.SeoDescription;
                    translation.ImageAltText = translationDto.ImageAltText;
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var value = await _context.Blogs
            .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
            {
                return null;
            }
            _fileService.DeleteFile(value.Image);
            _context.Blogs.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            var images = await _context.Blogs
             .Where(x => ids.Contains(x.Id))
             .Select(x => x.Image)
             .ToListAsync();

            foreach (var image in images)
            {
                _fileService.DeleteFile(image);
            }

            var affectedRows = await _context.Blogs.Where(x => ids.Contains(x.Id)).ExecuteDeleteAsync();

            return affectedRows > 0;
        }
    }
}
