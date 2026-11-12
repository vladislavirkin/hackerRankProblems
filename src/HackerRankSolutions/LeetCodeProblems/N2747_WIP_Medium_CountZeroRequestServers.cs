using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea.
/// <see cref="CountServers"/>
/// RT = 7 ms, beats 46%.
/// M = 42 MB, beats 86%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/count-zero-request-servers/")]
public class N2747_WIP_Medium_CountZeroRequestServers
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(
            3, new [] {new [] {1, 3},new [] {2, 6}, new [] {1, 5}}, 5, new [] {10, 11}, new [] {1, 2});
        yield return new TestCaseData(
            3, new [] {new [] {2, 4},new [] {2, 1}, new [] {1, 2}, new [] {3, 1}}, 2, new [] {3, 4}, new [] {0, 1});
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, int[][] logs, int x, int[] queries, int[] expected)
    {
        var ret = CountServers(n, logs, x, queries);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int[] CountServers(int n, int[][] logs, int x, int[] queries)
    {
        return [];
    }
}