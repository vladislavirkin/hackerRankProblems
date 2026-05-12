using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="IsPalindrome"/>
/// RT = 21 ms, beats 41%.
/// M = 46 MB, beats 23%.
/// <see cref="IsPalindromeRT"/>
/// RT = 0 ms, beats 100%.
/// M = 44 MB, beats 65%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/valid-palindrome/")]
public class N125_Easy_ValidPalindrome
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("A man, a plan, a canal: Panama", true);
        yield return new TestCaseData("race a car", false);
        yield return new TestCaseData(" ", true);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string str, bool expected)
    {
        var ret = IsPalindrome(str);
        // var ret = IsPalindromeRT(str);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return true;
        
        var cleanStr = new string(s.ToLower().Where(char.IsLetterOrDigit).ToArray());
        var reversedStr = new string(cleanStr.Reverse().ToArray());
        return cleanStr == reversedStr;
    }
    
    public bool IsPalindromeRT(string s)
    {
        short first = 0;
        short last = (short)(s.Length - 1);
        bool valid = true;

        while(first < last)
        {
            if (!IsValidChar(s[first]))
            {
                first++;
                continue;
            }

            if (!IsValidChar(s[last]))
            {
                last--;
                continue;
            }
            
            if(ToLowerCase(s[first]) == ToLowerCase(s[last]))
            {
                first++;
                last--;
            }
            else
            {
                valid = false;
                break;
            }
        }
        
        return valid;
    }
    
    public bool IsValidChar(char c)
    {
        return (c >= 'a' && c <= 'z') ||
               (c >= 'A' && c <= 'Z') ||
               (c >= '0' && c <= '9');
    }

    public char ToLowerCase(char c) => c>='A' && c<='Z' ? (char)(c+32) : c;
}