using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy"+"https://leetcode.com/problems/palindrome-number/")]
public class N9_PalindromeNumber
{
    [Test]
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(1235321, true)]
    public void Solve(int x, bool expected)
    {
        bool ret;

        if( x < 0 || (x != 0 && x%10 == 0))
        {
            ret = false;
        }

        var y = x;
        var res = 0;

        while(y > 0)
        {
            res = res*10 + y%10;
            y /= 10;
        }

        ret = res == x;

        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
}