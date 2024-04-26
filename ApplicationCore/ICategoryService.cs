using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public interface ICategoryService
    {
        IEnumerable<CategoryResponseModel> GetAllCategories();
        int InsertCategory(CategoryRequestModel category);
        int UpdateCategory(CategoryRequestModel category);
        int DeleteCategory(int id);
        CategoryResponseModel GetCategoryById(int id);
    }
}
