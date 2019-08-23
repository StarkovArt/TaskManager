namespace TaskManager.Data.Test.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskManager.Data.Repositories;
    using Xunit;

    public class TaskRepositoryTests
    {
        [Fact]
        public async Task GetAll_DataExist_ShouldReturnAirlines()
        {
            using (var context = new InMemoryTestFixture().Context)
            {
                // Arrange
                var taskId = Guid.NewGuid();
                var isDone = false;
                var description = "Description";
                var name = "Name";
 
                context.Tasks.Add(new Models.Task
                {   Id = taskId,
                    IsDone = isDone,
                    Description = description,
                    Name = name
                });
   
                context.SaveChanges();
  
                var repository = new TaskRepository(context);

                // Act
                var tasks = (await repository.GetAllAsync()).ToArray();
               
                // Assert
                Assert.Single(tasks);

                var task = tasks[0];

                Assert.Equal(task.Id, taskId);
                Assert.Equal(task.IsDone, isDone);
                Assert.Equal(task.Name, name);
                Assert.Equal(task.Description, description);
            }
        }
    }
}
