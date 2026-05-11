using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="Generate"/>
/// RT = 0 ms, beats 100%.
/// M = 40 MB, beats 75%.
/// </summary>
[TestFixture(Description = "Easy"+"https://leetcode.com/problems/pascals-triangle/")]
public class N118_Easy_PascalsTriangle
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(5, new [] { new [] {1}, new [] {1,1}, new [] {1,2,1}, new [] {1,3,3,1}, new [] {1,4,6,4,1}});
        yield return new TestCaseData(1, new [] { new [] {1}});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int numRows, int[][] expected)
    {
        var ret = Generate(numRows);
        
        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public IList<IList<int>> Generate(int numRows)
    {
        var ret = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            var row = new List<int>();

            if (i == 0)
            {
                row.Add(1);
            }
            else
            {
                row.Add(1);

                var previous = ret[i - 1];
                for (int j = 0; j < previous.Count - 1; j++)
                    row.Add(previous[j] + previous[j + 1]);
                
                row.Add(1);
            }

            ret.Add(row);
        }

        return ret;
    }
}