using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.AdminApp.Models.Services;
using eShopSolution.ViewModels.Catalog.Products.Manage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static eShopSolutionUtilities.Constants.SystemConstants;

namespace eShopSolution.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        public ProductController(IProductApiClient productApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index (string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(AppSettings.DefaultLanguageId);

            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };
            var data = await _productApiClient.GetPaging(request);
            ViewBag.Keyword = keyword;
            if(TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phầm thất bại");
            return View(request);
        }
    }
}
