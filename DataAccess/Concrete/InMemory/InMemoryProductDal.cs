using DataAccess.Abstract;
using Entities.Concrete;
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
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=2,ProductName="Klavye",UnitPrice=100,UnitsInStock=20 },
                new Product{ProductId=2,CategoryId=2,ProductName="Mouse",UnitPrice=60,UnitsInStock=51 },
                new Product{ProductId=3,CategoryId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=5 },
                new Product{ProductId=4,CategoryId=3,ProductName="Bardak",UnitPrice=10,UnitsInStock=50 },
                new Product{ProductId=5,CategoryId=3,ProductName="Çatal",UnitPrice=5,UnitsInStock=90 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete =  _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId == categoryId).ToList();
       
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürünün Id'sine sahip olan ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
