using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class CountingValleys
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(8, "UDDDUDUU", 1);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CountValleys(int steps, string path, int expected)
    {
        var result = 0;
        var counter = 0;

        foreach (var item in path)
        {
            switch (item)
            {
                case 'D':
                {
                    --counter;
                    if (counter == -1)
                        result++;

                    break;
                }
                case 'U':
                {
                    ++counter;
                    break;
                }                
            }
        }

        Assert.AreEqual(expected, result, "Number of Valleys calculated incorrectly.");
    }
}