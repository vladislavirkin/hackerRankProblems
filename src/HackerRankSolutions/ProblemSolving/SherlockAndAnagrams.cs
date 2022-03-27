using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class SherlockAndAnagrams
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<string> { "abba", "abcd", "ifailuhkqq", "kkkk" }, new List<int> { 4, 0, 3, 10 });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CountAnagrams(List<string> items, List<int> expected)
    {
        for (var index = 0; index < items.Count; index++)
        {
            var ret = 0;
        
            var length = items[index].Length;
            var anagrams = new Dictionary<string, int>();
            for (var len = 1; len < length; len++)
            {
                for (var i = 0; i < length - len + 1; i++)
                {
                    var item = new string(items[index].Substring(i, len).OrderBy(c => c).ToArray());
                    if (anagrams.ContainsKey(item))
                    {
                        ret += anagrams[item];
                        anagrams[item] += 1;
                    }
                    else
                        anagrams[item] = 1;
                }
                anagrams.Clear();
            }
        
            Assert.AreEqual(expected[index], ret, $"Anagrams for {index} string calculated incorrectly.");
        }
    }
}