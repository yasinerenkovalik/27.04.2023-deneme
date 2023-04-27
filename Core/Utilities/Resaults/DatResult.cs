using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Resaults
{
    public class DatResult<T> : Result, IDataResult<T>
    {
        public DatResult(T data,bool succes,string massage):base(succes,massage)
        {
            
        }
        public DatResult(T data ,bool succes):base(succes)
        {
            data = data;  
        }
        public T Data { get; }
    }
}
