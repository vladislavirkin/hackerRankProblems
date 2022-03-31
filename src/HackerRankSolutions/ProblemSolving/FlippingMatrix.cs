using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class FlippingMatrix
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<List<int>> { new() { 112, 42, 83, 119 }, new() { 56, 125, 56, 49 }, new() { 15, 78, 101, 43 }, new() { 62, 98, 114, 108 } }, 414);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<List<int>> matrix, int expectedSum)
    {
        var ret = 0;

        var n = matrix.Count / 2;
        var tmp = new List<int>();
        
        for (var row = 0; row < n; row++)
        {
            for (var column = 0; column < n; column++)
            {
                tmp.Add(matrix[row][2 * n - column - 1]);
                tmp.Add(matrix[row][column]);
                tmp.Add(matrix[2 * n - row - 1][column]);
                tmp.Add(matrix[2 * n - row - 1][2 * n - column - 1]);
             
                ret += tmp.Max();
                tmp.Clear();
            }
        }

        Assert.AreEqual(expectedSum, ret, "Sum of the values in the upper-left quadrant calculated incorrectly.");
    }
}