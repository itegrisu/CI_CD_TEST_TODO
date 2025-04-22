using Microsoft.EntityFrameworkCore;

namespace CI_CD_TEST
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; } = null!;
    }
}
