using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Sliding window.
/// ret = Max([__a__] + [0] + [__b__], ret).
/// <see cref="FindMaxConsecutiveOnes_ByNadya"/>
/// RT = 1 ms, beats 100%.
/// M = 47 MB, beats 59%.
/// <see cref="FindMaxConsecutiveOnes_Elegant"/>
/// RT = 1 ms, beats 100%.
/// M = 47 MB, beats 76%.
/// <see cref="FindMaxConsecutiveOnes_Max"/>
/// Not working.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/max-consecutive-ones-ii/")]
public class N487_Medium_MaxConsecutiveOnes_2
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { 1, 0, 1, 1, 0 }, 4);
        yield return new TestCaseData(new [] { 1, 0, 1, 1, 0, 1 }, 4);
        yield return new TestCaseData(new [] { 1, 1, 0, 1 }, 4);
        yield return new TestCaseData(new [] { 0, 0 }, 1);
        yield return new TestCaseData(new [] { 1 }, 1);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        // var ret = FindMaxConsecutiveOnes_Max(nums);
        // var ret = FindMaxConsecutiveOnes_Elegant(nums);
        var ret = FindMaxConsecutiveOnes_ByNadya(nums);

        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int FindMaxConsecutiveOnes_Max(int[] nums)
    {
        var ret = 0;
        var n = nums.Length;
        var max = 0;
        var candidate = -1;
        
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                if (candidate >= 0)
                {
                    ret = Math.Max(ret, max);
                    max = i - candidate;
                    continue;
                }

                candidate = i;
            }

            max++;
        }
        
        return Math.Max(max, ret);
    }
    
    public int FindMaxConsecutiveOnes_Elegant(int[] nums)
    {
        int max = 0;
        int curr = 0, prev = 0, seenZero = 0;
    
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) {
                seenZero = 1;
                prev = curr;
                curr = 0;
            } else {
                curr++;
            }
        
            max = Math.Max(max, curr + prev + seenZero);
        }
    
        return max;
    }
    
    public int FindMaxConsecutiveOnes_ByNadya(int[] nums)
    {
        var ret = 0;
        var n = nums.Length;
        int a = 0, b = 0;
        bool foundZero = false;
        
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == 0)
            {
                if (foundZero)
                {
                    ret = Math.Max(ret, a + b + 1);
                    a = b;
                    b = 0;
                    continue;
                }

                foundZero = true;
            }
            else
            {
                if (foundZero)
                    b++;
                else
                    a++;
            }
        }
        
        return Math.Max(ret, foundZero ? a + b + 1 : a);
    }
}