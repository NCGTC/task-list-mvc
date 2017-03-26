using System.Data.Entity;
using TaskListMvc.Data.Configurations;
using TaskListMvc.Model;

namespace TaskListMvc.Data
{
    public class TaskListContext : DbContext
    {
        public TaskListContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TaskConfiguration());
        }
    }
}
