using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// PrefixCounts || PrefixSum.
/// <see cref="NumOfSubarrays_PrefixSum"/>
/// Instead of checking all previous indices i with a loop,
/// just keep track of how many even and odd prefix sums you have seen so far:
///     If the current prefix sum is odd, it forms an odd subarray with every previous even prefix sum.
///     If the current prefix sum is even, it forms an odd subarray with every previous odd prefix sum.
/// ---
/// O(n), O(1) space.
/// ---
/// RT = 4 ms, beats 100%.
/// M = 61.02 MB, beats 100%.
/// <see cref="NumOfSubarrays_PrefixSum"/>
/// Calculate prefix parity, then count odd/even subarrays.
/// ---
/// O(n^2), O(n) space.
/// ---
/// Time limit exceeded.
/// RT = - ms, beats 0%.
/// M = - MB, beats 0%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/minimum-positive-sum-subarray/")]
public class N1524_RETRY_Medium_NumberOfSubArraysWithOddSum
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { 1, 3, 5 }, 4);
        yield return new TestCaseData(new [] { 2, 4, 6 }, 0);
        yield return new TestCaseData(new [] { 1, 2, 3, 4, 5, 6, 7 }, 16);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] arr, int expected)
    {
        // var ret = NumOfSubarrays_PrefixSum(arr);
        var ret = NumOfSubarrays_PrefixCounts(arr);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int NumOfSubarrays_PrefixCounts(int[] arr)
    {
        long ret = 0;
        const int LIM = 1_000_000_007;
        
        var evenCount = 1;
        var oddCount = 0;
        var parity = 0;

        foreach (var i in arr)
        {
            parity ^= i & 1;

            if (parity == 1)
            {
                ret += evenCount;
                oddCount++;
            }
            else
            {
                ret += oddCount;
                evenCount++;
            }
        }

        return (int)(ret % LIM);
    }
    
    public int NumOfSubarrays_PrefixSum(int[] arr)
    {
        var ret = 0;
        const int LIM = 1_000_000_007;

        var n = arr.Length;
        
        var prefix = new int[n+1];
        for (int i = 0; i < n; i++)
            prefix[i + 1] = (prefix[i] ^ arr[i]) & 1;
        
        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i + len <= n; i++)
            {
                int sum = prefix[i + len] ^ prefix[i];
                if (sum == 1)
                {
                    if (ret == LIM - 1)
                        ret = 0;
                    else
                        ret++;
                } 
            }
        }

        return ret;
    }
}