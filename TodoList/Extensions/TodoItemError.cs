
using Microsoft.OpenApi.Services;

public record TodoItemError
{
    private string IsDoneError => "Task should not be completed during creation.";
    private string IsExpiredError => "Task should not be expired during creation.";
    private string GuidError => "Guid should not be empty.";

    public string Current { get; }
    public TodoItemErrorEnum CurrentError { get; }

    public TodoItemError(TodoItemErrorEnum error)
    {
        CurrentError = error;

        switch (CurrentError)
        {
            case TodoItemErrorEnum.IsDoneError: Current = IsDoneError; break;
            case TodoItemErrorEnum.IsExpiredError: Current = IsExpiredError; break;
            case TodoItemErrorEnum.GuidError: Current = GuidError; break;
            default: Current = "Unknown error."; break;
        }
    }
}