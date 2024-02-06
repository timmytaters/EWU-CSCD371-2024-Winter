/*
 * Define an IEntity interface: ❌✔
Add an Id property of type Guid that is an init-only setter. ❌✔
Add a Name property that is string. ❌✔
 */

namespace Logger;

public interface IEntity
{
    public Guid Id { get; init; }
    //Set since some names are changeable
    public string Name { get;}
}
