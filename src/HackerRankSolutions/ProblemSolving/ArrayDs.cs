using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class ArrayDs
{
    [Test]
    [TestCase(new [] { 1, 2, 3, 4, 5 }, new [] { 5, 4, 3, 2, 1 })]
    public void Reverse(int[] list, int[] expected)
    {
        var ret = new List<int>();

        for (var i = list.Length - 1; i >= 0; i--)
            ret.Add(list[i]);

        Assert.AreEqual(expected, ret.ToArray(), "Reversed array calculated incorrectly.");
    }
}