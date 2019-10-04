namespace TaskManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task<IEnumerable<Models.Task>> Tasks();
    }
}
