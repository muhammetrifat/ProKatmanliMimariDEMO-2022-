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
        //Data döndürenlere IDataResult(hem data hem mesaj) yaptık, void olanı ise IResult(sadece mesaj) yaptık
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategotyId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
    }
}
