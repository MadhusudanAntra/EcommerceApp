using ApplicationCore;
using ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Training.Ecommerce.MvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _productService = service;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllCategories().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.SaveProduct(model);
                return RedirectToAction("Index");
            }


            ViewBag.Categories = _categoryService.GetAllCategories().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            });

            return View(model);
        }
    }

}
