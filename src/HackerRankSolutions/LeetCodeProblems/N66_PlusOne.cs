using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// RT = 0 ms, beats 100%.
/// M = 46 MB, beats 90%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/plus-one/")]
public class N66_PlusOne
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1,2,3}, new [] {1,2,4});
        yield return new TestCaseData(new [] {4,3,2,1}, new [] {4,3,2,2});
        yield return new TestCaseData(new [] {9}, new [] {1,0});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int[] expectedNums)
    {
        var ret = PlusOne(nums);

        Assert.That(ret, Is.EquivalentTo(expectedNums), "Result length calculated incorrectly.");
    }
    
    public int[] PlusOne(int[] digits)
    {
        var findEnd = false;
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] == 9)
            {
                digits[i] = 0;
                continue;
            }
            
            digits[i]++;
            findEnd = true;
            break;
        }
        
        if (findEnd)
            return digits;

        var ret = new int[digits.Length + 1];
        ret[0] = 1;
        for (var i = 0; i < digits.Length; i++)
            ret[i+1] = digits[i];
        
        return ret;
    }
}