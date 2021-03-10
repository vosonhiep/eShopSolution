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
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }
        
        [Display(Name = "Giá")]
        public decimal Price { set; get; }

        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { get; set; }

        [Display(Name = "Số lượng trong kho")]
        public int Stock { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        public string Description { get; set; }

        [Display(Name = "Chi tiết")]
        public string Details { get; set; }
        
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public IFormFile ThumbnailImage { get; set; }
    }
}
