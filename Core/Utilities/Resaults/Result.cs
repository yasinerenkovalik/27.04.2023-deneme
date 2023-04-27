using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Resaults
{
    public class Result : IResult
    {
      

        public Result(bool succes, string massage):this(succes)
        {
            message = massage;
            success=succes;

        }
        public Result(bool succes) 
        {
            
            success = succes;

        }

        public bool success  {get;}

        public string message { get; }
        
    }
}
