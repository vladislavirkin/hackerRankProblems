using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="MaxProfit"/>
/// RT = 1 ms, beats 99%.
/// M = 55 MB, beats 95%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/best-time-to-buy-and-sell-stock/")]
public class N121_Easy_BestTimeToBuyAndSellStock
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {7,1,5,3,6,4}, 5);
        yield return new TestCaseData(new [] {7,6,4,3,1}, 0);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] prices, int expected)
    {
        var ret = MaxProfit(prices);
        
        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public int MaxProfit(int[] prices)
    {
        var ret = 0;
        var first = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] <  first)
                first = prices[i];
            else
                ret = Math.Max(prices[i] - first, ret);
        }
        
        return ret;
    }
}