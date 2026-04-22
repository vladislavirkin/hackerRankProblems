using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy"+"https://leetcode.com/problems/remove-duplicates-from-sorted-array/")]
public class N26_RemoveDuplicatesFromSortedArray
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 1, 2}, 2, new [] {1, 2});
        yield return new TestCaseData(new [] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4}, 5, new [] {0, 1, 2, 3, 4});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int k, int[] expectedNums)
    {
        var ret = RemoveDuplicates(nums);

        Assert.AreEqual(ret, k, "Result length calculated incorrectly.");
        for (var i = 0; i < k; i++)
            Assert.AreEqual(nums[i], expectedNums[i], $"Result {i}/{nums[i]} calculated incorrectly.");
    }
    
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 1)
            return 1;
        
        var ret = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[ret] != nums[i])
                nums[++ret] = nums[i];
        }

        // GC.Collect(); beats 100% memory
        return ret + 1;
    }
}