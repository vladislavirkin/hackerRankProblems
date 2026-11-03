using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// RT = 12 ms, beats 78%.
/// M = 43 MB, beats 93%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/")]
public class N462_Medium_MinimumMovesToEqualArrayElements_2
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 2, 3}, 2, 2);
        yield return new TestCaseData(new [] {1, 10, 2, 9}, 16, 5);
        yield return new TestCaseData(new [] {1, 1, 1, 1, 1, 9}, 8, 1);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected, int expectedNumber)
    {
        var (ret, med) = MinMoves2(nums);

        Assert.AreEqual(ret, expected, "Result calculated incorrectly.");
        Assert.AreEqual(med, expectedNumber, "Result median calculated incorrectly.");
    }
    
    public (int, int) MinMoves2(int[] nums)
    {
        Array.Sort(nums);

        var length = nums.Length;
        var med = length % 2 == 0 ? (nums[length / 2] + nums[length / 2 - 1]) / 2 : nums[(length - 1) / 2];
        
        var ret = 0;
        for (var i = 0; i < length; i++)
            ret += Math.Abs(nums[i] - med);
        
        return (ret, med);
    }
}