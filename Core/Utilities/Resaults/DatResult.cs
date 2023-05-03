using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Resaults
{
    public class DatResult<T> : Result, IDataResult<T>
    {

        public DatResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DatResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
