namespace TaskManager.Services.Test
{
    using Moq;
    using System.Threading.Tasks;
    using TaskManager.Data;
    using TaskManager.Services.Impl;
    using Xunit;

    public class TaskServiceTests
    {
        [Fact]
        public async Task GetTasksAsync_DataExist_ShouldReturnTasks()
        {
            // Arrange
            var repository = new Mock<IUnitOfWork>();
            var service = new TaskService(repository.Object);
            var tasks = new[]
            {
                new Models.Task(),
                new Models.Task(),
            };
            repository.Setup(s => s.Tasks()).ReturnsAsync(tasks);

            // Act
            var result = await service.GetTasksAsync();

            // Assert
            Assert.Equal(tasks, result);
        }
    }
}
