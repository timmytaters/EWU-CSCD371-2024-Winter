using Logger;

public record Student(Guid Id, FullName Name) : IEntity
{
    // the Name property is implemented explicitly to provide a consistent naming convention.
    public string Name => $"Student: {Name.FirstName} {Name.LastName}";

}