using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// RT = 2 ms, beats 100%.
/// M = 60 MB, beats 60%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/rotate-function/")]
public class N396_RotateFunction
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {4,3,2,6}, 26);
        yield return new TestCaseData(new [] {100}, 0);
        yield return new TestCaseData(new [] {4,15,14,3,14,-8,12,-9,17,-1,15,1,10,19,-7,15,8,7,-8,11}, 1511);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        var ret = MaxRotateFunction(nums);

        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public int MaxRotateFunction(int[] nums)
    {
        int f = 0;
        int n = nums.Length;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            f += i * nums[i];
        }
        
        int ret = f;
        for (int i = 1; i < n; i++)
        {
            f += sum - n * nums[n-i];
            ret = Math.Max(ret, f);
        }
        
        return ret;
    }
}