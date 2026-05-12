using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Medium" + "https://leetcode.com/problems/jump-game-ix/")]
public class N3660_WIP_Medium_JumpGameIX
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {2,1,3}, new [] {2,2,3});
        yield return new TestCaseData(new [] {2,3,1}, new [] {3,3,3});
    }
    
    [Test]
    [Ignore("WIP")]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int[] expectedNums)
    {
        var ret = MaxValue(nums);
        
        Assert.AreEqual(ret, expectedNums, "Result calculated incorrectly.");
    }
    
    
    public int[] MaxValue(int[] nums)
    {
        var n = nums.Length;
        if (n <= 1)
            return nums;
        
        var ret = new int[n];

        int maxindex = n - 1;
        int minindex = n - 1;
        int max = nums[n - 1];
        int min = nums[n - 1];

        for (int i = n - 2; i >= 0; i--)
        {
            if (nums[i] >= max)
            {
                ret[i] = max;
            }
        }
        
        return nums;
    }
}