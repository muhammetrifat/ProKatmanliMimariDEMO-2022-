using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //burası memory için kullanılıyordu, biz entity framework eklentisini yaptığımızda buraya hiç dokunmadan eklemiş bulunduk

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //iş kodları buraya eklenebilir if else filan falan
            if (product.ProductName.Length < 2)
            {
                //magic stringten uzak dur
                return new ErrorResult(Messages.InvalidProductName);

            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAddSuccess);

        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 15)//1 saat boyunca listeleme işlemini kapatıyoruz
            {
                return new ErrorDataResult<List<Product>>(Messages.MeintananceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategotyId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }//successdata'ya product clasını verip constructor'una product datasını attık

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 9)//1 saat boyunca listeleme işlemini kapatıyoruz
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MeintananceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
