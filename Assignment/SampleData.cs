using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Text;

namespace Assignment;

public class SampleData : ISampleData
{
    //File.ReadLines internally handles the resource management and ensures proper disposal of resources once it finishes reading the lines.
    //It's designed to be used without requiring you to manually dispose of resources.
    public IEnumerable<string> CsvRows { get; set; } = File.ReadLines("People.csv").Skip(1);

    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        IEnumerable<string> states = CsvRows.Select(CsvRows => CsvRows.Split(",")[6].Trim()).Distinct().OrderBy(state => state);
        return states;
    }

    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        return string.Join(",", states);
    }

    public IEnumerable<IPerson> People
    {
        get
        {
            IEnumerable<IPerson> peopleOut = new List<IPerson>();
            IEnumerable<string[]> peopleIn = CsvRows.Select(CsvRows => CsvRows.Split(','));
            foreach(string[] person in peopleIn) 
            { 
                string[] curPerson = person;
                peopleOut = peopleOut.Append(new Person(curPerson[1], curPerson[2], new Address(curPerson[4], curPerson[5], curPerson[6], curPerson[7]), curPerson[3]));
            }
            peopleOut = peopleOut.OrderBy(p => p.Address.State).ThenBy(p => p.Address.City).ThenBy(p => p.Address.Zip);
            return peopleOut;

        }
    }

    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        IEnumerable<IPerson> people = People.Where(p => filter(p.EmailAddress));
        return people.Select(p => (p.FirstName, p.LastName));
    }

    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
    {
        IEnumerable<string> uniqueSortedStates = people.Select(person => person.Address.State).Distinct().OrderBy(state => state);
        return uniqueSortedStates.Aggregate(((concat, str) => $"{concat},{str}"));
    }
}
