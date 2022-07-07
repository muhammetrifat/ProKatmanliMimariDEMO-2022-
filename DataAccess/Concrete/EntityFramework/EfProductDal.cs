using Core.DataAccess.EntityFramework;
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
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal//IPRODUCTDAL'a neden ihtiyaç var?
        //çünkü biz sadece efrb içindeki imzaları kullanmayacağız, product'a özel imzaları IProductDal içerisinde tutacağız
        //DTO'lar orada kullanılacak, ve biz sadece EF'ye bağımlı değiliz
    {
        
    }
}
