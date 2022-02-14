using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdAssist.Models;

namespace ProdAssist.Services
{
    public interface IProductProvider
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
