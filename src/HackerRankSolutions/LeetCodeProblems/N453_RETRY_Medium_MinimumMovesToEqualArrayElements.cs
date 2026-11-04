using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea.
/// 0. In general, sum >= min * nums.Length. And equality holds if all elements are equal.
/// 1. k increments moves min to min + k, and sum to sum + k * (nums.Length - 1).
/// 2. Let's assume, that k is the number of increments required to achieve equality.
/// 3. Therefore, sum + k * (nums.Length - 1) = (min + k) * nums.Length.
/// 4. Or, k = number of moves = sum - min * nums.Length.
/// <see cref="MinMoves"/>
/// RT = 0 ms, beats 100%.
/// M = 51 MB, beats 86%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/minimum-moves-to-equal-array-elements/")]
public class N453_RETRY_Medium_MinimumMovesToEqualArrayElements
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 2, 3}, 3);
        yield return new TestCaseData(new [] {1, 1, 1, 1, 1}, 0);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        var ret = MinMoves(nums);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int MinMoves(int[] nums)
    {
        var sum = 0;
        var min = int.MaxValue;
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < min)
                min = nums[i];
            sum += nums[i];
        }

        return sum - min * nums.Length;
    }
}