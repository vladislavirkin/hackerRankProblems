using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Hard" + "https://leetcode.com/problems/minimum-initial-energy-to-finish-tasks/")]
public class N1665_WIP_Hard_MinimumInitialEnergyToFinishTasks
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {new [] {1,2}, new [] {2,4}, new [] {4,8}}, 8);
        yield return new TestCaseData(new [] {new [] {1,3}, new [] {2,4}, new [] {10,11}, new [] {10,12},new [] {8,9}}, 32);
        yield return new TestCaseData(new [] {new [] {1,7}, new [] {2,8}, new [] {3,9}, new [] {4,10}, new [] {5,11}, new [] {6,12}}, 27);
    }
    
    [Test]
    [Ignore("WIP")]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[][] grid, int expected)
    {
        var ret = MinimumEffort(grid);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public int MinimumEffort(int[][] tasks)
    {
        return -1;
    }
}