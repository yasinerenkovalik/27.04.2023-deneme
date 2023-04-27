using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Resaults;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Message.ProductNameInavlind);
            }
            _productdal.add(product);
            return new SuccessResult(Message.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(),true,Message.ProductsList);
        }


        public IDataResult <List<Product>> GetAllByCategory(int id)
        {
    
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(), true, Message.ProductsList);
        }

        public IDataResult<Product> GetById(int product)
        {
            return new SuccessDataResult<Product>(_productdal.Get(p => p.CategoryId == product));
        }

        public SuccessDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productdal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max));
        }

        public SuccessDataResult<List<ProductDetailDTO>> GetDetail()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productdal.GetProductDetails());
        }

       
     

         IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

       IDataResult<List<ProductDetailDTO>> IProductService.GetDetail()
        {
            throw new NotImplementedException();
        }
    }
}
