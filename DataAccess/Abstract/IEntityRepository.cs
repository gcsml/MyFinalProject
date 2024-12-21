using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
        //generic constraint  // filreleme yapıyoruz 
     public  interface IEntityRepository<T> where T : class,IEntity,new() // T bir referans ipolmalı ve T IEntity olabilir yada ondan implemente olan birşeyden olabilir
                                                                     //burda class referans tip olacağı anlamına gelir
                                                                     //IEntity dahil emek isemiyorum oyüzden newlenemez olduğu için sonuna new() yazıyoruz böylece kesişimdençıkmış oluyor
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        T Get(Expression<Func<T, bool>> filter = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity); 

 
    }
}
