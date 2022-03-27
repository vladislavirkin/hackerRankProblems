using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class LongestSubArray
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 0, 1, 2, 1, 2, 3 }, 4);
        yield return new TestCaseData(new List<int> { 1, 2, 3, 4, 5 }, 2);
        yield return new TestCaseData(new List<int> { 1, 1, 1, 3, 3, 2, 2 }, 4);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void CalculateLongestSubarrayLength(List<int> arr, int expected)
    {
        var longest = 1;
        var descendingLength = 1;
        var increasingLength = 1;
        
        if (arr.Count < 2)
            longest = arr.Count;

        for (var i = 1; i < arr.Count; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                increasingLength++;
                descendingLength++;
            }
            else if (arr[i] == arr[i - 1] + 1)
            {
                increasingLength = descendingLength + 1;
                descendingLength = 1;
            }
            else if (arr[i] == arr[i - 1] - 1)
            {
                descendingLength = increasingLength + 1;
                increasingLength = 1;
            }
            else
            {
                descendingLength = 1;
                increasingLength = 1;
            }

            longest = Math.Max(longest, Math.Max(descendingLength, increasingLength));
        }

        Assert.AreEqual(expected, longest, "Length of the longest Subarray calculated incorrectly.");
    }
}