using Logger;

public record Employee(Guid Id, FullName Name) : IEntity
{
    // the Name property is implemented explicitly to provide a consistent naming convention.
    public string Name => $"Employee: {Name.FirstName} {Name.LastName}";

}