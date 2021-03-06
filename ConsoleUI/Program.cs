using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //S
        //O YENİ ÖZELLİK EKLENİYORKEN MEVCUT KODUNA DOKUNMAYACAKSIN
        //L
        //I KULLANMAYACAĞIN BİŞEYİ YAZMA
        //D
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());//inmemorydata
            ProductManager productManager = new ProductManager(new EfProductDal());//entity data

            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            //foreach (var product in productManager.GetAll())
            //foreach (var product in productManager.GetAllByCategotyId(2))
            
        }
    }
}