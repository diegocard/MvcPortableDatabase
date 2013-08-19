using System.Data.Entity;

namespace PortableDatabaseExample.Models
{
    public abstract class TaskContext : DbContext
    {
        public TaskContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}