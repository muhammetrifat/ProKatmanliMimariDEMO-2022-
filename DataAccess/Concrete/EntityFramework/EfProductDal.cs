using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDispossable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())//using içine yazarak performanslı hale getiriyoruz
            {//using bittiği an garbagecollector gelip bunu temizleyecektir
                var addedEntity = context.Entry(entity);//referansı yakala
                addedEntity.State = EntityState.Added;//ekle
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala
                deletedEntity.State = EntityState.Deleted;//sil
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
                //select * from products // select * from products where ... burası bir if else parçacığıdır
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);//referansı yakala
                updatedEntity.State = EntityState.Modified;//editle
                context.SaveChanges();
            }
        }
    }
}
