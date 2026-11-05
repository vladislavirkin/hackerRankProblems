using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea.
/// 0. Sort array 2.
/// 1. Perform a binary search to find the insertion index for each item in arr1.
/// 2. Compare neighbors with the current item to determine if the distance is within the threshold.
/// <see cref="FindTheDistanceValue_First"/>
/// RT = 7 ms, beats 46%.
/// M = 42 MB, beats 86%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/find-the-distance-value-between-two-arrays/")]
public class N1385_RETRY_Easy_FindTheDistanceValueBetweenTwoArrays
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {4, 5, 8}, new [] {10, 9, 1, 8}, 2, 2);
        yield return new TestCaseData(new [] {1, 4, 2, 3}, new [] {-4, -3, 6, 10, 20, 30}, 3, 2);
        yield return new TestCaseData(new [] {2, 1, 100, 3}, new [] {-5, -2, 10, -3, 7}, 6, 1);
        yield return new TestCaseData(new [] {-8, -7}, new [] {4, 10, -4, 5, 2}, 55, 0);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] arr1, int[] arr2, int d, int expected)
    {
        var ret = FindTheDistanceValue_First(arr1, arr2, d);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int FindTheDistanceValue_First(int[] arr1, int[] arr2, int d)
    {
        var ret = 0;
        
        Array.Sort(arr2);

        for (int i = 0; i < arr1.Length; i++)
        {
            var insertIndex = FindInsertIndex(arr2, arr1[i]);
            
            if (insertIndex == arr2.Length)
                ret += Math.Abs(arr1[i] - arr2[insertIndex - 1]) > d ? 1 : 0;
            else if (insertIndex == 0)
                ret += Math.Abs(arr1[i] - arr2[insertIndex]) > d ? 1 : 0;
            else if (Math.Min(Math.Abs(arr1[i] - arr2[insertIndex]), Math.Abs(arr1[i] - arr2[insertIndex - 1])) > d)
                ret++;
        }

        return ret;
    }

    private int FindInsertIndex(int[] arr, int target)
    {
        var min = 0;
        var max = arr.Length - 1;
        while (min <= max)
        {
            var cur = min + (max - min) / 2;

            if (target == arr[cur])
                return cur;

            if (arr[cur] < target)
                min = cur + 1;
            else
                max = cur - 1;
        }

        return min;
    }
}