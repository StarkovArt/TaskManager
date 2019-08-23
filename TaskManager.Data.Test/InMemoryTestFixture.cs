namespace TaskManager.Data.Test
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TaskManager.Data.Entities;
    using Xunit;
    public class InMemoryTestFixture : IDisposable
    {
        public TaskContext Context => InMemoryContext();

        public void Dispose()
        {
            this.Context?.Dispose();
        }

        private static TaskContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TaskContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new TaskContext(options);

            return context;
        }
    }
}
