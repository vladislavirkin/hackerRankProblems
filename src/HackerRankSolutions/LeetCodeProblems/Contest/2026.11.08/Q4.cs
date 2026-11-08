using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems.Contest._2026._11._08;

[TestFixture]
public class Q4
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("abac", 10);
        yield return new TestCaseData("abc", 5);
        yield return new TestCaseData("ac", 3);
        yield return new TestCaseData("aabc", 8);
        yield return new TestCaseData("abcaa", 12);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, long expected)
    {
        var ret = 0;
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
}