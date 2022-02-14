using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdAssist.DbContexts;
using ProdAssist.DTOs;
using ProdAssist.Models;

namespace ProdAssist.Services.ProductCreator
{
    public class DatabaseProductCreator : IProductCreator
    {
        private readonly ProductsDbContextFactory _dbContextFactory;
        public DatabaseProductCreator(ProductsDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateProduct(Product product)
        {
            using (ProductsDbContext context = _dbContextFactory.CreateDbContext())
            {
                ProductDTO productDTO = ToProductDTO(product);
                context.Products.Add(productDTO);
                await context.SaveChangesAsync();
            }
        }

        private ProductDTO ToProductDTO(Product product)
        {
            return new ProductDTO()
            {
                Group = product.Group,
                SKU = product.SKU,
                Categorie = product.Categorie,
                Name = product.Name,
                Sheet = product.Sheet,
                Active = product.Active,
            };
        }
    }
}
