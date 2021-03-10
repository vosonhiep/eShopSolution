using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PageResult<ProductViewModel>> GetPaging(GetManageProductPagingRequest request);
        public Task<bool> CreateProduct(ProductCreateRequest request);
        //public Task<ApiResult<ProductViewModel>> GetById(Guid id);
        public Task<bool> UpdateProduct(ProductUpdateRequest request);
        //public Task<ApiResult<bool>> DeleteProduct(Guid id);
        public Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        public Task<ProductViewModel> GetById(int id, string languageId);
        public Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);
        public Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);
    }
}
