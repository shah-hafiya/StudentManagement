namespace StudentManagement.Infrastructure
{
    public class PageInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public bool HasPrevPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}