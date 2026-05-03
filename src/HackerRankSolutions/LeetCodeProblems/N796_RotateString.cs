using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="RotateString"/>
/// RT = 0 ms, beats 100%.
/// M = 40,8 MB, beats 41%.
/// <see cref="RotateStringM"/>
/// RT = 0 ms, beats 100%.
/// M = 39 MB, beats 100%.
/// <see cref="RotateStringRT"/>
/// RT = 0 ms, beats 100%.
/// M = 40,2 MB, beats 91%.
/// <see cref="RotateStringKmp"/>
/// RT = 0 ms, beats 100%.
/// M = 41,17 MB, beats 23%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/rotate-string/")]
public class N796_RotateString
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("abcde", "bcdea", true);
        yield return new TestCaseData("abcde", "cdeab", true);
        yield return new TestCaseData("abcde", "abced", false);
        yield return new TestCaseData("defdefdefabcabc", "defdefabcabcdef", true);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, string goal, bool expected)
    {
        var ret = RotateString(s, goal);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length)
            return false;

        var startes = FindIndex(s, goal[0]);
        if (startes.Length == 0)
            return false;

        foreach (var start in startes)
        {
            if (TryRotate(s, goal, start))
                return true;
        }

        return false;
    }

    private bool TryRotate(string s, string goal, int start)
    {
        var n = s.Length;
        int i;
        for (i = start; i < n; i++)
        {
            if (s[i] != goal[i - start])
                return false;
        }
        
        for (int j = 0; j < start; j++)
        {
            if (s[j] != goal[i - start + j])
                return false;
        }

        return true;
    }

    private int[] FindIndex(string s, char goal)
    {
        var ret = new List<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (goal == s[i])
                ret.Add(i);
        }

        return ret.ToArray();
    }
    
    public bool RotateStringM(string s, string goal)
    {
        if (s.Length != goal.Length)
            return false;

        var concatenated = s + s;
        return concatenated.Contains(goal);
    }

    public bool RotateStringRT(string s, string goal)
    {
        if(s == goal)
            return true;
        
        for ( int i = 1 ; i < s.Length ; i++)
        {
            string firstPart = s.Substring(0,i);
            string lastPart = s.Substring(i);
            if (lastPart + firstPart == goal)
                return true;
        }
        return false;
    }
    
    public bool RotateStringKmp(string s, string goal)
    {
        // Check if the lengths of both strings are different; if so, they can't be rotations
        if (s.Length != goal.Length) return false;

        // Concatenate 's' with itself to create a new string containing all possible rotations
        string doubledString = s + s;

        // Perform KMP substring search to check if 'goal' is a substring of 'doubledString'
        return KmpSearch(doubledString, goal);
    }

    private bool KmpSearch(string text, string pattern)
    {
        // Precompute the LPS (Longest Prefix Suffix) array for the pattern
        int[] lps = ComputeLPS(pattern);
        int textIndex = 0, patternIndex = 0;
        int textLength = text.Length, patternLength = pattern.Length;

        // Loop through the text to find the pattern
        while (textIndex < textLength)
        {
            // If characters match, move both indices forward
            if (text[textIndex] == pattern[patternIndex])
            {
                textIndex++;
                patternIndex++;
                // If we've matched the entire pattern, return true
                if (patternIndex == patternLength) return true;
            }
            // If there's a mismatch after some matches, use the LPS array to skip unnecessary comparisons
            else if (patternIndex > 0)
            {
                patternIndex = lps[patternIndex - 1];
            }
            // If no matches, move to the next character in text
            else
            {
                textIndex++;
            }
        }
        // Pattern not found in text
        return false;
    }

    private int[] ComputeLPS(string pattern)
    {
        int patternLength = pattern.Length;
        int[] lps = new int[patternLength];
        int length = 0, index = 1;

        // Build the LPS array
        while (index < patternLength)
        {
            // If characters match, increment length and set lps value
            if (pattern[index] == pattern[length])
            {
                length++;
                lps[index++] = length;
            }
            // If there's a mismatch, update length using the previous LPS value
            else if (length > 0)
            {
                length = lps[length - 1];
            }
            // No match and length is zero
            else
            {
                lps[index++] = 0;
            }
        }
        return lps;
    }
}