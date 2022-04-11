using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class GridChallenge
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<string> { "abc", "ade", "cfg" }, "YES");
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<string> grid, string expected)
    {
        var ret = "YES";

        for(var i = 0; i < grid.Count; ++i)
        {
            var s = grid[i].ToCharArray();
            Array.Sort(s);
            grid[i] = new string(s);
        }

        for(var i = 0; i < grid.Count - 1; i++)
        {
            for(var j = 0; j < grid[i].Length; j++)
            {
                if(grid[i][j] > grid[i+1][j])
                    ret = "NO";
            }           
        }

        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
}