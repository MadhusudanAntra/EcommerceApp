using ApplicationCore;
using ApplicationCore.Entities;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
                _repository = productRepository;
            _mapper = mapper;
        }
        public IEnumerable<ProductResponseModel> GetAllProducts()
        {
            var products = _repository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponseModel>>(products);
        }

        public ProductResponseModel GetProduct(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                return _mapper.Map<ProductResponseModel>(product);
            }
            return null;
        }

        public int SaveProduct(ProductRequestModel model)
        {
            var product = _mapper.Map<Product>(model);
            return _repository.Insert(product);
        }
    }
}
