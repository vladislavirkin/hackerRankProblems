using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy" + "https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/")]
public class N28_FindTheIndexOfTheFirstOccurrenceInAString
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("sadbutsad", "sad", 0);
        yield return new TestCaseData("leetcode", "leeto", -1);
        yield return new TestCaseData("a", "a", 0);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string haystack, string needle, int expected)
    {
        var ret = StrStr(haystack, needle);
        // var ret = StrStrBestSolution(haystack, needle);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public int StrStr(string haystack, string needle)
    {
        if (needle.Length > haystack.Length)
            return -1;

        for (var i = 0; i <= haystack.Length - 1; i++)
        {
            if (haystack[i] != needle[0])
                continue;
            
            if (haystack.Length - i < needle.Length)
                break;
                
            for (var j = 0; j <= needle.Length - 1; j++)
            {
                if (haystack[i + j] != needle[j])
                    break;

                if (j == needle.Length - 1)
                    return i;
            }
        }

        return -1;
    }
    
    public int StrStrBestSolution(string haystack, string needle)
    {
        for(var i = 0; i < haystack.Length - needle.Length + 1 ; i++)
        {
            if(haystack.AsSpan(i, needle.Length).SequenceEqual(needle))
                return i;
        }

        return -1;
    }
}