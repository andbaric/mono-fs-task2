using System.Collections.Generic;

namespace Project.Common.Paging
{
    public interface IPagedList<T> : IList<T>
    {
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get;}
        public int ItemsCount { get; }

        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
    }
}
