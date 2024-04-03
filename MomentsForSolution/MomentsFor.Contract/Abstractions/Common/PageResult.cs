using Microsoft.EntityFrameworkCore;

namespace MomentsFor.Contract.Abstractions.Common
{
    public class PageResult<T>(List<T>? items, int pageIndex, int pageSize, int totalRecord)
    {
        public const int UPPER_PAGE_SIZE = 100;
        public const int DEFAULT_PAGE_SIZE = 10;
        public const int DEFAULT_PAGE_INDEX = 1;

        public List<T>? Items { get; } = items;
        public int PageIndex { get; } = pageIndex;
        public int PageSize { get; } = pageSize;
        public int TotalRecord { get; } = totalRecord;
        public int TotalPage { get; } = (int)Math.Ceiling(totalRecord / (double)pageSize);
        public bool HasNextPage => PageIndex < TotalPage;
        public bool HasPreviousPage => PageIndex > 1;

        public static async Task<PageResult<T>> CreateAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex <= 0 ? DEFAULT_PAGE_INDEX : pageIndex;
            pageSize = pageSize <= 0 ? DEFAULT_PAGE_SIZE : pageSize > UPPER_PAGE_SIZE ? UPPER_PAGE_SIZE : pageSize;

            var count = await query.CountAsync();
            var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new(result, pageIndex, pageSize, count);
        }

        public static PageResult<T> Create(List<T> items, int pageIndex, int pageSize, int totalRecord)
            => new(items, pageIndex, pageSize, totalRecord);
    }
}
