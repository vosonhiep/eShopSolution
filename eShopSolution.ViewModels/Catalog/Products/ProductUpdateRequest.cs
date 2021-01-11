﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products.Manage
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string Seotitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}