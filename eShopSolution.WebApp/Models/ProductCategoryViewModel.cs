using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }
        public PageResult<ProductViewModel> Products { get; set; }
    }
}
