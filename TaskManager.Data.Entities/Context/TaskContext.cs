namespace TaskManager.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Models;

    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
        { }

        public DbSet<Task> Tasks { get; set; }
    }
}
