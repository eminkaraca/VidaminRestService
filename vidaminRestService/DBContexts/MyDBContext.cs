using Microsoft.EntityFrameworkCore;

namespace vidaminRestService.DBContexts
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

    }
}
