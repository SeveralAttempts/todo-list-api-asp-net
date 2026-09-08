using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/todo")]
public class TodoManageController : ControllerBase
{
    private TodoService _todoService;

    public TodoManageController(TodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost]
    public IActionResult AddTodo(TodoAddRequest request)
    {
        var todoItem = BaseTodoItem.Create(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.IsDone,
            request.CreationDate,
            request.OptionalEndDate,
            request.IsExpired
        );

        if (todoItem.IsFailure)
        {
            return BadRequest(todoItem.Error.Current);
        }

        _todoService.Add(todoItem.Value);

        return Created("api/todo", new TodoAddResponse(todoItem.Value.Id));
    }
}