using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint - generic kısıt
    //burada class, referans tip olabilir anlamındadır, 
    //Ientity ise bizim tablolarımızın annesidir(yalnızca Ientity ve ondan türeyen classlar yazılabilir)
    //new(): newlenebilir olmalı(yani artık sadece IEntity yeterli değil IEntity den türemek zorunda(ondan türeyen classlar))
    //bu hareketimizle bi standart oluşturma işlemi yaptık
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null/*filtre vermeyebilirsin anlamındadır*/);
        T Get(Expression<Func<T, bool>> filter); //refactoring yapcaz
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
