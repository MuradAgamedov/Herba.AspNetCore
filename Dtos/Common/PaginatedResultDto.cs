namespace Herba.Dtos.Common
{
    public class PaginatedResultDto<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Take { get; set; }
        public int TotalPages { get; set; }
    }
}
