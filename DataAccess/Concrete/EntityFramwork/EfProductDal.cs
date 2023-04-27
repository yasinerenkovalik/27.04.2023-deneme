using Core.DataAccess.EntitiyFreamwork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramwork
{
    public class EfProductDal : EfntitiRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDTO> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
                             select new ProductDetailDTO
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
