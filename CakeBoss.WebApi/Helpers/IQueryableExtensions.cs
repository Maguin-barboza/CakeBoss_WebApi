using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CakeBoss.WebApi.Helpers
{
    public static class IQueryableExtensions
    {
        public async static Task<List<T>> Pagination<T>(this IQueryable<T> Iquery, HttpResponse response, PageConfig pageConfig)
        {
            int TotalItems = await Iquery.CountAsync();
            int TotalPages = (int)Math.Ceiling((double)(TotalItems / pageConfig.PageSize));
            
            List<T> registros = await Iquery.Skip((pageConfig.CurrentPage - 1) * pageConfig.PageSize).Take(pageConfig.PageSize).ToListAsync();
            AddPaginationHeader(response, pageConfig.CurrentPage, TotalItems, registros.Count, TotalPages);
            
            return registros;
        }

        private static void AddPaginationHeader(HttpResponse response, int currentPage, int totalItems, int totalItensInPage, int totalPages)
        {
            response.AddPagination(currentPage, totalItems, totalItensInPage, totalPages);
        }
    }
}