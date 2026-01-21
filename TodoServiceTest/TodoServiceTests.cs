namespace TodoServiceTest;

public class TodoServiceTests
{
    [Fact]
    public void InitializeService_ShouldSuccess()
    {
        var service = new TodoService();
        var expectedItemCount = 0;

        Assert.Equal(service.GetAll().Value.Count, expectedItemCount);
    }
}
