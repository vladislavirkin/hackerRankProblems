using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Medium"+"https://leetcode.com/problems/generate-parentheses/")]
public class N22_Generate_Parentheses_WIP
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(3, new [] {"((()))","(()())","(())()","()(())","()()()"});
        yield return new TestCaseData(1, new[] { "()" });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, List<string> expected)
    {
        var ret = GenerateParenthesis(n);
        
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public IList<string> GenerateParenthesis(int n)
    {
        var ret = new List<string>();
        if (n == 1)
        {
            ret.Add("()");
            return ret;
        }
        
        

        return ret;
    }
}