using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            if(product.ProductName.Length<2)
            {
                return new ErrorResult("Ürün ismi en az 2 karakter olmalırdır");
            }

            _productDal.Add(product);

            return new Result(true,"Ürün eklendi");
        }

        public List<Product> GetAll()
        {
          //İş kodları
          //yetkisi var mı vs if ile kontrol edebilirim
          return _productDal.GetAll();  
        }

        public List<Product> GetAllByCategoryId(int id)
        {
             //her p için benim gönderdiğim category id ile eşitse onları filtrele
            return _productDal.GetAll(p =>p.CategoryId == id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            //iki fiya aralığında olan data
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public Product GetById(int productId)
        {
           return _productDal.Get(p=>p.ProductId == productId );
        }

        public List<ProductDetailDto> GetProdductDetails()
        {
           return _productDal.GetProdductDetails();
        }
    }
}
