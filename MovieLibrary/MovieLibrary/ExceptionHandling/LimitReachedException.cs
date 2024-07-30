using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.ExceptionHandling
{
    public class LimitReachedException:Exception
    {
        public LimitReachedException(String message) : base(message)
        { }
    }
}
