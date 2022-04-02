using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class PalindromeIndex
{
    [Test]
    [TestCase("aaab", 3)]
    [TestCase("baa", 0)]
    [TestCase("aaa", -1)]
    public void Solve(string s, int expected)
    {
        var ret = -1;

        if (IsPalindrome(s))
            ret = -1;
        else
        {
            var left = 0;
            var right = s.Length - 1;
            while (left <= right)
            {
                if (s[left] != s[right])
                    break;
                left++;
                right--;
            }

            if (IsPalindrome(s.Remove(left, 1)))
                ret = left;
            else if (IsPalindrome(s.Remove(right, 1)))
                ret = right; 
        }

        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }

    private bool IsPalindrome(string s)
    {
        return !s.Where((symbol, index) => symbol != s[s.Length - (index + 1)]).Any();
    }
}