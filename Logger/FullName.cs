/*
 * Define a full name record (first, last, middle) handling optional and null appropriately. ❌✔
Provide a comment on the full name record on why you selected to define a value or a reference type and ❌✔
Provide a comment on the full name record on why or why not the type is immutable. ❌✔
*/
namespace Logger;

//I believe that fullname should be a reference type that is immutable because people's names are able to be changed

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
    public string GetFullName()
    {
        string name = "";
        if(FirstName != null && FirstName != "")
        {
            name += FirstName;
        }
        if(MiddleName != null&&MiddleName != "")
        {
            name += " " + MiddleName;
        }
        if(LastName != null && LastName != "")
        {
            name += " " + LastName;
        }
        return name.Trim();
    }
}