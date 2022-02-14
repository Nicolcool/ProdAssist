using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdAssist.Models;

namespace ProdAssist.Services.ProductConflictValidators
{
    public interface IProductConflictValidator
    {
        Task<Product> GetConflictingProduct(Product product);
    }
}
