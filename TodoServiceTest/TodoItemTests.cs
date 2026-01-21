namespace TodoServiceTest;

public class TodoItemTests
{
    [Fact]
    public void CreateItemWithCorrectData_ShouldSuccess()
    {
        var id = Guid.NewGuid();
        var name = "Name";
        var description = "Descr";
        var isDone = false;
        var creationDate = DateTime.Now;
        var optionalEndDate = DateTime.Now.AddDays(3);
        var isExpired = false;

        var item = BaseTodoItem.Create(id, name, description,
            isDone, creationDate, optionalEndDate, isExpired);

        Assert.NotNull(item.Value);
        Assert.True(item.IsSuccess);
        Assert.Equal(id, item.Value.Id);
        Assert.Equal(name, item.Value.Name);
        Assert.Equal(description, item.Value.Description);
        Assert.Equal(isDone, item.Value.IsDone);
        Assert.Equal(creationDate, item.Value.CreationDate);
        Assert.Equal(optionalEndDate, item.Value.OptionalEndDate);
        Assert.Equal(isExpired, item.Value.IsExpired);
    }

    [Fact]
    public void CreateItemWithIsDoneTrue_ShouldFail()
    {
        var id = Guid.NewGuid();
        var name = "Name";
        var description = "Descr";
        var isDone = true;
        var creationDate = DateTime.Now;
        var optionalEndDate = DateTime.Now.AddDays(3);
        var isExpired = false;

        var item = BaseTodoItem.Create(id, name, description,
            isDone, creationDate, optionalEndDate, isExpired);

        Assert.True(item.IsFailure);
    }

    [Fact]
    public void CreateItemWithIsExpiredTrue_ShouldFail()
    {
        var id = Guid.NewGuid();
        var name = "Name";
        var description = "Descr";
        var isDone = false;
        var creationDate = DateTime.Now;
        var optionalEndDate = DateTime.Now.AddDays(3);
        var isExpired = true;

        var item = BaseTodoItem.Create(id, name, description,
            isDone, creationDate, optionalEndDate, isExpired);

        Assert.True(item.IsFailure);
    }
    
    [Fact]
    public void CreateItemWithEmptyGuid_ShouldFail()
    {
        var id = Guid.Empty;
        var name = "Name";
        var description = "Descr";
        var isDone = false;
        var creationDate = DateTime.Now;
        var optionalEndDate = DateTime.Now.AddDays(3);
        var isExpired = false;

        var item = BaseTodoItem.Create(id, name, description,
            isDone, creationDate, optionalEndDate, isExpired);
        
        Assert.True(item.IsFailure);
    }
}
