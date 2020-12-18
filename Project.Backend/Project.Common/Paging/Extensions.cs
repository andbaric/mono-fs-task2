using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Common.Paging
{
    public static class Extensions
    {
        public static PagedList<TDestination> ToMappedPagedList<TSource, TDestination>
            (this IPagedList<TSource> list, IMapper mapper)
        {
            IEnumerable<TDestination> sourceList = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            PagedList<TDestination> pagedResult = new PagedList<TDestination>(sourceList, list.Count, list.PageSize, list.CurrentPage);

            return pagedResult;
        }
    }
}
