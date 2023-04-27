﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Resaults
{
    public class SuccessDataResult<T>:DatResult<T>
    {
        

        public SuccessDataResult(T data, bool v, string message):base(data,true,message)
        {
            
        }
        public SuccessDataResult(T data):base(data,true)
        {
            
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        public SuccessDataResult():base(default,true)
        {
            
        }

      
    }
}