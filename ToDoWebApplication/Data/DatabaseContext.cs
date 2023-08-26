using Microsoft.EntityFrameworkCore;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
           // Database.EnsureCreated();
        }
       public DbSet<TaskBase> Tasks { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<AddDueDate> AddDueDates { get; set; }
       public DbSet<AddFile> AddFiles { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<RepeatTime> RepeatTimes { get; set; }
    }
}
