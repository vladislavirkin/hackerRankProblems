using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy" + "https://leetcode.com/problems/search-insert-position/")]
public class N35_SearchInsertPosition
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 3, 5, 6}, 5, 2);
        yield return new TestCaseData(new [] {1, 3, 5, 6}, 2, 1);
        yield return new TestCaseData(new [] {1, 3, 5, 6}, 7, 4);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int target, int expected)
    {
        var ret = SearchInsert(nums, target);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public int SearchInsert(int[] nums, int target)
    { 
        var last = nums.Length - 1;
        var prev = 0;
        while (prev <= last)
        {
            var cur = prev + (last - prev) / 2;

            if (nums[cur] == target)
                return cur;

            if (nums[cur] < target)
                prev = cur + 1;
            else
                last = cur - 1;
        }
        
        return prev;
    }
}