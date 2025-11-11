using API1.DTO.DataModel;
using Microsoft.EntityFrameworkCore;

namespace API1.DataContext
{
    public class Test_dbContext : DbContext
    {
        public Test_dbContext(DbContextOptions<Test_dbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
