namespace Logger;

public interface IEntity
{

    // Place members here.

    // the Guid Id and Name property in implemented implicitly because they are both required member
    // of the IEntity interface class
    public Guid Id { get; init; }
    public string Name { get; }


}
