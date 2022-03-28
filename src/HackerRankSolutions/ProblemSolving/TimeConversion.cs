using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class TimeConversion
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("07:05:45PM", "19:05:45");
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Convert(string inputTime, string expectedTime)
    {
        var time = DateTime.Parse(inputTime);
        var result = time.ToString("HH:mm:ss");

        Assert.AreEqual(expectedTime, result, "Conversion failed.");
    }
}