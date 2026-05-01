using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Hard" + "https://leetcode.com/problems/maximum-score-from-grid-operations/")]
public class N3225_MaximumScoreFromGridOperations
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { new [] {0,0,0,0,0}, new [] {0,0,3,0,0}, new [] {0,1,0,0,0}, new [] {5,0,0,3,0}, new [] {0,0,0,0,2}}, 11);
        yield return new TestCaseData(new [] { new [] {10,9,0,0,15}, new [] {7,1,0,8,0}, new [] {5,20,0,11,0}, new [] {0,0,0,1,2}, new [] {8,12,1,10,3}}, 94);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[][] grid, long expected)
    {
        var ret = MaximumScore(grid);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public long MaximumScore(int[][] grid)
    {
        var ret = 0;
        return ret;
    }
}