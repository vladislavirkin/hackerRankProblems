using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class DiagonalDifference
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<List<int>> { new() { 11, 2, 4 }, new() { 4, 5, 6 }, new() { 10, 8, -12 } }, 15);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<List<int>> arr, int expected)
    {
        var length = arr.Count;
        var left = 0;
        var right = 0;
    
        for (var i = 0; i < length; i++) 
        {
            for (var j = 0; j < length; j++) 
            {
                if (i == j) {
                    left += arr[i][j];
                }                    
            
                if (i + j == length - 1) {
                    right += arr[i][j]; 
                }
            }    
        }

        var ret = Math.Abs(left - right);

        Assert.AreEqual(expected, ret, "Diagonal difference calculated incorrectly.");
    }
}