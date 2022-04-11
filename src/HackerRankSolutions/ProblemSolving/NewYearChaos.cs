using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class NewYearChaos
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 2, 5, 3, 7, 8, 6, 4 }, "7");
        yield return new TestCaseData(new List<int> { 5, 1, 2, 3, 7, 8, 6, 4 }, "Too chaotic");
        yield return new TestCaseData(new List<int> { 2, 1, 5, 3, 4 }, "3");
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CalculateMiniMaxSum(List<int> arr, string expected)
    {
        var result = string.Empty;

        var bribesCount = 0;
        var last = arr[^1];
        
        for (var i = arr.Count - 2; i >= 0; --i)
        {
            if (arr[i] > i + 3)
            {
                result = "Too chaotic";
                break;
            }

            if(arr[i] == i+3)
                bribesCount += 2;
            else if(arr[i] > last)
                bribesCount++;
            else 
                last = arr[i];
        }
        
        if (result != "Too chaotic")
            result = bribesCount.ToString();

        Assert.AreEqual(expected, result, "Result calculated incorrectly.");
    }
}