using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// If string is beautiful, iff all substrings of length 2 are beautiful!
/// Therefore, you just need to iterate through all consecutive pairs,
/// and if they are not equal, increment the change count by 1.
/// <see cref="MinChanges"/>
/// RT = 2 ms, beats 100%.
/// M = 45.72 MB, beats 100%.
/// </summary>
[TestFixture(Description = "Hard" + "https://leetcode.com/problems/minimum-changes-to-make-k-semi-palindromes/")]
public class N2914_Medium_MinimumNumberOfChangesToMakeBinaryStringBeautiful
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("1001", 2);
        yield return new TestCaseData("10", 1);
        yield return new TestCaseData("0000", 0);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, int expected)
    {
        var ret = MinChanges(s);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int MinChanges(string s)
    {
        var ret = 0;

        for (var i = 0; i < s.Length; i += 2)
        {
            if (s[i] != s[i + 1])
                ret++;
        }
        
        return ret;
    }
}