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
}

