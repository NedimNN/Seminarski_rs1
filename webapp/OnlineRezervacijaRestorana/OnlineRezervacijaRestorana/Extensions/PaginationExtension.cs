using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Online_Rezervacija_Restorana.Models;
using Online_Rezervacija_Restorana.Utilities;

namespace Online_Rezervacija_Restorana.Extensions
{
    public static class PaginationExtension
    {
        public static PagedResult<TEntity> GetPaged<TEntity>(this IQueryable<TEntity> query, int page, int pageSize) where TEntity : class, IEntity
        {
            var result = new PagedResult<TEntity>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
