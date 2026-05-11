using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// RT = 0 ms, beats 100%.
/// M = 47 MB, beats 90%. Всегда разные значения при отправки на сервера литкода.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/merge-sorted-array/")]
public class N88_MergeSortedArray
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1,2,3,0,0,0}, 3, new [] {2,5,6}, 3, new [] {1,2,2,3,5,6});
        yield return new TestCaseData(new [] {1}, 1, Array.Empty<int>(), 0, new [] {1});
        yield return new TestCaseData(new [] {0}, 0, new [] {1}, 1, new [] {1});
        yield return new TestCaseData(new [] {2,0}, 1, new [] {1}, 1, new [] {1,2});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        Merge(nums1, m, nums2, n);

        Assert.That(nums1, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0)
            return;

        if (m == 0)
        {
            for (int j = 0; j < n; j++)
                nums1[j] = nums2[j];
            return;
        }

        int i = m + n - 1;
        m -= 1;
        n -= 1;
        
        while (n >= 0)
        {
            if (m >= 0 && nums1[m] >= nums2[n])
                nums1[i--] = nums1[m--];
            else
                nums1[i--] = nums2[n--];
        }
    }
}