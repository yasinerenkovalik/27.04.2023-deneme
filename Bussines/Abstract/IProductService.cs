using Core.Utilities.Resaults;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int id);
        IDataResult<List<Product>>GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDTO>> GetDetail();
        IDataResult<Product> GetById(int product);
        IResult Add(Product product);
        IResult Update(Product product);

    }
}
