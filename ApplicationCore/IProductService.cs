using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public interface IProductService
    {
        int SaveProduct(ProductRequestModel model);
        IEnumerable<ProductResponseModel> GetAllProducts();
        ProductResponseModel GetProduct(int id);
    }
}
