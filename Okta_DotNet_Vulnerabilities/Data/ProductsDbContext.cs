using Microsoft.EntityFrameworkCore;
using Okta_DotNet_SQL_Injection.Models;

namespace Okta_DotNet_SQL_Injection.Data
{
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        { }

        public DbSet<Products> Products { get; set; }
    }
}