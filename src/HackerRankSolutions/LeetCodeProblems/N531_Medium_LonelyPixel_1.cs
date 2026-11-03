using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="FindLonelyPixel_First"/>
/// RT = 14 ms, beats -%.
/// M = 61 MB, beats 11%.
/// <see cref="FindLonelyPixel_Best"/>
/// RT = 2 ms, beats 88%.
/// M = 57 MB, beats 100%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/lonely-pixel-i/")]
public class N531_Medium_LonelyPixel_1
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new char[][] { ['W','W','B'], ['W','B','W'], ['B','W','W'] }, 3);
        yield return new TestCaseData(new char[][] { ['B','B','B'], ['B','B','W'], ['B','B','B'] }, 0);
        yield return new TestCaseData(new char[][] { ['B','B','B'] }, 0);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(char[][] picture, int expected)
    {
        // var ret = FindLonelyPixel_Best(picture);
        var ret = FindLonelyPixel_First(picture);

        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int FindLonelyPixel_First(char[][] picture)
    {
        var m = picture.Length;
        var n = picture[0].Length;
        var store = new Dictionary<int, bool>();
        
        for (int i = 0; i < m; i++)
        {
            var bIndex = -1;
            var alone = false;
            
            for (int j = 0; j < n; j++)
            {
                
                if (picture[i][j] == 'W')
                    continue;

                if (bIndex >= 0)
                {
                    alone = false;
                    if (!store.TryAdd(j, false))
                        store[j] = false;
                }
                else
                {
                    alone = true;
                    bIndex = j;
                }
            }
            if (!store.TryAdd(bIndex, alone))
                store[bIndex] = false;
        }
        
        return store.Count(x => x.Value);
    }
    
    public int FindLonelyPixel_Best(char[][] picture)
    {
        int m = picture.Length;
        int n = picture[0].Length;

        int[] cols = new int[n];

        for (int i = 0; i < m; i++)
        {
            int pixelCount = 0;
            int firstPixel = -1;
            for (int j = 0; j < n; j++)
            {
                if (picture[i][j] == 'B')
                {
                    pixelCount++;
                    if (pixelCount == 1)
                    {
                        firstPixel = j;
                    }

                    if (pixelCount == 2)
                    {
                        cols[firstPixel] = -1;
                    }

                    if (cols[j] == 0 && pixelCount == 1)
                    {
                        cols[j] = 1;
                    }
                    else
                    {
                        cols[j] = -1;
                    }
                }
            }
        }

        int result = 0;
        for (int j = 0; j < n; j++)
        {
            if (cols[j] == 1)
            {
                result++;
            }
        }

        return result;
    }
}