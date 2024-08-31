using CRUD_FOR_AKSHAY.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_FOR_AKSHAY.Data
{
    public class StduentDbContext : DbContext
    {
        public StduentDbContext(DbContextOptions<StduentDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
