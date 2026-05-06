using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// RT = 123 ms, beats 57%.
/// M = 73 MB, beats 42%.
/// Main idea:
///     1. It's possible in one case - all elements should have same reminder when divided by x. (mod x)
///     2. Save all dividers (grid[i][j] / x) to list.
///     3. Minimum number of operations will be when choosing the mid element number k/2.
///     4. result = List.Sum(x => x - list[k/2]);
///
/// Best solution:
///     1. all vars -> int, int[] etc.
///     2. No sorting -> tricky algo.
///     3. In 1D array saves frequencies for each element in grid.
///     4. No linq.
/// </summary>
[TestFixture(Description = "Medium"+"https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/")]
public class N2033_MinimumOperationsToMakeAUniValueGrid
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { new [] {2,4}, new [] {6,8}}, 2, 4);
        yield return new TestCaseData(new [] { new [] {1,5}, new [] {2,3}}, 1, 5);
        yield return new TestCaseData(new [] { new [] {1,2}, new [] {3,4}}, 2, -1);
        yield return new TestCaseData(new [] { new [] {146}}, 86, 0);
        yield return new TestCaseData(new [] { new [] {1,1,10000}}, 1, 9999);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[][] grid, int x, int expected)
    {
        var ret = MinOperations(grid, x);
        // var ret = MinOperationsBest(grid, x);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public int MinOperations(int[][] grid, int x)
    {
        var ret = 0;
        var m = grid.Length;
        var n = grid[0].Length;

        if (m == 1 && n == 1)
            return 0;

        var reminder = grid[0][0] % x;
        var dividers = new int[m * n];
        var k = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                var tmp = grid[j][i] % x;
                if (tmp != reminder)
                    return -1;
                
                dividers[k] = grid[j][i] / x;
                k++;
            }
        }
        
        Array.Sort(dividers);
        
        var mid = dividers[k/2];

        foreach (var divider in dividers)
            ret += Math.Abs(divider - mid);
        
        return ret;
    }

    public int MinOperationsBest(int[][] grid, int x)
    {
        var rem = grid[0][0] % x;
        var max = 0;
        var min = 10000;
        Span<int> med = stackalloc int[10000];
        foreach (int[] arr in grid)
            foreach (int n in arr) {
            if (n % x != rem)
                return -1;

            max = Math.Max(max, n);
            min = Math.Min(min, n);
            ++med[n - 1];
        }

        var mid = 0;
        var ans = 0;
        var pm = (grid.Length * grid[0].Length) / 2 + 1;
        for (var i = min - 1; i != max; ++i) {
            while (pm != 0 && med[i] != 0) {
                --pm;
                --med[i];
            }

            if (pm == 0) {
                mid = i + 1;
                break;
            }
        }

        foreach (int[] arr in grid)
        foreach (int n in arr)
            ans += (int)Math.Abs(n - mid) / x;

        return grid.Length == 1 && grid[0].Length == 1 ? 0 : ans;
    }
}