
namespace TaskManager.Api.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using TaskManager.Api.Controllers;
    using TaskManager.Services;
    using Xunit;

    public class TaskControllerTests
    {
        [Fact]
        public async Task GetAll_DataIsOk_ShouldReturnTasksAsync()
        {
            // Arrange
            var service = new Mock<ITaskService>();
            var controller = new TaskController(service.Object);
            var tasks = new List<Models.Task>
            {
                new Models.Task(),
                new Models.Task(),
            };
            service.Setup(s => s.GetTasksAsync()).ReturnsAsync(tasks);

            // Act
            var response = await controller.GetAll();

            // Assert
            Assert.Equal(2, response.Count());
        }

        [Fact]
        public async void GetAll_DataNotFound_ShouldReturnEmptyList()
        {
            // Arrange
            var service = new Mock<ITaskService>();
            var controller = new TaskController(service.Object);

            service.Setup(s => s.GetTasksAsync()).ReturnsAsync(new List<Models.Task>());

            // Act
            var response = await controller.GetAll();

            // Assert
            Assert.Empty(response);
        }

    }
}
