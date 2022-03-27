using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class ExtraLongFactorials
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(25, "15511210043330985984000000");
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, string expected)
    {
        var factorial = new List<int> {1};

        for (var i = 2; i <= n; i++)
        {
            for (var j = 0; j < factorial.Count; j++)
                factorial[j] *= i;

            for (var j = 0; j < factorial.Count; j++)
            {
                if (factorial[j] < 10) 
                    continue;
                
                if (j == factorial.Count - 1)
                    factorial.Add(0);

                factorial[j + 1] += factorial[j] / 10;
                factorial[j] %= 10;
            }
        }

        factorial.Reverse();
        var result = string.Join("", factorial);

        Assert.AreEqual(expected, result, "Factorial calculated incorrectly.");
    }
}