using Business.Abstract;
using Business.Constans;
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
                return new ErrorResult(Messages.ProductNameInvalidid);
            }

            _productDal.Add(product);

            return new Result(true, Messages.ProductAdded);
        }

        public IDateResult<Product> GetAll()
        {
          //İş kodları
          //yetkisi var mı vs if ile kontrol edebilirim
          return new DataResult.GetAll();  
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
