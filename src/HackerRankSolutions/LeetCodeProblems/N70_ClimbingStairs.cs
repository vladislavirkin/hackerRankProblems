using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="ClimbStairs"/>
/// RT = 0 ms, beats 100%.
/// M = 28 MB, beats 93%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/climbing-stairs/")]
public class N70_ClimbingStairs
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(2, 2);
        yield return new TestCaseData(3, 3);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, int expected)
    {
        var ret = ClimbStairs(n);
        // var ret = ClimbStairsRecursion(n);

        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;

        var previous = 2;
        var preprevious = 1;
        var cur = 0;

        for (int i = 3; i <= n; i++)
        {
            cur = previous + preprevious;
            preprevious = previous;
            previous = cur;
        }

        return cur;
    }
    
    public int ClimbStairsRecursion(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return ClimbStairsRecursion(n - 1) + ClimbStairsRecursion(n - 2);
    }
}