using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class TruckTour
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<List<int>> { new() { 1, 5 }, new() { 10, 3 }, new() { 3, 4 } }, 1);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CalculateMiniMaxSum(List<List<int>> arr, int expected)
    {
        var result = 0;

        var amount = 0;
        for (var i = 0; i < arr.Count; i++)
        {
            amount += arr[i][0] - arr[i][1];
            
            if (amount < 0)
            {
                amount = 0;
                result = i + 1;
            }
        }

        Assert.AreEqual(expected, result, "Result calculated incorrectly.");
    }
}