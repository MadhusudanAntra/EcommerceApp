using ApplicationCore;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace Training.Ecommerce.MvcApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            this._categoryService = _categoryService;
        }


        public IActionResult Index()
        {
            var collection = _categoryService.GetAllCategories();
            return View(collection);
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.InsertCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var item = _categoryService.GetCategoryById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(CategoryResponseModel model)
        {
            _categoryService.DeleteCategory(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _categoryService.GetCategoryById(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(CategoryResponseModel model)
        { 
          if(ModelState.IsValid)
            {
                CategoryRequestModel c = new CategoryRequestModel();
                c.Id = model.Id;
                c.CategoryName=model.CategoryName;
                _categoryService.UpdateCategory(c);
                return RedirectToAction("Index");
            }
          return View(model);
        
        }



    }
}
