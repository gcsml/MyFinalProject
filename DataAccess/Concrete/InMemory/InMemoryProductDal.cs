using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
       
        //construckter= bellekte referans aldığı zaman çalışacak olan blok
        public InMemoryProductDal()
        {       //Burda aslında Oracle,Sql server, Postgres den geliyomuş gibii simüle ediyoruz.
            _products = new List<Product> {
                new Product { CategoryId = 1, ProductId = 1, ProductName = "Bardak", UnitPrice = 15 ,UnitsInStock = 15 },
                new Product { CategoryId = 2, ProductId = 2, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                new Product { CategoryId = 3, ProductId = 3, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
                new Product { CategoryId = 4, ProductId = 4, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
                new Product { CategoryId = 5, ProductId = 5, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 },

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
          /*  Product productToDelete;
              foreach (var p in _products)                // gönderdiğim tüm elemanları dolaş eğer ıd eşitse sil
                if (product.ProductId == p.ProductId)   // bunun yerine LINQ(Language Intergrated Query)  kullanılır bize filtreleme sağlar 
                {
                    productToDelete = p;
                } */                                    //her p için 
           Product productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);                



            _products.Remove(productToDelete);
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public List<ProductDetailDto> GetProdductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
          //gönderdiğim ürün id'sine sahip olan listedeki ürünü  bul demek
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //güncellemeler
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
