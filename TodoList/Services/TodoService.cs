
using System.ComponentModel;
using CSharpFunctionalExtensions;

public class TodoService
{
    private List<BaseTodoItem> _todoItems;

    public TodoService()
    {
        _todoItems = new();
    }

    public Result Add(BaseTodoItem item)
    {
        _todoItems.Add(item);

        return Result.Success();
    }

    public Result Remove(Guid id)
    {
        var del = _todoItems.Find(x => x.Id == id);

        if (del is null)
            return Result.Failure("Item not found.");

        _todoItems.Remove(del);
        return Result.Success();
    }

    public Result<List<BaseTodoItem>> GetAll()
    {
        return _todoItems;
    }

    public Result<BaseTodoItem> GetExact(Guid id)
    {
        if (id == Guid.Empty)
            return Result.Failure<BaseTodoItem>("Id is empty.");

        var del = _todoItems.Find(x => x.Id == id);

        if (del is null)
            return Result.Failure<BaseTodoItem>("No such item.");

        return del;
    }

    public Result Change(BaseTodoItem item)
    {
        var change = _todoItems.Find(x => x.Id == item.Id);

        if (change is null)
            return Result.Failure("Item not found.");

        var newList = _todoItems.Select(x =>
        {
            if (x.Id == item.Id)
                x = item;

            return x;
        }).ToList();

        _todoItems = newList;

        return Result.Success();
    }
}