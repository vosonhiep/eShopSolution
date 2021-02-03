using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.System.Languages;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BeckendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var language = await _languageService.GetAll();

            return Ok(language);
        }
    }
}
