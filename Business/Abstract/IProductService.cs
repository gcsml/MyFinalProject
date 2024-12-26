using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDateResult<List<Product>> GetAll();
        IDateResult<List<Product>> GetAllByCategoryId(int id);

        IDateResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);

        IDateResult<List<ProductDetailDto>> GetProdductDetails();
        IDateResult<Product> GetById(int productId);

        IResult Add(Product product);
    }
}
