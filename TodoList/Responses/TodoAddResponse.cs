public record TodoAddResponse
{
    public Guid Id { get; }

    public TodoAddResponse(Guid id)
    {
        Id = id;
    }
}