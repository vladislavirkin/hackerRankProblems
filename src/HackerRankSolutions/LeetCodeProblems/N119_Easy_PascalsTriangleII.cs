using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="GetRow"/>
/// RT = 0 ms, beats 100%.
/// M = 39 MB, beats 90%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/pascals-triangle-ii/")]
public class N119_Easy_PascalsTriangleII
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(3, new [] {1,3,3,1});
        yield return new TestCaseData(0, new [] {1});
        yield return new TestCaseData(1, new [] {1,1});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int numRows, int[] expected)
    {
        var ret = GetRow(numRows);
        
        Assert.That(ret, Is.EqualTo(expected), "Result length calculated incorrectly.");
    }
    
    public IList<int> GetRow(int rowIndex)
    {
        IList<int> ret = new List<int> { 1 };
        for(int i = 1; i <= rowIndex; i++)
        {
            IList<int> helper = new List<int>(i+1);
            helper.Add(1);
            for(int j = 1; j < i; j++)
                helper.Add(ret[j-1] + ret[j]);
            
            helper.Add(1);
            ret = helper;
        }
        
        return ret;
    }
}