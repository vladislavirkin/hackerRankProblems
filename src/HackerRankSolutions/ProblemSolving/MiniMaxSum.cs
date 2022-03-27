using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class MiniMaxSum
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 10, 14 });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CalculateMiniMaxSum(List<int> arr, List<int> expected)
    {
        var result = new List<long>();
        long min;
        long max;
        long sum;
        
        min = arr[0];
        max = min;
        sum = min;
        for (var i = 1; i < arr.Count; i++) 
        {
            sum += arr[i];
            if (arr[i] < min)
                min = arr[i];
            
            if (arr[i] > max)
                max = arr[i];
        }
        result.Add(sum-max);
        result.Add(sum-min);

        Assert.AreEqual(expected, result, "Min && max sum calculated incorrectly.");
    }
}