using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdAssist.DbContexts;
using ProdAssist.DTOs;
using ProdAssist.Models;

namespace ProdAssist.Services.ProductConflictValidators
{
    public class DatabaseProductConflictValidator : IProductConflictValidator
    {
        private readonly ProductsDbContextFactory _dbContextFactory;

        public DatabaseProductConflictValidator(ProductsDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Product> GetConflictingProduct(Product product)
        {
            using (ProductsDbContext context = _dbContextFactory.CreateDbContext())
            {
                ProductDTO productDTO = await context.Products
                    .Where(r => r.SKU == product.SKU)
                    .Where(r => r.Name == product.Name)
                    .FirstOrDefaultAsync();

                if(productDTO == null)
                {
                    return null;
                }

                return ToProduct(productDTO);
            }
        }

        private static Product ToProduct(ProductDTO dto)
        {
            return new Product(dto.Group, dto.SKU, dto.Categorie, dto.Name, dto.Sheet, dto.Active);
        }
    }
}
