using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="ClimbStairs_Best"/>
/// RT = 6 ms, beats 100%.
/// M = 70 MB, beats 78%.
/// <see cref="ClimbStairs"/>
/// RT = 44 ms, beats 44%.
/// M = 75 MB, beats 44%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/climbing-stairs-ii/")]
public class N3693_Medium_Climbing_Stairs_Il
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(4, new [] { 1, 2, 3, 4 }, 13);
        yield return new TestCaseData(4, new [] { 5, 1, 6, 2 }, 11);
        yield return new TestCaseData(3, new [] { 9, 8, 3 }, 12);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, int[] costs, int expected)
    {
        // var ret = ClimbStairs_Best(n, costs);
        var ret = ClimbStairs(n, costs);

        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int ClimbStairs_Best(int n, int[] costs)
    {
        int a = 0, b = 0, c = 0;
        
        for (var i = 0; i < n; ++i)
        {
            var next = Math.Min(Math.Min(a + 9, b + 4), c + 1) + costs[i];
            a = b;
            b = c;
            c = next;
        }
        
        return c;
    }
    
    public int ClimbStairs(int n, int[] costs)
    {
        var dp = new int[n+1];

        dp[0] = 0;
        dp[1] = costs[0] + 1;
        
        if (n == 1)
            return dp[1];
        
        for (var i = 2; i < n + 1; i++)
            dp[i] = 0;

        return Calculate(n, costs, dp);
    }

    private int Calculate(int cur, int[] costs, int[] dp)
    {
        if (dp[cur] != 0 || cur == 0)
            return dp[cur];

        if (cur == 2)
        {
            dp[cur] = Math.Min(dp[1] + costs[cur - 1] + 1, dp[0] + costs[cur - 1] + 4);
            return dp[cur];
        }
            
        dp[cur] = Math.Min(
            Calculate(cur - 1, costs, dp) + costs[cur - 1] + 1,
            Math.Min(
                Calculate(cur - 2, costs, dp) + costs[cur - 1] + 4,
                Calculate(cur - 3, costs, dp) + costs[cur - 1] + 9));
        return dp[cur];
    }
}