using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="SingleNumber"/>
/// RT = 13 ms, beats 24%.
/// M = 49 MB, beats 23%.
/// <see cref="SingleNumberRT"/>
/// RT = 0 ms, beats 100%.
/// M = 46 MB, beats 89%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/single-number/")]
public class N136_Pack_Xor_Easy_SingleNumber
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {2,2,1}, 1);
        yield return new TestCaseData(new [] {4,1,2,1,2}, 4);
        yield return new TestCaseData(new [] {1}, 1);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        var ret = SingleNumber(nums);
        // var ret = SingleNumberRT(nums);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public int SingleNumber(int[] nums)
    {
        var hashset = new HashSet<int>();

        foreach (var num in nums)
            if (!hashset.Add(num))
                hashset.Remove(num);

        return hashset.First();
    }
    
    /// <summary>
    /// We XOR all the numbers. same will produce 0, only different will add up.
    /// </summary>
    public int SingleNumberRT(int[] nums)
    {
        int result = 0;

        for(int i = 0; i < nums.Length; i++)
            result ^= nums[i];

        return result;
    }
}