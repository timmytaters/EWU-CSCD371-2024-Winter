using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1.Implement the ISampleData.CsvRows property, loading the data from the People.csv file and returning each line as a single string. ❌✔

    /*Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ❌✔
    Using LINQ, skip the first row in the People.csv. ❌✔
    Be sure to appropriately handle resource (IDisposable) items correctly if applicable (and it may not be depending on how you implement it). ❌✔*/
    public IEnumerable<string> CsvRows{
        //File.ReadLines internally handles the resource management and ensures proper disposal of resources once it finishes reading the lines.
        //It's designed to be used without requiring you to manually dispose of resources.
        get
        {
            string csvFilePath = "People.csv";
            return File.ReadLines(csvFilePath).Skip(1);
        }
    }

    /*2. Implement IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() to return a sorted, unique list of states. ❌✔
    Use ISampleData.CsvRows for your data source. ❌✔
    Don't forget the list should be unique. ❌✔
    Sort the list alphabetically. ❌✔
    Include a test that leverages a hardcoded list of addresses. ❌✔
    Include a test that uses LINQ to verify the data is sorted correctly (do not use a hardcoded list). ❌✔*/
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        IEnumerable<String> states = CsvRows.Select(CsvRows => CsvRows.Split(",")[6].Trim()).Distinct().OrderBy(state=>state);
        return states;

    }

    /*3.Implement ISampleData.GetAggregateSortedListOfStatesUsingCsvRows() to return a string that contains a unique, comma separated list of states. ❌✔

    Use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows() for your data source. ❌✔
    Consider "selecting" only the states and calling ToArray() to retrieve an array of all the state names. ❌✔
    Given the array, consider using string.Join to combine the list into a single string. ❌✔*/
    public string GetAggregateSortedListOfStatesUsingCsvRows()
        => throw new NotImplementedException();

    /*4.Implement the ISampleData.People property to return all the items in People.csv as Person objects ❌✔
    Use ISampleData.CsvRows as the source of the data. ❌✔
    Sort the list by State, City, and Zip. (Sort the addresses first then select). ❌✔
    Be sure that Person.Address is also populated. ❌✔
    Adding null validation to all the Person and Address properties is optional.
    Consider using ISampleData.CsvRows in your test to verify your results. ❌✔*/
    public IEnumerable<IPerson> People => throw new NotImplementedException();

    /*5.Implement ISampleDate.FilterByEmailAddress(Predicate<string> filter) to return a list of names where the email address matches the filter. ❌✔
    Use ISampleData.People for your data source. ❌✔*/
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter) => throw new NotImplementedException();

    /*6.Implement ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) to return a string that contains a unique, comma-separated list of states. ❌✔
    Use the people parameter from ISampleData.People property for your data source. ❌✔
    At a minimum, use the System.Linq.Enumerable.Aggregate` LINQ method to create your result. ❌✔
    Don't forget the list should be unique. ❌✔
    It is recommended that, at a minimum, you use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows to validate your result.*/
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people) => throw new NotImplementedException();

    /*7.Given the implementation of Node in Assignment5
    Implement IEnumerable<T> to return all the items in the "circle" of items. ❌✔
    Add an IEnumberable<T> ChildItems(int maximum) method to Node that returns the remaining items with a maximum number of items returned less than maximum.*/
}
