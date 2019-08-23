namespace TaskManager.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskManager.Data;

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;

        public TaskService(ITaskRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
 
        public async Task<IEnumerable<Models.Task>> GetTasksAsync()
        {
            return await repository.GetAllAsync();
        }

    }
}
