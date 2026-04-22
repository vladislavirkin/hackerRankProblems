using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy"+"https://leetcode.com/problems/valid-parentheses/")]
public class N20_ValidParentheses
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("()", true);
        yield return new TestCaseData("()[]{}", true);
        yield return new TestCaseData("(}", false);
        yield return new TestCaseData("([])", true);
        yield return new TestCaseData("([)]", false);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string str, bool expected)
    {
        var ret = IsValid(str);
        
        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }

    private static bool IsValid(string s) {
        int length = s.Length;
        
        if (length % 2 != 0)
            return false;
        
        var stack = new char[length];
        var top = 0;

        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    stack[top++] = ')';
                    break;

                case '[':
                    stack[top++] = ']';
                    break;

                case '{':
                    stack[top++] = '}';
                    break;

                default:
                {
                    if (top == 0)
                        return false;
                    
                    if (stack[--top] != c)
                        return false;

                    break;
                    
                }
            }
        }
        
        return top == 0;
    }
}