using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="MySqrtNewton"/>
/// RT = 0 ms, beats 100%.
/// M = 28 MB, beats 93%.
/// <see cref="MySqrtBinary"/>
/// RT = 0 ms, beats 100%.
/// M = 29 MB, beats 24%.
/// <see cref="MySqrt"/>
/// RT = 0 ms, time exceeded on large numbers.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/sqrtx/")]
public class N69_RETRY_Easy_Sqrt
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(4, 2);
        yield return new TestCaseData(8, 2);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, int expected)
    {
        // var ret = MySqrt(n);
        // var ret = MySqrtNewton(n);
        var ret = MySqrtBinary(n);
        
        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }

    public int MySqrtNewton(int x)
    {
        double ans = findSqrt(x);
        return (int)Math.Round(ans, 5);
    }
    
    public static double findSqrt(double x)
    {
        if (x < 2)
            return x;
        
        double y = x;
        double z = (y + (x / y)) / 2;
        
        while (Math.Abs(y - z) >= 0.00001)
        {
            y = z;
            z = (y + (x / y)) / 2;
        }
        
        return z;
    }
    
    public int MySqrt(int x)
    {
        if (x == 0)
            return 0;
        if (x < 4)
            return 1;
        if (x == 4)
            return 2;
        
        int tmp = 4;
        int i = 2;
        do
        {
            tmp += 2 * i + 1;
            i++;
        } while (tmp < x);

        if (tmp == x)
            return i;

        return i - 1;
    }
    
    public int MySqrtBinary(int x)
    {
        if (x == 0 || x == 1)
            return x;
        
        int start = 1;
        int end = x;
        int mid = -1;
        
        while (start <= end)
        {
            mid = start + (end - start) / 2;
            
            if ((long) mid * mid > (long) x)
                end = mid - 1;
            else if (mid * mid == x)
                return mid;
            else
                start = mid + 1;
        }
        
        return end;
    }
}