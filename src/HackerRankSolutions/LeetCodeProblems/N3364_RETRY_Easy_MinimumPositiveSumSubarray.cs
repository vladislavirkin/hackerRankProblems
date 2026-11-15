using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Sliding window || PrefixSum || BruteForce.
/// All three approaches visit the same candidates. Only the cost of computing S(i,len) changes.
/// <see cref="MinimumSumSubarray_SlidingWindow"/>
/// Fix len and slide the window one step right.
/// Only two elements change: one enters on the right, one leaves on the left.
/// ---
/// O(n*(r-l+1)), O(1) space.
/// ---
/// RT = 8 ms, beats 58.06%.
/// M = 45.80 MB, beats 45.16%.
/// <see cref="MinimumSumSubarray_PrefixSum"/>
/// Precompute once: prefix[i]=Sum(nums[k]), k = [0, i-1].
/// Then any window is a difference of two stored values:
///     S(i,len)=prefix[i+len]−prefix[i]
/// Why this works:
///     prefix[i+len] contains everything up to the end of the window, and prefix[i] contains everything before it.
///     Subtracting leaves exactly the window. Each window now costs O(1), at the price of an O(n) array.
/// ---
/// O(n*(r-l+1)), O(n) space.
/// ---
/// RT = 3 ms, beats 90.32%.
/// M = 45.59 MB, beats 48.39%.
/// <see cref="MinimumSumSubarray_BruteForce"/>
/// For every window, add its len elements from scratch.
/// Simple and obviously correct, but it repeats work:
///     two neighboring windows overlap in len−1 elements, and we add those again and again.
/// ---
/// O(n*(r-l+1)*r), O(1) space.
/// ---
/// RT = 13 ms, beats 12.90%.
/// M = 44.99 MB, beats 74.19%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/minimum-positive-sum-subarray/")]
public class N3364_RETRY_Easy_MinimumPositiveSumSubarray
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 3, -2, 1, 4 }, 2, 3, 1);
        yield return new TestCaseData(new List<int> { -2, 2, -3, 1 }, 2, 3, -1);
        yield return new TestCaseData(new List<int> { 1, 2, 3, 4 }, 2, 4, 3);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(IList<int> nums, int l, int r, int expected)
    {
        // var ret = MinimumSumSubarray_BruteForce(nums, l, r);
        // var ret = MinimumSumSubarray_PrefixSum(nums, l, r);
        var ret = MinimumSumSubarray_SlidingWindow(nums, l, r);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int MinimumSumSubarray_SlidingWindow(IList<int> nums, int l, int r)
    {
        var ret = int.MaxValue;

        var n = nums.Count;

        for (int len = l; len <= r; len++)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                if (i >= len)
                    sum -= nums[i - len];
                
                if (i >= len - 1 && sum > 0 && sum < ret)
                    ret = sum;
            }
        }
        
        return ret == int.MaxValue ? -1 : ret;
    }
    
    public int MinimumSumSubarray_PrefixSum(IList<int> nums, int l, int r)
    {
        var ret = int.MaxValue;

        var n = nums.Count;

        // Improve RT up to 1 ms, 100%.
        // Span<int> prefix = stackalloc int[nums.Count + 1];
        var prefix = new int[n+1];
        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] + nums[i];
        
        for (int len = l; len <= r; len++)
        {
            for (int i = 0; i + len <= n; i++)
            {
                int sum = prefix[i + len] - prefix[i];
                if (sum > 0 && sum < ret)
                    ret = sum;
            }
        }
        
        return ret == int.MaxValue ? -1 : ret;
    }
    
    public int MinimumSumSubarray_BruteForce(IList<int> nums, int l, int r)
    {
        var ret = int.MaxValue;

        var n = nums.Count;

        for (int len = l; len <= r; len++)
        {
            for (int i = 0; i + len <= n; i++)
            {
                int sum = 0;
                for (int k = i; k < i + len; k++)
                    sum += nums[k];
                if (sum > 0 && sum < ret)
                    ret = sum;
            }
        }
        
        return ret == int.MaxValue ? -1 : ret;
    }
}