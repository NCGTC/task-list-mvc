using System.Data.Entity.ModelConfiguration;
using TaskListMvc.Model;

namespace TaskListMvc.Data.Configurations
{
    public class TaskConfiguration :
        EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            Property(t => t.Title).HasMaxLength(150).IsRequired();
        }
    }
}
