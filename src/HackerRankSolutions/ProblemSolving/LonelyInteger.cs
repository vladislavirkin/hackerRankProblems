using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class LonelyInteger
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 3, 2, 1 }, 4);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<int> a, int expected)
    {
        var result = 0;
        foreach (var item in a)
            result ^= item;

        Assert.AreEqual(expected, result, "Solving Failed.");
    }
}