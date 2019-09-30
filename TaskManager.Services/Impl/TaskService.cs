namespace TaskManager.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskManager.Data;

    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Models.Task>> GetTasksAsync()
        {            
            return await unitOfWork.Tasks();
        }

    }
}
