using Microsoft.EntityFrameworkCore;
using ResturentManagementSystem.Model;

namespace ResturentManagementSystem.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        public DbSet<Category> Category { get; set; }
    }
}
