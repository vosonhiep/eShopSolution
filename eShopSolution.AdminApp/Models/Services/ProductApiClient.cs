using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products.Manage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Models.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {

        }

        public async Task<PageResult<ProductViewModel>> GetPaging(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PageResult<ProductViewModel>>($"/api/product/paging?pagiIndex={request.PageIndex}"
                + $"&pageSize={request.PageSize}" + $"&keyword={request.Keyword}&languageId={request.LanguageId}");

            return data;
        }
    }
}
