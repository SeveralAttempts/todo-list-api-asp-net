
using System.Dynamic;
using CSharpFunctionalExtensions;

public class BaseTodoItem
{
    public Guid Id { get; }
    public string? Name { get; }
    public string? Description { get; }
    public bool IsDone { get; }
    public DateTime CreationDate { get; }
    public DateTime? OptionalEndDate { get; }
    public bool? IsExpired { get; }

    private BaseTodoItem(Guid id,
                        string? name,
                        string? description,
                        bool isDone,
                        DateTime creationDate,
                        DateTime? optionalEndDate,
                        bool? isExpired)
    {
        Id = id;
        Name = name;
        Description = description;
        IsDone = isDone;
        CreationDate = creationDate;
        OptionalEndDate = optionalEndDate;
        IsExpired = isExpired;
    }

    public static Result<BaseTodoItem, TodoItemError> Create(Guid id,
                                                    string? name,
                                                    string? description,
                                                    bool isDone,
                                                    DateTime creationDate,
                                                    DateTime? optionalEndDate,
                                                    bool? isExpired)
    {
        if (isDone)
            return new TodoItemError(TodoItemErrorEnum.IsDoneError);
        if (isExpired is true)
            return new TodoItemError(TodoItemErrorEnum.IsExpiredError);
        if (id == Guid.Empty)
            return new TodoItemError(TodoItemErrorEnum.GuidError);

        return new BaseTodoItem(id, name, description, isDone, creationDate, optionalEndDate, isExpired);
    }
}