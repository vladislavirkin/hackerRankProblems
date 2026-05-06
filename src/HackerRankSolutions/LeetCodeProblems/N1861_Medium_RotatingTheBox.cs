using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="RotateTheBox"/>
/// RT = 10 ms, beats 35%.
/// M = 93 MB, beats 16%.
/// <see cref="RotateTheBoxBest"/>
/// RT = 7 ms, beats 96%.
/// M = 93 MB, beats 41%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/rotating-the-box/")]
public class N1861_Medium_RotatingTheBox
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {new [] {'#','.','#'}}, new [] { new [] {'.'}, new [] {'#'}, new [] {'#'}});
        yield return new TestCaseData(
            new [] {new [] {'#','.','*','.'}, new [] {'#','#','*','.'}},
            new [] {new [] {'#','.'}, new [] {'#','#'}, new [] {'*','*'}, new [] {'.','.'}});
        yield return new TestCaseData(
            new [] {new [] {'#','#','*','.','*','.'}, new [] {'#','#','#','*','.','.'}, new [] {'#','#','#','.','#','.'}},
            new [] {new [] {'.','#','#'}, new [] {'.','#','#'}, new [] {'#','#','*'}, new [] {'#','*','.'}, new [] {'#','.','*'}, new [] {'#','.','.'}});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(char[][] grid, char[][] expected)
    {
        // var ret = RotateTheBox(grid);
        var ret = RotateTheBoxBest(grid);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public char[][] RotateTheBoxBest(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        char[][] ret = new char[n][];
        
        for (int i = 0; i < n; i++)
        {
            ret[i] = new char[m];
            for (int j = 0; j < m; j++)
                ret[i][j] = '.';
        }
        
        for (int i = 0; i < m; i++)
        {
            int lowestRowWithEmptyCell = n - 1;
            
            for (int j = n - 1; j >= 0; j--)
            {
                if (grid[i][j] == '#')
                {
                    ret[lowestRowWithEmptyCell][m - i - 1] = '#';
                    lowestRowWithEmptyCell--;
                }
                
                if (grid[i][j] == '*')
                {
                    ret[j][m - i - 1] = '*';
                    lowestRowWithEmptyCell = j - 1;
                }
            }
        }
        return ret;
    }
    
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        var n = boxGrid.Length;
        var m = boxGrid[0].Length;
        
        for (int j = 0; j < n; j++)
        {
            var obstacle = m;
            for (int i = m - 1; i >= 0; i--)
            {
                if (boxGrid[j][i] == '*')
                    obstacle = i;
                if (boxGrid[j][i] == '.')
                    continue;
                if (boxGrid[j][i] == '#' && obstacle != i)
                {
                    (boxGrid[j][i], boxGrid[j][obstacle - 1]) = (boxGrid[j][obstacle - 1], boxGrid[j][i]);
                    obstacle -= 1;
                }
            }
        }
        
        var ret = new char[m][];
        for (int i = 0; i < m; i++)
        {
            ret[i] = new char[n];
            for (int j = 0; j < n; j++)
                ret[i][j] =  boxGrid[n - 1 - j][i];
        }
        
        return ret;
    }
}