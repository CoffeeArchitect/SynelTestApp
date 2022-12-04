
using SynelTestApp.DAL.Interfaces;

namespace SynelTestApp.TEST
{
    public class EmployeeControllerTest
    {
        private readonly EmployeeController _controller;
        private readonly IRepository _repository;

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {

            // Arrange
            var testData = new CRUDModel<Employee>()
            {
                action = "remove",
                added = null,
                changed = null,
                deleted = null,
                key = 11111111,
                keyColumn = "Id",
                @params = null,
                table = null,
                value = null
            };
            // Act
            var badResponse = _controller.Delete(testData);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var testData = new CRUDModel<Employee>()
            {
                action = "remove",
                added = null,
                changed = null,
                deleted = null,
                key = 1010,
                keyColumn = "Id",
                @params = null,
                table = null,
                value = null
            };
            // Act
            var noContentResponse = _controller.Delete(testData);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }
        
    }
}