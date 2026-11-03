using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="MinMoves"/>
/// RT = 0 ms, beats 100%.
/// M = 44 MB, beats 88%.
/// <see cref="MinMovesM"/>
/// RT = 0 ms, beats 100%.
/// M = 43 MB, beats 100%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/minimum-moves-to-equal-array-elements-iii/")]
public class N3736_MinimumMovesToEqualArrayElements_3
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {2, 1, 3}, 3, 3);
        yield return new TestCaseData(new [] {1, 10, 2, 9}, 18, 10);
        yield return new TestCaseData(new [] {1, 1, 1, 1, 1, 9}, 40, 9);
        yield return new TestCaseData(new [] {4,4,5}, 2, 5);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected, int expectedNumber)
    {
        // var (ret, max) = MinMovesM(nums);
        var (ret, max) = MinMoves(nums);

        Assert.AreEqual(ret, expected, "Result calculated incorrectly.");
        Assert.AreEqual(max, expectedNumber, "Result max calculated incorrectly.");
    }
    
    public (int, int) MinMoves(int[] nums)
    {
        var ret = 0;
        var max = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == max)
                continue;
            
            if (nums[i] < max)
                ret += max - nums[i];
            else
            {
                ret += (nums[i] - max) * i;
                max = nums[i];
            }
        }
        
        return (ret, max);
    }
    
    public (int, int) MinMovesM(int[] nums)
    {
        int n = nums.Length;
        int sum = 0;
        int max = 0;
        foreach(int num in nums)
        {
            sum += num;
            max = Math.Max(max, num);
        }
        return (max * n - sum, max);
    }
}