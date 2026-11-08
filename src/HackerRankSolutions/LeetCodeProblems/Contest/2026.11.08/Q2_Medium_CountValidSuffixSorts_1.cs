using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems.Contest._2026._11._08;

/// <summary>
/// <see cref="CountSuffix"/>
/// RT = 248 ms, beats 46%.
/// M = 81 MB, beats 86%.
/// </summary>
[TestFixture]
public class Q2_Medium_CountValidSuffixSorts_1
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 2, 3}, new [] {3, 2, 1}, 1);
        yield return new TestCaseData(new [] {1}, new [] {1}, 1);
        yield return new TestCaseData(new [] {1, 5, 6, 4, 6}, new [] {1, 5, 6, 6, 4}, 2);
        yield return new TestCaseData(new [] {7, 6, 8}, new [] {8, 6, 7}, 0);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int[] target, int expected)
    {
        var ret = CountSuffix(nums, target);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int CountSuffix(int[] nums, int[] target)
    {
        var n = nums.Length;

        var numsSorted = (int[])nums.Clone();
        Array.Sort(numsSorted);
        var targetSorted = (int[])target.Clone();
        Array.Sort(targetSorted);

        for (var i = 0; i < n; i++)
        {
            if (numsSorted[i] != targetSorted[i])
                return 0;
        }

        var k = n - 1;
        for (var i = 0; i < n; i++)
        {
            if (nums[i] != target[i])
            {
                k = i;
                break;
            }
        } 

        var l = n-1;
        while (l >= 1 && target[l] <= target[l-1])
            l--;
        
        return Math.Max(0, k - l + 1);
    }
}