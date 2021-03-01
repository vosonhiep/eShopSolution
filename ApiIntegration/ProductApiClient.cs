using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products.Manage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static eShopSolutionUtilities.Constants.SystemConstants;
using Newtonsoft.Json;
using System.Text;

namespace eShopSolution.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PageResult<ProductViewModel>> GetPaging(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PageResult<ProductViewModel>>($"/api/product/paging?pageIndex={request.PageIndex}"
                + $"&pageSize={request.PageSize}" 
                + $"&keyword={request.Keyword}&languageId={request.LanguageId}&categoryId={request.CategoryIds}");

            return data;
        }

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using(var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {

                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }

                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
            }

            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.Description.ToString()), "description");

            requestContent.Add(new StringContent(request.Details.ToString()), "details");
            requestContent.Add(new StringContent(request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/product/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/product/{id}/categories", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);

        }

        // Get product by id
        public async Task<ProductViewModel> GetById(int id, string languageId)
        {
            var data = await GetAsync<ProductViewModel>($"/api/product/{id}/{languageId}");

            return data;
        }

        public async Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductViewModel>($"/api/product/featured/{languageId}/{take}");
            return data;
        }

        public async Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductViewModel>($"/api/product/latest/{languageId}/{take}");
            return data;
        }
        //public Task<ApiResult<ProductViewModel>> GetById(Guid id, string languageId)
        //{
        //    var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri(_configuration["BaseAddress"]);
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
        //    var response = await client.GetAsync($"/api/product?productId={id}");
        //    var body = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return JsonConvert.DeserializeObject<ApiSuccessResult<UserViewModel>>(body);
        //    }
        //    return JsonConvert.DeserializeObject<ApiErrorResult<UserViewModel>>(body);
        //}


    }
}
