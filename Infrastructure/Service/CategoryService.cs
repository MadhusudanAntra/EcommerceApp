using ApplicationCore;
using ApplicationCore.Entities;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository repo)
        {
            categoryRepository = repo;
        }


        public int DeleteCategory(int id)
        {
            return categoryRepository.Delete(id);
        }

        public IEnumerable<CategoryResponseModel> GetAllCategories()
        {
            List<CategoryResponseModel> lst= new List<CategoryResponseModel>();
            var collection = categoryRepository.GetAll();
            if(collection != null)
            {
                foreach (var item in collection)
                {
                    CategoryResponseModel m = new CategoryResponseModel();
                    m.Id= item.Id;
                    m.CategoryName = item.CategoryName;
                    lst.Add(m);
                }
                return lst;
            }
            return null;
        }

        public CategoryResponseModel GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category != null)
            {
             CategoryResponseModel categoryResponseModel = new CategoryResponseModel();
                categoryResponseModel.Id = category.Id;
                categoryResponseModel.CategoryName = category.CategoryName;
                return categoryResponseModel;
            }
            return null;
        }

        public int InsertCategory(CategoryRequestModel category)
        {
            Category c = new Category() {
                CategoryName = category.CategoryName,
                Id=category.Id
            };

           return categoryRepository.Insert(c);
        }

        public int UpdateCategory(CategoryRequestModel category)
        {
            Category c = new Category() { 
            Id=category.Id,
            CategoryName = category.CategoryName
            };
            return categoryRepository.Update(c);
        }
    }
}
