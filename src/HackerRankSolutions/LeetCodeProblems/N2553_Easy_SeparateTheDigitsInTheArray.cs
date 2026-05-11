using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="SeparateDigits"/>
/// RT = 1 ms, beats 100%.
/// M = 50 MB, beats 80%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/separate-the-digits-in-an-array/")]
public class N2553_Easy_SeparateTheDigitsInTheArray
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {13,25,83,77},  new [] {1,3,2,5,8,3,7,7});
        yield return new TestCaseData(new [] {7,1,3,9},  new [] {7,1,3,9});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int[] expected)
    {
        var ret = SeparateDigits(nums);
        
        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public int[] SeparateDigits(int[] nums)
    {
        var ret = new List<int>();

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            int digit = nums[i];
            while ( digit> 0)
            {
                ret.Add(digit % 10);
                digit /= 10;
            }
        }
            
        ret.Reverse();
        return ret.ToArray();
    }
}