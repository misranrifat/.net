using Microsoft.EntityFrameworkCore;
using DotNetApi.Models;

namespace DotNetApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
} 