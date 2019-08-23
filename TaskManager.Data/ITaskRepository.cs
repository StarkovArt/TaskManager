namespace TaskManager.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITaskRepository : IRepository
    {
        Task<IEnumerable<Models.Task>> GetAllAsync();
    }
}
