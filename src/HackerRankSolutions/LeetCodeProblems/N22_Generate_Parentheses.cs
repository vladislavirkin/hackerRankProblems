using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Medium"+"https://leetcode.com/problems/generate-parentheses/")]
public class N22_Generate_Parentheses
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(3, new List<string> {"((()))","(()())","(())()","()(())","()()()"});
        yield return new TestCaseData(1, new List<string> { "()" });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int n, List<string> expected)
    {
        var ret = GenerateParenthesis(n);
        
        Assert.That(ret, Is.EquivalentTo(expected), "Result calculated incorrectly.");
    }
    
    public IList<string> GenerateParenthesis(int n)
    {
        var ret = new List<string>();
        Generate(ret, "", 0, 0, n);
        return ret;
    }

    private static void Generate(List<string> ret, string newStr, int openingParenthesis, int closingParenthesis, int n)
    {
        if (openingParenthesis == n && closingParenthesis == n)
        {
            ret.Add(newStr);
            return;
        }
        
        if (openingParenthesis > closingParenthesis)
            Generate(ret, newStr + ")", openingParenthesis, closingParenthesis + 1, n);
        if (openingParenthesis < n)
            Generate(ret, newStr + "(", openingParenthesis + 1, closingParenthesis, n);
    }
}