using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Bruteforce.
/// <see cref="DigitSum"/>
/// O(n), O(n) space.
/// RT = 0 ms, beats 100%.
/// M = 39.01 MB, beats 82.76%.
/// </summary>
// Complexity Proof.
// O(n) Time and O(n) Space.
// A round costs about as much as the current length.
// At worst, the length stays the same for one round and then halves,
// so all the rounds together cost:
// n + n + n/2 + n/2 + n/4 + ... = 2(n + n/2 + n/4 + ...) < 4n
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/calculate-digit-sum-of-a-string/")]
public class N2243_Easy_CalculateDigitSumOfAString
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("11111222223", 3, "135");
        yield return new TestCaseData("00000000", 3, "000");
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, int k, string expected)
    {
        var ret = DigitSum(s, k);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public string DigitSum(string s, int k)
    {
        var n = s.Length;
        if (n <= k)
            return s;
        
        while (n > k)
        {
            var newS = "";
            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += s[i] - '0';
                if ((i + 1) % k == 0 || i == n - 1)
                {
                    newS += sum.ToString();
                    sum = 0;
                }
            }
            
            s = newS;
            n = s.Length;
        }

        return s;
    }
}