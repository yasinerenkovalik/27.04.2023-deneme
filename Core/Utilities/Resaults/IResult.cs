using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Resaults
{
    public interface IResult
    {
        bool success { get; }
        string message { get; }
    }
}
