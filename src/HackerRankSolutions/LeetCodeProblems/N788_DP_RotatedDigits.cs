using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="RotatedDigitsBruteForce(int n)"/>
/// RT = 5 ms, beats 73%.
/// M = 29 MB, beats 56%.
/// <see cref="RotatedDigitsBruteForce(int n)"/>
/// RT = 1 ms, beats 100%.
/// M = 29 MB, beats 84%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/rotated-digits/")]
public class N788_DP_RotatedDigits
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(10, 4);
        yield return new TestCaseData(857, 247);
        yield return new TestCaseData(100, 40);
        yield return new TestCaseData(1, 0);
        yield return new TestCaseData(2, 1);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, int expected)
    {
        // var ret = RotatedDigitsBruteForce(n);
        var ret = RotatedDigitsDp(n);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }

    public int RotatedDigitsDp(int n)
    {
        string s = n.ToString();
        int[,,] dp = new int[s.Length, 2, 2];
        Fill(ref dp);
        
        return Calculate(s, 0, 0, 1, ref dp);
    }

    private void Fill(ref int[,,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int k = 0; k < arr.GetLength(2); k++)
                {
                        arr[i, j, k] = -1;
                }
            }
        }
    }

    /// <summary>
    /// DP.
    /// </summary>
    /// <param name="s">N to string.</param>
    /// <param name="i">Current index.</param>
    /// <param name="foundGood">If found good - 1 (0, 1).</param>
    /// <param name="tight">If tight - 1 (0, 1).</param>
    /// <param name="dp">Array of memoization.</param>
    /// <returns></returns>
    private int Calculate(string s, int i, int foundGood, int tight, ref int[,,] dp)
    {
        if (i == s.Length)
            return foundGood;

        if (dp[i, foundGood, tight] != -1)
            return dp[i, foundGood, tight];

        int count = 0;
        var digit = s[i] - '0';
        int upperBound = tight == 1 ? digit : 9;

        for (int j = 0; j <= upperBound; j++)
        {
            if (IsDigitBad(j))
                continue;
            
            int newTight = tight == 1 && j == digit ? 1 : 0;
            
            if (IsDigitGood(j))
                count += Calculate(s, i+1, 1, newTight, ref dp);
            else
                count += Calculate(s, i+1, foundGood, newTight, ref dp);
        }
        
        return dp[i, foundGood, tight] = count;
    }
    
    public int RotatedDigitsBruteForce(int n)
    {
        var ret = 0;
        
        for (int i = 1; i <= n; i++)
        {
            if (IsNumberGood(i))
                ret++;
        }
        
        return ret;
    }

    private bool IsNumberGood(int number)
    {
        var foundGood = false;
        while (number > 0)
        {
            int k = number % 10;
            if (IsDigitBad(k))
                return false;
            
            if (IsDigitGood(k))
                foundGood = true;

            number /= 10;
        }

        return foundGood;
        
    }

    private bool IsDigitGood(int n)
    {
        if (n == 2 || n == 5 || n == 6 || n == 9)
            return true;
        
        return false;
    }

    private bool IsDigitBad(int n)
    {
        if (n == 3 || n == 4 || n == 7)
            return true;
        
        return false;
    }
    
    private bool IsDigitSame(int n)
    {
        if (n == 0 || n == 1 || n == 8)
            return true;
        
        return false;
    }
}