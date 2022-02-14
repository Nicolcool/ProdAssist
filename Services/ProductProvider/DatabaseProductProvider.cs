using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProdAssist.DbContexts;
using ProdAssist.DTOs;
using ProdAssist.Models;

namespace ProdAssist.Services
{
    public class DatabaseProductProvider : IProductProvider
    {
        private readonly ProductsDbContextFactory _dbContextFactory;

        public DatabaseProductProvider(ProductsDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using(ProductsDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ProductDTO> productDTOs = await context.Products.ToListAsync();
                return productDTOs.Select(r => ToProduct(r));
            }
        }

        private static Product ToProduct(ProductDTO dto)
        {
            return new Product(dto.Group, dto.SKU, dto.Categorie, dto.Name, dto.Sheet, dto.Active);
        }
    }
}
