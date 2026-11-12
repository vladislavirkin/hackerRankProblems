using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Just if-else cases.
/// <see cref="LongestMonotonicSubarray"/>
/// RT = 0 ms, beats 100%.
/// M = 43 MB, beats 71%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/")]
public class N3105_Easy_LongestStrictlyIncreasingOrStrictlyDecreasingSubarray
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { 1, 4, 3, 3, 2 }, 2);
        yield return new TestCaseData(new [] { 3, 3, 3, 3 }, 1);
        yield return new TestCaseData(new [] { 3, 2, 1 }, 3);
        yield return new TestCaseData(new [] { 1, 1, 5 }, 2);
        yield return new TestCaseData(new [] { 1, 9, 7, 1 }, 3);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        var ret = LongestMonotonicSubarray(nums);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int LongestMonotonicSubarray(int[] nums)
    {
        var ret = 1;

        if (nums.Length == 1)
            return ret;
        
        var cur = 1;
        var pattern = 0; // 0 - unknown, 1 - increasing, -1 - decreasing.
        
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                if (pattern == 1 || pattern == 0)
                {
                    cur++;
                }
                else
                {
                    ret = Math.Max(ret, cur);
                    cur = 2;
                }

                pattern = 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                if (pattern == -1 || pattern == 0)
                {
                    cur++;
                }
                else
                {
                    ret = Math.Max(ret, cur);
                    cur = 2;
                }

                pattern = -1;
            }
            else
            {
                if (pattern == 0)
                {
                    // nothing.
                }
                else
                {
                    ret = Math.Max(ret, cur);
                }

                cur = 1;
                pattern = 0;
            }
        }

        return Math.Max(ret, cur);
    }
}