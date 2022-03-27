using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class StairCase
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(4, new List<string> { "   #", "  ##", " ###", "####" });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, List<string> expected)
    {
        var result = new List<string>();
        for (var i = 1; i <= n; i++)
        {                                
            var begin = new string(' ', n-i);
            var end = new string('#', i);
            result.Add(begin + end);
        }
        
        CollectionAssert.AreEqual(expected, result, "Result calculated incorrectly.");
    }
}