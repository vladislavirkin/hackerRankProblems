using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class SortedSums
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 9, 5, 8 }, 80);
        yield return new TestCaseData(new List<int> { 5, 9 }, 28);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CountPairs(List<int> a, int expected)
    {
        long result = 0;

        for (var i = 1; i <= a.Count; i++)
        {
            var s = a.Take(i).OrderBy(x => x).ToList();

            for (var j = 1; j <= s.Count; j++)
                result += j * s[j-1];
        }

        Assert.AreEqual(expected, result, "Result calculated incorrectly.");
    }
}