using Bussines.Abstract;
using Bussines.BusinessAspects.Autofact;
using Bussines.Constants;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Resaults;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramwork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Bussines.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productdal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productdal,
            ICategoryService categoryService)
        {
            _productdal = productdal;
            _categoryService = categoryService; 
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidatior))]
        public IResult Add(Product product)
        {
            IResult resullt=BusinessRules.Run(
                ChecIfProductNameOfExists(product.ProductName)
                ,ChecIfProductCountOfCategory(product.CategoryId));

            if (resullt != null)
            {
                return resullt;

            }
                  _productdal.add(product);
                  return new SuccessResult(Message.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Product>>(Message.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(),Message.ProductsList);
        }


        public IDataResult <List<Product>> GetAllByCategory(int id)
        {
    
            return new SuccessDataResult<List<Product>>(_productdal.GetAll(), Message.ProductsList);
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

        [ValidationAspect(typeof(ProductValidatior))]
        public IResult Update(Product product)
        {
           


            _productdal.add(product);
            return new SuccessResult(Message.ProductAdded);
        }
        private IResult ChecIfProductCountOfCategory(int categoryId)
        {
            var result = _productdal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Message.ProductCountOfCategory);
            }
            return new SuccessResult();
        }
        private IResult ChecIfProductNameOfExists(string productname)
        {
            var result = _productdal.GetAll(p => p.ProductName == productname).Any();
            if (result)
            {
                return new ErrorResult(Message.ProductNameAlreadyExists);
            }
            return new SuccessResult();
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
