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

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //yetkisi var mı vs if ile kontrol edebilirim

            if (DateTime.Now.Hour == 22) ;
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

          return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);  
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
             //her p için benim gönderdiğim category id ile eşitse onları filtrele
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p =>p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //iki fiya aralığında olan data
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int productId)
        {
           return new SuccessDataResult<Product> (_productDal.Get(p=>p.ProductId == productId ));
        }

        public IDataResult<List<ProductDetailDto>> GetProdductDetails()
        {
           return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProdductDetails());
        }
    }
}
