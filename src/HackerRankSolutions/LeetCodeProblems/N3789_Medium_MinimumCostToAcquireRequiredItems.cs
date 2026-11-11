using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="MinimumCost"/>
/// RT = 0 ms, beats 100%.
/// M = 28 MB, beats 85%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/minimum-cost-to-acquire-required-items/")]
public class N3789_Medium_MinimumCostToAcquireRequiredItems
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(3, 2, 1, 3, 2, 3);
        yield return new TestCaseData(5, 4, 15, 2, 3, 22);
        yield return new TestCaseData(5, 4, 15, 0, 0, 0);
        yield return new TestCaseData(388168, 988887, 336014, 50411, 252237, 84755163318);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int cost1, int cost2, int costBoth, int need1, int need2, long expected)
    {
        var ret = MinimumCost(cost1, cost2, costBoth, need1, need2);

        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public long MinimumCost(int cost1, int cost2, int costBoth, int need1, int need2)
    {
        long ret = 0;
        
        if (need1 == 0 && need2 == 0)
            return ret;

        if (need1 <= need2)
            ret = Math.Min((long)cost1 * need1 + (long)cost2 * need2, (long)costBoth * need1 + (long)Math.Min(costBoth, cost2) * (need2 - need1));
        else
            ret = Math.Min((long)cost1 * need1 + (long)cost2 * need2, (long)costBoth * need2 + (long)Math.Min(costBoth, cost1) * (need1 - need2));

        return ret;
    }
}