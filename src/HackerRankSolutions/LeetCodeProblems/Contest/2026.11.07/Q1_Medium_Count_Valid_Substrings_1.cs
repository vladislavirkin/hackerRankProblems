using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems.Contest._2026._11._07;

/// <summary>
/// # Main idea.
/// <see cref="CountValidSubstrings"/>
/// RT = 8 ms, beats 46%.
/// M = 51 MB, beats 86%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/contest/biweekly-contest-195/problems/count-valid-substrings-i/")]
public class Q1_Medium_Count_Valid_Substrings_1
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("abac", 10);
        yield return new TestCaseData("abc", 5);
        yield return new TestCaseData("ac", 3);
        yield return new TestCaseData("aabc", 8);
        yield return new TestCaseData("abcaa", 12);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, long expected)
    {
        var ret = CountValidSubstrings(s);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public long CountValidSubstrings(string s)
    {
        long ret = 0;
        int invalid = -1;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (i >= 2 && s[i - 2] == 'a' && s[i - 1] == 'b' && s[i] == 'c')
                invalid = i - 2;
            
            ret += i - invalid;
        }
        
        return ret;
    }
    
    public long CountValidSubstrings_First(string s)
    {
        long ret = 0;

        if (s.Length == 1)
            return 1;
        
        if (s.Length == 2)
            return 3;

        const string notValid = "abc";
        var cur = string.Empty;
        var k = s.Length - 1;
        var found = false;
        for (var i = 0; i < s.Length; i++)
        {
            cur += s[i];
            if (cur.Length == 3)
            {
                if (cur == notValid)
                {
                    k = i - 1;
                    found = true;
                    break;
                }
                
                cur = cur.Substring(1);
            }

            ret += 1;
        }

        if (!found)
        {
            for (int i = 1; i <= k; i++)
                ret += k - i + 1;

            return ret;
        }
        
        for (int i = 1; i < k; i++)
            ret += k - i + 1;
        
        if (k < s.Length - 1)
            ret += CountValidSubstrings(s.Substring(k));

        return ret;
    }
}