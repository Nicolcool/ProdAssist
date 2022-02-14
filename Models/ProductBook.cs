using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProdAssist.Exceptions;
using ProdAssist.Services;
using ProdAssist.Services.ProductConflictValidators;
using ProdAssist.Services.ProductCreator;

namespace ProdAssist.Models
{
    public class ProductBook
    {
        private readonly IProductProvider _productProvider;
        private readonly IProductCreator _productCreator;
        private readonly IProductConflictValidator _productConflictValidator;

        public ProductBook(IProductProvider productProvider, IProductCreator productCreator, IProductConflictValidator productConflictValidator)
        {
            _productProvider = productProvider;
            _productCreator = productCreator;
            _productConflictValidator = productConflictValidator;
        }

        public async Task AddProduct(Product product)
        {
            Product conflictingProduct = await _productConflictValidator.GetConflictingProduct(product);

            if(conflictingProduct != null)
            {
                throw new ProductConflictException(conflictingProduct, product);
            }

            await _productCreator.CreateProduct(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           return await _productProvider.GetAllProducts();
        }
    }
}