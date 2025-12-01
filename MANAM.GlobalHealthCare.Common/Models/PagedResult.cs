namespace MANAM.GlobalHealthCare.Common.Models
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; } = 0;
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;

        public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
