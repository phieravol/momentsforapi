using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MomentsFor.Contract.Abstractions.Common;

namespace MomentsFor.Application.DependencyInjection.Extensions
{
    public static class PaginationProfile
    {
        public static Task<PageResult<TDestination>> ToPaginationAsync<TDestination>(this IQueryable<TDestination> query, int pageIndex, int pageSize) where TDestination : class
            => PageResult<TDestination>.CreateAsync(query.AsNoTracking(), pageIndex, pageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable query, IConfigurationProvider configuration) where TDestination : class
            => query.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
    }
}
