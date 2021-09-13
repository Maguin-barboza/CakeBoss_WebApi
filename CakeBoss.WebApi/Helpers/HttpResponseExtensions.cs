using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CakeBoss.WebApi.Helpers
{
    public static class HttpResponseExtensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int totalItems, int totalItemsInPage, int totalPages)
        {
            PaginationHeader pageHeader = new PaginationHeader(currentPage, totalItems, totalItemsInPage, totalPages);

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(pageHeader));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}