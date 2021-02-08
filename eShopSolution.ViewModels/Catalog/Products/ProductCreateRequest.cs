using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products.Manage
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhận tên sản phẩm")]
        public string Name { get; set; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
