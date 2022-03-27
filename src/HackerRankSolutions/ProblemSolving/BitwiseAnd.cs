using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class BitwiseAnd
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 2, 1, 3 }, 4);
        yield return new TestCaseData(new List<int> { 0, 2, 4 }, 0);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CountPairs(List<int> arr, int expected)
    {
        var result = 0;

        var dict = new Dictionary<int, int>();
        foreach (var item in arr)
        {
            if (!dict.ContainsKey(item))
                dict.Add(item, 1);
            else
                dict[item]++;
        }

        var list = dict.ToList();

        for (var i = 0; i < list.Count; i++)
        {
            var left = list[i];
            for (var j = i; j < list.Count; j++)
            {
                var right = list[j];
                
                var sum = left.Key & right.Key;
                
                var notsum = (sum & (sum - 1));
                if (sum > 0 && notsum != 1)
                {
                    if (left.Key == right.Key)
                        result += left.Value * (left.Value - 1);
                    else
                        result += left.Value * right.Value;
                }
            }
        }

        Assert.AreEqual(expected, result, "Result calculated incorrectly.");
    }
}