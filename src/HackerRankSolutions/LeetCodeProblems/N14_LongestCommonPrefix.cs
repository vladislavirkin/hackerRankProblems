using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy" + "https://leetcode.com/problems/longest-common-prefix/")]
public class N14_LongestCommonPrefix
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {"flower", "flow", "flight"}, "fl");
        yield return new TestCaseData(new [] {"dog","racecar","car"}, "");
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string[] strs, string expected)
    {
        string ret;
        
        if (strs == null || strs.Length == 0)
            ret = "";
        else
        {
            ret = strs[0];

            for (var i = 1; i < strs.Length; i++)
            {
                while (!strs[i].StartsWith(ret))
                {
                    ret = ret[..^1];

                    if (ret == "")
                        ret = "";
                }
            }
        }
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
}