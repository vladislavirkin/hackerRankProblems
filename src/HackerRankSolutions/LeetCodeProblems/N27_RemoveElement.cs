using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy" + "https://leetcode.com/problems/remove-element/")]
public class N27_RemoveElement
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {3,3}, 3, 0, Array.Empty<int>());
        yield return new TestCaseData(new [] {3,2,2,3}, 3, 2, new [] {2, 2});
        yield return new TestCaseData(new [] {0,1,2,2,3,0,4,2}, 2, 5, new [] {0,1,4,0,3});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int val, int expectedCount, int[] expectedNums)
    {
        var ret = RemoveElement(nums, val);
        // var ret = RemoveElementBest(nums, val);

        Assert.That(ret, Is.EqualTo(expectedCount), "Result length calculated incorrectly.");
        Array.Sort(nums, 0, expectedCount);
        Array.Sort(expectedNums, 0, expectedCount);
        for (var i = 0; i < expectedCount; i++)
            Assert.That(nums[i], Is.EqualTo(expectedNums[i]), $"Result {i}/{nums[i]} calculated incorrectly.");
    }
    
    public int RemoveElement(int[] nums, int val)
    {
        var ret = 0;
        
        if (nums.Length == 1 && nums[0] == val)
            return ret;
        
        var n = nums.Length - 1;
        for (var i = 0; i <= n; i++)
        {
            if (nums[i] == val)
            {
                ret++;
                
                for (var j = n; j >= i; j--)
                {
                    if (j == i)
                    {
                        n = j;
                        break;
                    }
                    
                    if (nums[j] != val)
                    {
                        nums[i] = nums[j];
                        n = j - 1;
                        break;
                    }
                    else
                        ret++;
                }
            }
        }

        return nums.Length - ret;
    }
    
    public int RemoveElementBest(int[] nums, int val)
    {
        var k = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if(nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }
}