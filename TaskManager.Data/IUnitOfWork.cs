using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;   

namespace TaskManager.Data
{
    public interface IUnitOfWork
    {
        Task<IEnumerable<Models.Task>> Tasks();

    }
}
