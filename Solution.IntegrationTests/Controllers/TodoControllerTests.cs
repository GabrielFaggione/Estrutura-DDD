using Solution.Domain.Entities.TodoAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Solution.IntegrationTests.Controllers
{
    public class TodoControllerTests : SolutionTestBase
    {

        [Fact]
        public async Task GetAllTodos_ReturnEmptyList()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/Todo");

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var allTodosResponse = JsonSerializer.Deserialize<List<TodoRecord>>(content);

            Assert.NotNull(allTodosResponse);
            Assert.Empty(allTodosResponse);
        }


    }
}
