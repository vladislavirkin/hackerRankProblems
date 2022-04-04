using System;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class SuperDigit
{
    [Test]
    [TestCase("123", 3, 9)]
    [TestCase("9875", 4, 8)]
    public void Solve(string n, int k, int expected)
    {
        var ret = n;
        var sum = ret.Aggregate<char, long>(0, (current, t) => current + Convert.ToInt32(t.ToString()));
        ret = (sum * k).ToString();

        while (ret.Length > 1)
        {
            sum = ret.Aggregate<char, long>(0, (current, t) => current + Convert.ToInt32(t.ToString()));
            ret = sum.ToString();
        }

        Assert.AreEqual(expected, int.Parse(ret), "Result calculated incorrectly.");
    }
}