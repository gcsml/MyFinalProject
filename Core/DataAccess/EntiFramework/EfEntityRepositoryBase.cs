using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace Core.DataAccess.EntiFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class,IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using içinde yazılan nesneler using bitice anında bellekten silinir
            using (TContext context = new TContext())

            {
                var addedEntity = context.Entry(entity); //referansı yakala 
                addedEntity.State = EntityState.Added;   // o aslında eklenecek bir nesne
                context.SaveChanges();                   // ve şimdi ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())

            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null                                   // filtre null mı
                    ? context.Set<TEntity>().ToList()                   //evet ise bu çalışır   
                    : context.Set<TEntity>().Where(filter).ToList();    //değilse filtreleyip ver

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())

            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
