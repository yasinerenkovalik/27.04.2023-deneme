﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ICategoryService
    {
       public List<Category> GetAll();
       public Category GetById(int categoryid);
    }
}
