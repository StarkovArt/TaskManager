namespace TaskManager.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Data.Entities;
    using TaskManager.Data.Repositories;
    using TaskManager.Models;

    public class UnitOfWork : IDisposable, IUnitOfWork

    {
        private readonly TaskContext taskContext;
        private TaskRepository taskRepository;

        public UnitOfWork(TaskContext taskContext)
        {
            this.taskContext = taskContext;

        }

        public async Task<IEnumerable<Models.Task>> Tasks()
        {

            if (taskRepository == null)
                taskRepository = new TaskRepository(taskContext);
            return await taskRepository.GetAllAsync();
        }

        public void Save()
        {
            taskContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    taskContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
