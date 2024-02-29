using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Tests;
public class SampleDataTests
{
    [Fact]
    public void SkipingFirstRow_PeopleCSV_Successful()
    {
        SampleData data = new ();
        var csvRows = data.CsvRows;
        Assert.NotNull(csvRows);
        Assert.DoesNotContain(csvRows.First(), "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
    }
    [Fact]
    public void TestGetUniqueSortedListOfStatesGivenCsvRows()
    {
        SampleData sampleData = new();
        // Arrange
        List<String> csvRows =
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

}

