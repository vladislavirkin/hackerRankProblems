using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea.
/// <see cref="MinOperations"/>
/// RT = 0 ms, beats 100%.
/// M = 51 MB, beats 86%.
/// </summary>
[TestFixture(Description = "Hard" + "https://leetcode.com/problems/minimum-operations-to-make-elements-within-k-subarrays-equal/")]
public class N3505_WIP_Hard_MinimumOperationsToMakeElementsWithinKSubarraysEqual
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { 5, -2, 1, 3, 7, 3, 6, 4, -1 }, 3, 2, 8);
        yield return new TestCaseData(new [] { 9, -2, -2, -2, 1, 5 }, 2, 2, 3);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int x, int k, int expected)
    {
        var ret = MinOperations(nums, x, k);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public long MinOperations(int[] nums, int x, int k)
    {
        return 0;
    }
}