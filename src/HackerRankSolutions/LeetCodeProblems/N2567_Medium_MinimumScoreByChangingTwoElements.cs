using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Sort + solve cases || without sorting, but saving 3 max and 3 min elements
/// <see cref="MinimizeSum"/>
/// 1 loop through array, save:
/// max1 > max2 > max3;
/// min3 > min2 > min1.
/// Then, we again have 3 cases of changing elements:
/// 1. min1, min2 -> min3
/// 2. max1, max2 -> max3
/// 3. min1, max1 -> min2
/// Just find min of 3 cases.
/// ---
/// RT = 1 ms, beats 100.00%.
/// M = 57.86 MB, beats 57.14%.
/// ---
/// Complexity Analysis:
/// O(n), O(1) space.
/// <see cref="MinimizeSum_First"/>
/// After sorting array and that fact, that only 2 elements may be changed, we have 3 cases of changing elements:
/// 1. nums[0], nums[1] -> nums[2]
/// 2. nums[n-1], nums[n-2] -> nums[n-3]
/// 3. nums[0], nums[n-1] -> nums[1]
/// Just find min of 3 cases.
/// ---
/// RT = 58 ms, beats 57.14%.
/// M = 57.48 MB, beats 71.43%.
/// ---
/// Complexity Analysis:
/// O(n*log(n)), O(1) space.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/minimum-score-by-changing-two-elements/")]
public class N2567_Medium_MinimumScoreByChangingTwoElements
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { 1, 4, 7, 8, 5 }, 3);
        yield return new TestCaseData(new [] { 1, 4, 3 }, 0);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        // var ret = MinimizeSum_First(nums);
        var ret = MinimizeSum(nums);
        Assert.That(ret, Is.EqualTo(expected), $"Result calculated incorrectly.");
    }
    
    public int MinimizeSum(int[] nums)
    {
        var n = nums.Length;
        if (n <= 3)
            return 0;

        var max1 = int.MinValue;
        var max2 = int.MinValue;    
        var max3 = int.MinValue;
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;
        var min3 = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] > max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = nums[i];
            }
            else if (nums[i] > max2)
            {
                max3 = max2;
                max2 = nums[i];
            }
            else if (nums[i] > max3)
            {
                max3 = nums[i];
            }

            if (nums[i] < min1)
            {
                min3 = min2;
                min2 = min1;
                min1 = nums[i];
            }
            else if (nums[i] < min2)
            {
                min3 = min2;
                min2 = nums[i];
            }
            else if (nums[i] < min3)
            {
                min3 = nums[i];
            }
        }

        // min1, min2 -> min3
        var f1 = max1 - min3;
        
        // max1, max2 -> max3
        var f2 = max3 - min1;
        
        // min1, max1 -> min2
        var f3 = max2 - min2;

        return Math.Min(f1, Math.Min(f2, f3));
    }
    
    public int MinimizeSum_First(int[] nums)
    {
        var n = nums.Length;
        if (n <= 3)
            return 0;
        
        Array.Sort(nums);

        // nums[0], nums[1] -> nums[2]
        var f1 = nums[n-1] - nums[2];
        
        // nums[n-1], nums[n-2] -> nums[n-3]
        var f2 = nums[n - 3] - nums[0];
        
        // nums[0], nums[n-1] -> nums[1]
        var f3 = nums[n - 2] - nums[1];

        return Math.Min(f1, Math.Min(f2, f3));
    }
}