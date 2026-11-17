using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Just if-else cases.
/// <see cref="MinimumChanges"/>
/// RT = 0 ms, beats 100%.
/// M = 43 MB, beats 71%.
/// </summary>
[TestFixture(Description = "Hard" + "https://leetcode.com/problems/minimum-changes-to-make-k-semi-palindromes/")]
public class N2911_WIP_Hard_MinimumChangesToMakeKSemiPalindromes
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("abcac", 2, 1);
        yield return new TestCaseData("abcdef", 2, 2);
        yield return new TestCaseData("aabbaa", 3, 0);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, int k, int expected)
    {
        var ret = MinimumChanges(s, k);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int MinimumChanges(string s, int k)
    {
        var ret = 0;
        
        var n = s.Length;
        int[][] dp = new int[][] { };

        var v = new int[n][];

        for (int i = 0; i < n; i++)
        {
            v[i] = new int[n-i];
            for (int j = 2; j < n - i; j++)
            {
                v[i][j] = CalculateMinChanges(s[i..j]);
            }
        }

        return ret;
    }

    private int CalculateMinChanges(string s)
    {
        return 0;
    }
}