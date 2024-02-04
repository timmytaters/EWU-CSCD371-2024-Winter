namespace Logger;
using System;

public abstract class EntityBase : IEntity 
{ 

    public abstract Guid Id { get; init; }

    public abstract string Name { get; }   

}