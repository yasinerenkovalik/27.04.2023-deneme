﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntitiyRepository<Product>
    {
        List<ProductDetailDTO> GetProductDetails();
    }
}
