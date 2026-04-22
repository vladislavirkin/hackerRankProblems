using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class PalindromeIndex
{
    [Test]
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(1235321, true)]
    public void Solve(int x, bool expected)
    {
        bool ret;
        
        if (x < 0)
            ret = false;
        else
        {
            var s = x.ToString();
            ret = !s.Where((symbol, index) => symbol != s[s.Length - (index + 1)]).Any();
        }

        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
}