public record TodoAddRequest
{
    public string? Name { get; }
    public string? Description { get; }
    public bool IsDone { get; }
    public DateTime CreationDate { get; }
    public DateTime? OptionalEndDate { get; }
    public bool? IsExpired { get; }
}