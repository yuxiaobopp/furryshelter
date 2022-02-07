using Microsoft.EntityFrameworkCore;
using WebApplication.DbModels;

namespace WebApplication
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Register> Users { get; set; }
    }
}
