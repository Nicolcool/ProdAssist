using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdAssist.DTOs;
using ProdAssist.Models;

namespace ProdAssist.DbContexts
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductDTO> Products { get; set; }
    }
}
