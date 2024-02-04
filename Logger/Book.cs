using Logger;

public record Book(Guid Id, string Title) : IEntity
{
    // the Name property is implemented explicitly to provide a consistent naming convention.
    public string Name => $"Book: {Title}";

}

