namespace TaskManager.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITaskService
    {
        Task<IEnumerable<Models.Task>> GetTasksAsync();
    }
}
