using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class AVeryBigSum
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 0, 1, 2, 1, 2, 3 }, 9);
        yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5 }, 15);
        yield return new TestCaseData(new List<int> { 1, 1, 1, 3, 3, 2, 2 }, 13);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CalculateSum(List<int> items, long expectedSum)
    {
        Assert.AreEqual(expectedSum, items.Sum());
    }
}