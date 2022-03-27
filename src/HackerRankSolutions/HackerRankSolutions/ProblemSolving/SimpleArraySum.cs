using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class SimpleArraySum
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 4, 0, 3, 10 }, 17);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<int> items, int expected)
    {
        Assert.AreEqual(expected, items.Sum());
    }
}