using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products.Manage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products.Public;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuanity);
        Task AddViewCount(int productId);
        Task<int> Delete(int productId);
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImages(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImages(int imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<ProductImageViewModel> GetImageById(int imageId);

        public Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll(string languageId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        public Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);
        public Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);
    }
}
