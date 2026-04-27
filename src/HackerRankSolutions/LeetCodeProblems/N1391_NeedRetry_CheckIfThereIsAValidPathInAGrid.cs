using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// Retry with DFS, DHS, DSU etc.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid/")]
public class N1391_NeedRetry_CheckIfThereIsAValidPathInAGrid
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { new [] {2,4,3}, new [] {6,5,2}}, true);
        yield return new TestCaseData(new [] { new [] {1,2,1}, new [] {1,2,1}}, false);
        yield return new TestCaseData(new [] { new [] {1,1,2}}, false);
        yield return new TestCaseData(new [] { new [] {1}}, true);
        yield return new TestCaseData(new [] { new [] {2, 6}}, false);
        yield return new TestCaseData(new [] { new [] {4,1}, new [] {6,1}}, true);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[][] grid, bool expected)
    {
        var ret = HasValidPath(grid);
        // var ret = HasValidPathBest(grid);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    /// <summary>
    /// Beats 100% by Memory. 57% runtime
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public bool HasValidPath(int[][] grid)
    {
        bool ret;

        if (grid.Length == 1 && grid[0].Length == 1)
            return true;

        var crossings = new Dictionary<int, Crossing>
        {
            {0, new Crossing(1, 1)},
            {1, new Crossing(4, 2)},
            {2, new Crossing(1, 3)},
            {3, new Crossing(4, 3)},
            {4, new Crossing(3, 2)},
            {5, new Crossing(4, 1)},
            {6, new Crossing(1, 2)},
        };

        // Ox.
        var i  = 0;
        // Oy.
        var j = 0;
        
        var prev = crossings[grid[j][i]];
        ret = Calculate(grid, prev, i, j, crossings);
        if (!ret)
            ret = Calculate(grid, prev.Invert(), i, j, crossings);
        
        return ret;
    }

    public bool Calculate(int[][] grid, Crossing prev, int i, int j, Dictionary<int, Crossing> crossings)
    {
        var ret = false;
        
        grid[j][i] = 0;
        (i, j) = prev.CrossGrid(i, j);
        
        while (true)
        {
            if (j > grid.Length - 1 || i > grid[0].Length - 1)
                return false;
            
            if (i < 0 || j < 0)
                break;

            // Уже посещенная ячейка.
            if (grid[j][i] == 0)
                break;
            
            var crossing = crossings[grid[j][i]];

            // Если переходы мэтчатся - ничего не делаем.
            if (Crossing.IsValid(prev, crossing))
            {
            }
            else
            {
                crossing = crossing.Invert();
                
                // Если инвертированные переходы не мэтчатся - выходим.
                if (!Crossing.IsValid(prev, crossing))
                    break;
            }
            
            // Помечаем ячейку как пройденную. Если окажемся в ней снова - зациклились, нужно выйти из цикла.
            grid[j][i] = 0;
            
            // Если пришли в конец - нашли путь, выходим из метода.
            if (j == grid.Length - 1 && i == grid[0].Length - 1)
                return true;
            
            (i, j) = crossing.CrossGrid(i, j);
            if (j > grid.Length - 1 || i > grid[0].Length - 1)
                return false;
            
            prev = crossing;
        }
        
        return ret;
    }

    /// <summary>
    ///     1
    /// 4       2
    ///     3
    /// </summary>
    public struct Crossing(int start, int end)
    {
        public readonly int Start = start;
        public readonly int End = end;
        
        public Crossing Invert() => new (End, Start);

        public static bool IsValid(Crossing prev, Crossing next)
        {
            if (prev.End == 1)
                return next.Start == 3;
            if (prev.End == 2)
                return next.Start == 4;
            if (prev.End == 3)
                return next.Start == 1;
            if (prev.End == 4)
                return next.Start == 2;
            
            return false;
        }

        public (int, int) CrossGrid(int i, int j)
        {
            if (start == 1)
            {
                if (end == 2)
                    return (i + 1, j);
                if (end == 3)
                    return (i, j + 1);
                if (end == 4)
                    return (i - 1, j);
            }
            
            if (start == 2)
            {
                if (end == 1)
                    return (i, j - 1);
                if (end == 3)
                    return (i, j + 1);
                if (end == 4)
                    return (i - 1, j);
            }
            
            if (start == 3)
            {
                if (end == 1)
                    return (i, j - 1);
                if (end == 2)
                    return (i + 1, j);
                if (end == 4)
                    return (i - 1, j);
            }
            
            if (start == 4)
            {
                if (end == 1)
                    return (i, j - 1);
                if (end == 2)
                    return (i + 1, j);
                if (end == 3)
                    return (i, j + 1);
            }
            
            return (-1, -1);
        } 
    }
    
    private readonly int[][][] directions = new int[][][]
    {
        null,
        new int[][] { new int[] {0, -1}, new int[] {0, 1} },
        new int[][] { new int[] {-1, 0}, new int[] {1, 0} },
        new int[][] { new int[] {0, -1}, new int[] {1, 0} },
        new int[][] { new int[] {0, 1},  new int[] {1, 0} },
        new int[][] { new int[] {0, -1}, new int[] {-1, 0} },
        new int[][] { new int[] {0, 1},  new int[] {-1, 0} }
    };

    /// <summary>
    /// 100% by runtime.
    /// </summary>
    public bool HasValidPathBest(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        bool[,] visited = new bool[m, n];

        queue.Enqueue((0, 0));
        visited[0, 0] = true;

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            if (r == m - 1 && c == n - 1) return true;

            int type = grid[r][c];
            foreach (var dir in directions[type])
            {
                int nr = r + dir[0];
                int nc = c + dir[1];
                
                if (nr >= 0 && nr < m && nc >= 0 && nc < n && !visited[nr, nc])
                {
                    if (CanConnect(nr, nc, r, c, grid))
                    {
                        visited[nr, nc] = true;
                        queue.Enqueue((nr, nc));
                    }
                }
            }
        }
        return false;
    }

    private bool CanConnect(int nextR, int nextC, int currR, int currC, int[][] grid)
    {
        int nextType = grid[nextR][nextC];
        foreach (var dir in directions[nextType])
        {
            if (nextR + dir[0] == currR && nextC + dir[1] == currC)
                return true;
        }
        
        return false;
    }
}