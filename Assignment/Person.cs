using System.Linq;
using System.Collections.Generic;

namespace Assignment;

public class Person : IPerson
{
    public Person(string firstName, string lastName, IAddress address, string emailAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        EmailAddress = emailAddress;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IAddress Address { get;set; }
    public string EmailAddress { get; set; }
    public bool ManualIsEqual(IPerson other)
    {
        bool result = true;
        if(FirstName != other.FirstName)
        {
            result = false;
        }
        if(LastName != other.LastName)
        {
            result = false;
        }
        if(EmailAddress != other.EmailAddress)
        {
            result = false;
        }
        if (Address.City != other.Address.City)
        {
            result = false;
        }
        if(Address.State != other.Address.State)
        {
            result = false;
        }
        if(Address.Zip != other.Address.Zip)
        {
            result = false;
        }
        return result;
    }
}
