namespace TaskManager.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskManager.Data;

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;
        private readonly IUnitOfWork unitOfWork;


        public TaskService(IUnitOfWork unitOfWork)//(ITaskRepository repository)
        {
            //this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        }

        public async Task<IEnumerable<Models.Task>> GetTasksAsync()
        {
            //return await repository.GetAllAsync();
            return await unitOfWork.Tasks();

        }

    }
}
