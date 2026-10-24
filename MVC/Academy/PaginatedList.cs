using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace Academy
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; private set; }
        public PaginatedList(List<T> items,int count, int pageIndex , int pageSize)
        {
            this.PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling((double)count / pageSize);
            AddRange(items);
        }
        public bool HasPreviusPage { get => PageIndex > 0; }
        public bool HasNextPage { get => PageIndex < TotalPages - 1; }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source , int pageIndex , int pageSize)  
        {
            int count = await source.CountAsync();
            return new PaginatedList<T>
                (
                    await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync() ,
                    count ,
                    pageIndex ,
                    pageSize
                );
        }

    }
}
