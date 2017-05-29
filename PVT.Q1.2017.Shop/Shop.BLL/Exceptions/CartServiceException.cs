using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Exceptions
{
    public class CartServiceException : Exception
    {
        public CartServiceException() : base() { }

        public CartServiceException(string message) : base(message) { }

        public CartServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
