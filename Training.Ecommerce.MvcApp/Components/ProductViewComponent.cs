using ApplicationCore;
using Microsoft.AspNetCore.Mvc;

namespace Training.Ecommerce.MvcApp.Components
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly IProductService service;
        public ProductViewComponent(IProductService productService)
        {
                service = productService;
        }

        public IViewComponentResult InvokeAsync()
        {
            return View(service.GetAllProducts().ToList());
        }
    }
}
