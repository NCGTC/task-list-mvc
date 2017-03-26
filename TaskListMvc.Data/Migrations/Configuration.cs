namespace TaskListMvc.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskListMvc.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskListMvc.Data.TaskListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TaskListMvc.Data.TaskListContext context)
        {
            context.Tasks.AddOrUpdate(
              t => t.Title,
              new Task { Title = "Go for a walk" },
              new Task { Title = "Drink some tea" },
              new Task { Title = "Relax" }
            );
        }
    }
}
