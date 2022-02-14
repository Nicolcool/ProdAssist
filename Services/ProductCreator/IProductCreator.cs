using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdAssist.Models;

namespace ProdAssist.Services.ProductCreator
{
    public interface IProductCreator
    {
        Task CreateProduct(Product product);
    }
}
