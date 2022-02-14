using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProdAssist.DbContexts
{
    public class ProductsDbContextFactory
    {
        private readonly string _connectionString;

        public ProductsDbContextFactory(string connextionString)
        {
            _connectionString = connextionString;
        }
        public ProductsDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new ProductsDbContext(options);
        }
    }
}
