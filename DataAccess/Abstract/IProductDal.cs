using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    // Dal-dao =data access layer
    public interface IProductDal : IEntityRepository<Product>

    { 
    }
}

 