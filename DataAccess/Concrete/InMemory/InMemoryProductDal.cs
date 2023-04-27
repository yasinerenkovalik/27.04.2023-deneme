using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="bardak",UnitsInStock=10,UnitPrice=100},
              new Product{ProductId=2,CategoryId=1,ProductName="bardak böyük",UnitsInStock=14,UnitPrice=56},
                new Product{ProductId=3,CategoryId=2,ProductName="tabak",UnitsInStock=11,UnitPrice=65}
        };
            }
        public void add(Product product)
        {
            throw new NotImplementedException();
        }

        public void delete(Product product)
        {
            Product productToDelte=null;
            productToDelte = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelte);
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

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void update(Product product)
        {
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            
        }
    }

     
    }
