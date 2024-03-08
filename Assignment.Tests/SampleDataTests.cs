using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Tests;
public class SampleDataTests
{
    [Fact]
    public void SkippingFirstRow_PeopleCSV_Successful()
    {
        SampleData data = new ();
        var csvRows = data.CsvRows;
        Assert.NotNull(csvRows);
        Assert.DoesNotContain(csvRows.First(), "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
    }
    [Fact]
    public void GetUniqueSortedListOfStates_GivenTestCsvRows_Successful()
    {
        SampleData sampleData = new();
        // Arrange
        List<string> csvRows =
        [
             "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
         ];

        // Mock the behavior of the CsvRows property
        sampleData.CsvRows = csvRows;

        // Act
        var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        var expectedStates = new List<string> { "CA", "FL", "MT" };
        Assert.Equal(expectedStates, result);
    }
    [Fact]
    public void GetAggregateSortedListOfStates_UsingTestCsvRows_Successful()
    {
        SampleData sampleData = new();
        // Arrange
        List<string> csvRows =
        [
             "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
         ];

        // Mock the behavior of the CsvRows property
        sampleData.CsvRows = csvRows;

        // Act
        string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        string expectedStates = "CA,FL,MT";
        Assert.Equal(expectedStates, result);
    }
    [Fact]
    public void People_UsingTestCsv_Successful()
    {
        SampleData sampleData = new();
        // Arrange
        List<string> csvRows =
        [
             "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
         ];

        // Mock the behavior of the CsvRows property
        sampleData.CsvRows = csvRows;

        // Act
        IEnumerable<IPerson> result = sampleData.People;

        // Assert
        IEnumerable<IPerson> expected = new List<IPerson>();
        expected = expected.Append(new Person("Chadd", "Stennine", new Address("94148 Kings Terrace", "Long Beach", "CA", "59721"), "cstennine2@wired.com"));
        expected = expected.Append(new Person("Karin", "Joder", new Address("03594 Florence Park", "Tampa", "FL", "71961"), "kjoder1@quantcast.com"));
        expected = expected.Append(new Person("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0@state.gov"));
        Assert.Equal(expected.ElementAt(0).FirstName, result.ElementAt(0).FirstName);
        Assert.Equal(expected.ElementAt(0).LastName, result.ElementAt(0).LastName);
        Assert.Equal(expected.ElementAt(0).EmailAddress, result.ElementAt(0).EmailAddress);
        Assert.Equal(expected.ElementAt(0).Address.StreetAddress, result.ElementAt(0).Address.StreetAddress);
        Assert.Equal(expected.ElementAt(0).Address.City, result.ElementAt(0).Address.City);
        Assert.Equal(expected.ElementAt(0).Address.State, result.ElementAt(0).Address.State);
        Assert.Equal(expected.ElementAt(0).Address.Zip, result.ElementAt(0).Address.Zip);
        Assert.Equal(expected.ElementAt(1).FirstName, result.ElementAt(1).FirstName);
        Assert.Equal(expected.ElementAt(1).LastName, result.ElementAt(1).LastName);
        Assert.Equal(expected.ElementAt(1).EmailAddress, result.ElementAt(1).EmailAddress);
        Assert.Equal(expected.ElementAt(1).Address.StreetAddress, result.ElementAt(1).Address.StreetAddress);
        Assert.Equal(expected.ElementAt(1).Address.City, result.ElementAt(1).Address.City);
        Assert.Equal(expected.ElementAt(1).Address.State, result.ElementAt(1).Address.State);
        Assert.Equal(expected.ElementAt(1).Address.Zip, result.ElementAt(1).Address.Zip);
        Assert.Equal(expected.ElementAt(2).FirstName, result.ElementAt(2).FirstName);
        Assert.Equal(expected.ElementAt(2).LastName, result.ElementAt(2).LastName);
        Assert.Equal(expected.ElementAt(2).EmailAddress, result.ElementAt(2).EmailAddress);
        Assert.Equal(expected.ElementAt(2).Address.StreetAddress, result.ElementAt(2).Address.StreetAddress);
        Assert.Equal(expected.ElementAt(2).Address.City, result.ElementAt(2).Address.City);
        Assert.Equal(expected.ElementAt(2).Address.State, result.ElementAt(2).Address.State);
        Assert.Equal(expected.ElementAt(2).Address.Zip, result.ElementAt(2).Address.Zip);
    }

    [Fact]
    public void GetUniqueSortedListOfStates_GivenActualCsvRows_Successful()
    {
        SampleData sampleData = new();

        // Act
        var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        var expectedStates = new List<string>();
        string expectedStatesString = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
        string[] expectedStatesArray = expectedStatesString.Split(',');
        for(int i = 0; i < expectedStatesArray.Length; i++)
        {
            expectedStates.Add(expectedStatesArray[i]);
        }

        // Assert
        Assert.Equal(expectedStates, result);
    }
    [Fact]
    public void GetAggregateSortedListOfStates_UsingActualCsvRows_Successful()
    {
        SampleData sampleData = new();

        // Act
        string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        string expectedStates = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";
        Assert.Equal(expectedStates, result);
    }
    [Fact]
    public void People_UsingActualCsv_Successful()
    {
        SampleData sampleData = new();

        // Act
        IEnumerable<IPerson> result = sampleData.People;

        // Assert
        IEnumerable<IPerson> expected = new List<IPerson>();

    }

    [Fact]
    public void EmailFilter_WithCSVAndFilter_Successful()
    {
        SampleData sampleData = new();
        // Arrange
        List<string> csvRows =
        [
             "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
        ];
        // Mock the behavior of the CsvRows property
        sampleData.CsvRows = csvRows;
        Predicate<string> filter = email => email.EndsWith(".com", StringComparison.OrdinalIgnoreCase);

        //Act
        var matches = sampleData.FilterByEmailAddress(filter).ToList();

        //Assert
        Assert.Equal(2, matches.Count);
        Assert.Equal(("Chadd", "Stennine"), matches[0]);
        Assert.Equal(("Karin", "Joder"), matches[1]);
    }

    [Fact]
    public void GetAggregateListOfStates_GivenPeopleCollection_Successful()
    {
        SampleData sampleData = new();
        // Arrange
        List<string> csvRows =
        [
             "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
         ];

        // Mock the behavior of the CsvRows property
        sampleData.CsvRows = csvRows;

        // Act
        string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

        // Assert
        string expectedStates = "CA,FL,MT";
        Assert.Equal(expectedStates, result);
    }

    [Fact]
    public void AggregateListOfStates_GivenPeopleAndCsv_Equal()
    {
        SampleData sampleData = new();
        // Arrange
        List<string> csvRows =
        [
             "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
         ];

        // Mock the behavior of the CsvRows property
        sampleData.CsvRows = csvRows;

        // Act
        string cresult = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        string presult = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);

        // Assert
        Assert.Equal(cresult, presult);
    }
}

