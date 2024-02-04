namespace Logger;

// I choose to define FullNameRecord as a value type record beacuse it a
// immutable data structure that stores a person's full name.

// FullNameRecord is immutable because it is a value type record. 

public record FullName
{
    public string? FirstName { get; }
    public string? MiddleName { get; }
    public string? LastName { get; }

    public FullName(string? firstName, string? middleName, string? lastName)
    {
        FirstName = firstName ?? "";
        MiddleName = middleName ?? "";
        LastName = lastName ?? "";
    }
}