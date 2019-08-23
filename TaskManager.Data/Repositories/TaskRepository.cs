namespace TaskManager.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskManager.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class TaskRepository: ITaskRepository
    {
        private readonly TaskContext context;

        public TaskRepository(TaskContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Models.Task>> GetAllAsync()
        {
            return await this.context.Tasks.ToListAsync();
        }
    }
}
