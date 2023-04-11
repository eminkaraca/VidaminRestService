using Microsoft.EntityFrameworkCore;


namespace vidaminRestService.Data
{
    public class DataContext : DbContext
    {
       // public DbSet<Pet> Pets { get; set; }
       // public DbSet<User> Users { get; set; }

        public DataContext(Microsoft.EntityFrameworkCore.DbContextOptions<DataContext> options)
            : base(options) { }
    }
}
