using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class CompareTheTriplets
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 2, 3 }, new List<int> { 3, 2, 1 }, new List<int> { 1, 1 });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public static void CompareTriplets(List<int> a, List<int> b, List<int> expected)
    {
        var result = new List<int> { 0, 0 };
        
        for (var i = 0; i < a.Count; i++)
        {
            if (a[i] < b[i])
                result[1]++;

            if (a[i] > b[i])
                result[0]++;
        }
        
        CollectionAssert.AreEqual(expected, result, " calculated incorrectly.");
    }
}