using Solution.Domain.Entities.TodoAggregates;

namespace Solution.UnitTests.TodoServiceTest
{
    public class Add : TodoServiceBase
    {
        [Fact]
        public void AlreadyExistsTodoWithSameDescription_MustReturnException()
        {
            // Arrange
            var todoCreationRequest = new TodoCreationRequest { Description = "Test" };

            _todoRepository
                .Setup(s => s.Find(It.IsAny<Expression<Func<Todo, bool>>>()))
                .Returns(new Todo(todoCreationRequest.Description));
            // Act && Assert
            Assert.Throws<DuplicateException>(() => _todoService.Add(todoCreationRequest));
        }

        [Fact]
        public void AddWithoutDuplicateDescription_MustReturnTodo()
        {
            // Arrange
            var todoCreationRequest = new TodoCreationRequest { Description = "Test" };

            _todoRepository
                .Setup(s => s.Find(It.IsAny<Expression<Func<Todo, bool>>>()))
                .Returns<Todo>(null);
            // Act
            var result = _todoService.Add(todoCreationRequest);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result.Description);
            Assert.False(result.IsCompleted);
        }

    }
}
