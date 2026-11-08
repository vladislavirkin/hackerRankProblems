using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems.Contest._2026._11._08;

/// <summary>
/// <see cref="FindMismatchedSegments"/>
/// RT = 1 ms, beats 46%.
/// M = 59 MB, beats 86%.
/// </summary>
[TestFixture]
public class Q1_Medium_FindMismatchedSegmentsBetweenTwoStrings
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("earth", "empty",
            new List<IList<string>> { new List<string> { "ar", "mp" }, new List<string> { "h", "y" } });
        yield return new TestCaseData("action", "nation",
            new List<IList<string>> { new List<string> { "ac", "na" } });
        yield return new TestCaseData("hot", "hot",
            new List<IList<string>> { });
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s1, string s2, List<IList<string>> expected)
    {
        var ret = FindMismatchedSegments(s1, s2);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public IList<IList<string>> FindMismatchedSegments(string s1, string s2)
    {
        var ret = new List<IList<string>>();

        var n = s1.Length;

        var cur = 0;
        
        for (var i = 0; i < n; i++)
        {
            if (s1[i] == s2[i])
            {
                if (cur == i)
                {
                    cur = i + 1;
                    continue;
                }
                
                ret.Add(new List<string> { s1.Substring(cur, i - cur), s2.Substring(cur, i - cur) });
                cur = i + 1;
            }
        }
        
        if (cur < n)
            ret.Add(new List<string> { s1.Substring(cur), s2.Substring(cur) });
        
        return ret;
    }
}