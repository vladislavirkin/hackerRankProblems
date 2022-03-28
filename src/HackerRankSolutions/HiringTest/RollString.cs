using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.HiringTest;

[TestFixture]
public class RollString
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("abz", new List<int> { 3, 2, 1 }, "dda");
        yield return new TestCaseData("bca", new List<int> { 3, 2, 1, 5, 4 }, "ggd");
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string s, List<int> roll, string expected)
    {
        var ret = new char[s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            var rollCount = roll.Count(x => x > i);
            var offset = s[i] + rollCount % 26;
            if (offset > 'z')
                offset = 'a' + offset - 'z' - 1;
            ret[i] = (char)offset;
        }

        Assert.AreEqual(expected, new string(ret), "Incorrectly calculated result.");
    }
}