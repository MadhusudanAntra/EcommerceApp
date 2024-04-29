using ApplicationCore.Entities;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Ecommerce.MvcApp.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ProductRequestModel, Product>().ReverseMap();
            //CreateMap<Product, ProductRequestModel>();
            CreateMap<ProductResponseModel, Product>().ReverseMap();

        }
    }
}
