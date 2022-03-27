using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class SalesByMatch
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(7, new List<int> { 1, 2, 1, 2, 1, 3, 2 }, 2);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, List<int> arr, int expected)
    {
        var result = 0;
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < n; ++i)
        {
            if (!dict.ContainsKey(arr[i]))
                dict.Add(arr[i], 1);
            else
                dict[arr[i]]++;

            if (dict[arr[i]] % 2 == 0)
                ++result;
        }

        Assert.AreEqual(expected, result, "Sales calculated incorrectly.");
    }
}