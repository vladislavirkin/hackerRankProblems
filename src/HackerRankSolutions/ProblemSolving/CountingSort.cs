using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class CountingSort
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 0, 1, 2, 1, 2, 3 }, new List<int> { 1, 2, 2, 1 });
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<int> items, List<int> frequencyList)
    {
        var ret = Enumerable.Repeat(0, items.Max() + 1).ToList();

        foreach (var t in items)
            ret[t]++;

        Assert.AreEqual(frequencyList, ret, "Frequency list calculated incorrectly.");
    }
}