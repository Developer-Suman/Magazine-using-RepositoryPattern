using System.Reflection.Metadata.Ecma335;

namespace Megazine_Practice.Helper
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex  = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double) pageSize);
            this.AddRange(items);

        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int PageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * PageSize).Take(count).ToList();
            return new PaginatedList<T>(items, count, pageIndex, PageSize);
        }
    }
}
