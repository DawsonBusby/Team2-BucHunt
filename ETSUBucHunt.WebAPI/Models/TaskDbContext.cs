using Microsoft.EntityFrameworkCore;

namespace ETSUBucHunt.WebAPI.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; } = null!;
    }
}
