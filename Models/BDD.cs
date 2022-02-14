using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProdAssist.Models
{
    public class BDD
    {
        private readonly ProductBook _productBook;
        public string Name { get; }

        public BDD(string name, ProductBook productBook)
        {
            Name = name;
            _productBook = productBook;
        }

        public async Task AddProduct(Product product)
        {
            await _productBook.AddProduct(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productBook.GetAllProducts();
        }
    }
}
