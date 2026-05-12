using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="MinScoreTriangulation"/>
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/minimum-score-triangulation-of-polygon/")]
public class N1039_WIP_Medium_MinimumScoreTriangulationOfPolygon
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {3,7,4,5}, 144);
        yield return new TestCaseData(new [] {1,2,3}, 6);
        yield return new TestCaseData(new [] {1,3,1,4,1,5}, 13);
    }
    
    [Test]
    [Ignore("WIP")]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] nums, int expected)
    {
        var ret = MinScoreTriangulation(nums);

        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public int MinScoreTriangulation(int[] values)
    {
        if (values.Length == 3)
        {
            var ret = 1;
            for (int i = 0; i < values.Length; i++)
                ret *= values[i];

            return ret;
        }
        
        
        
        return -1;
    }
}