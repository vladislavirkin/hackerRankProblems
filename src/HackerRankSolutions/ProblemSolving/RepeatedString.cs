using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class RepeatedString
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("aba", 10, 7);
        yield return new TestCaseData("a", 1000000000000, 1000000000000);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, long n, long expected)
    {
        var strSize = s.Length;
        long quotient = n / strSize;
        long remaider = n - strSize * quotient;

        long counter = 0;
        for (var i = 0; i < strSize; i++)
        {                               
            if (s[i] == 'a')
                counter++;
        }

        counter = quotient * counter;

        for (var i = 0; i < remaider; i++)
        {
            if (s[i] == 'a')
                counter++;
        }
        
        Assert.AreEqual(expected, counter, "Wrong number calculated.");
    }
}