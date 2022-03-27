using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.OneWeekPreparationKit;

[TestFixture]
public class PlusMinus
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 1, 0, -1, -1 }, new List<string> { "0,400000", "0,400000", "0,200000" });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<int> arr, List<string> expected)
    {
        var length = arr.Count;
        
        var positives = (double)arr.Count(x => x > 0) / length;
        var negatives = (double)arr.Count(x => x < 0) / length;
        var zeroes = (double)arr.Count(x => x == 0) / length;
        
        Assert.AreEqual(expected[0], positives.ToString("N" + 6), "Wrong positives count.");
        Assert.AreEqual(expected[1], negatives.ToString("N" + 6), "Wrong negatives count.");
        Assert.AreEqual(expected[2], zeroes.ToString("N" + 6), "Wrong zeroes count.");
    }
}