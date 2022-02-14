using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ProdAssist.Models;

namespace ProdAssist.Exceptions
{
    class ProductConflictException : Exception
    {
        public Product ExistingProduct { get; }
        public Product IncomingProduct { get; }

        public ProductConflictException(Product existingProduct, Product incomingProduct)
        {
            ExistingProduct = existingProduct;
            IncomingProduct = incomingProduct;
        }

        public ProductConflictException(string message, Product existingProduct, Product incomingProduct) : base(message)
        {
            ExistingProduct = existingProduct;
            IncomingProduct = incomingProduct;
        }

        public ProductConflictException(string message, Exception innerException, Product existingProduct, Product incomingProduct) : base(message, innerException)
        {
            ExistingProduct = existingProduct;
            IncomingProduct = incomingProduct;
        }
    }
}
