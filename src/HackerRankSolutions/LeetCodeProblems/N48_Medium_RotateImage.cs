using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="Rotate"/>
/// RT = 0 ms, beats 100%.
/// M = 46 MB, beats 61%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/rotate-image/")]
public class N48_Medium_RotateImage
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(
            new [] { new [] {1,2,3}, new [] {4,5,6}, new [] {7,8,9}},
            new [] { new [] {7,4,1}, new [] {8,5,2}, new [] {9,6,3}});
        yield return new TestCaseData(
            new [] { new [] {5,1,9,11}, new [] {2,4,8,10}, new [] {13,3,6,7}, new [] {15,14,12,16}},
            new [] { new [] {15,13,2,5}, new [] {14,3,4,1}, new [] {12,6,8,9}, new [] {16,7,10,11}});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[][] grid, int[][] expected)
    {
        Rotate(grid);
        
        Assert.That(grid, Is.EqualTo(expected), $"Result calculated incorrectly. {ToString(grid)}\n{ToString(expected)}");
    }
    
    public void Rotate(int[][] matrix)
    {
        var n = matrix.Length;
        var last = n / 2;

        for (int j = 0; j < n; j++)
            for (int i = j; i < n; i++)
                (matrix[j][i], matrix[i][j]) = (matrix[i][j], matrix[j][i]);
        
        for (int j = 0; j < n; j++)
            for (int i = 0; i < last; i++)
                (matrix[j][i], matrix[j][n - 1 - i]) = (matrix[j][n - 1 - i], matrix[j][i]);
    }
    
    private string ToString(int[][] matrix)
    {
        var sb = new StringBuilder();
        foreach (var i in matrix)
        {
            var s = string.Empty;
            foreach (var j in i)
                s += j + " ";

            sb.Append('\n');
            sb.Append(s);
        }
        return sb.ToString();
    }
}