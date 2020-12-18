using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Common.Paging
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageSize, int pageNumber)
        {
            TotalPages = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int ItemsCount { get; private set; }

        public bool HasPreviousPage
        {
            get { return (CurrentPage > 1); }
        }
        public bool HasNextPage
        {
            get { return (CurrentPage < TotalPages); }
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> data, int pageSize, int pageNumber)
        {
            var count = await data.CountAsync();
            var items = await data
               .Skip(pageSize * (pageNumber - 1))
               .Take(pageSize)
               .ToListAsync();

            var pagedList = new PagedList<T>(items, count, pageSize, pageNumber);

            return pagedList;
        }
    }
}
