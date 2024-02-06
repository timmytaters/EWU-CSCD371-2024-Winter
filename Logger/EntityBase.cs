/*
 * Define an abstract base class that implements IEntity - appropriately choosing to implement the interface explicitly or implicitly. ❌✔
Do not implement the Name property in this abstract class. ❌✔
Do force any derived classes to provide an implementation for Name. ❌✔
 */

namespace Logger;
using System;

public abstract record EntityBase : IEntity 
{ 

    public Guid Id { get => Id; init => Guid.NewGuid(); }  
    public abstract string Name { get; }

}