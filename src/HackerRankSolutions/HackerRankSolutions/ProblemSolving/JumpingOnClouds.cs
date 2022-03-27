using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class JumpingOnClouds
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 0, 0, 1, 0, 0, 1, 0 }, 4);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<int> items, int expected)
    {
        var result = new List<int> {0};

        for (var i = 0; i < items.Count - 2; i++)
        {
            if (i == result.Last())
            {               
                if (items[i + 2] == 0)
                {
                    result.Add(i + 2);
                }
                else if (items[i + 1] == 0)
                {
                    result.Add(i + 1);
                }
            }             
        }

        if (result.Last() != items.Count - 1)
            result.Add(items.Count - 1);
        
        Assert.AreEqual(expected, result.Count - 1, "Wrong number calculated.");
    }
}