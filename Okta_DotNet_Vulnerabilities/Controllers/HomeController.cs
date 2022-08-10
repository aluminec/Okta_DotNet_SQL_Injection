using Microsoft.AspNetCore.Mvc;
using Okta_DotNet_SQL_Injection.Models;
using Okta_DotNet_SQL_Injection.Services.Interfaces;

namespace Okta_DotNet_SQL_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;
        public HomeController(IProductService service) => _service = service;

        public IActionResult Index(string code = "")
        {
            var products = _service.Search(code);

            HomeViewModel model = new()
            {
                SearchProductCode = code,
                Products = products
            };

            return View(model);
        }
    }
}