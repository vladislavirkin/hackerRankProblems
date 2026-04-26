using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy" + "https://leetcode.com/problems/length-of-last-word/")]
public class N58_LengthOfLastWord
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("Hello World", 5);
        yield return new TestCaseData("   fly me   to   the moon  ", 4);
        yield return new TestCaseData("luffy is still joyboy", 6);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string str, int expected)
    {
        var ret = LengthOfLastWord(str);
        // var ret = LengthOfLastWordBest(str);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public int LengthOfLastWord(string s)
    {
        var ret = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                if (ret > 0)
                    break;
            }
            else
                ret++;
        }

        return ret;
    }
    
    public int LengthOfLastWordBest(string s)
    {
        var words = s.Trim().Split(" ");
        return words[^1].Length;
        
    }
}