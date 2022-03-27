using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.ProblemSolving;

[TestFixture]
public class SubArraySums
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<int> { 1, 0, 3, 4, 5 }, new List<List<int>> { new() { 1, 3, 10 } }, new List<int> { 14 });
        yield return new TestCaseData(new List<int> { 1, 0, 3, 4, 5, 10, 8, 0, 9 }, new List<List<int>> { new() { 2, 8, 100 }, new() { 4, 6, 100 } }, new List<int> { 230, 19 });
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void FindSums(List<int> numbers, List<List<int>> queries, List<int> expected)
    {
        var result = new List<long>();
        var numbersSize = numbers.Count;

        var sums = new long[numbersSize];
        var zeroes = new long[numbersSize];

        sums[0] = numbers[0];
        zeroes[0] = numbers[0] == 0 ? 1 : 0;

        for (var i = 1; i < numbersSize; i++)
        {
            zeroes[i] = zeroes[i - 1];
            if (numbers[i] == 0)
                zeroes[i]++;

            sums[i] += sums[i - 1] + numbers[i];
        }

        foreach (var query in queries)
        {
            if (query.Count != 3) 
                continue;
            
            var left = query[0];
            var right = query[1];
            var weight = query[2];

            var sum = sums[right - 1] - (left - 2 < 0 ? 0 : sums[left - 2]);
            sum += (zeroes[right - 1] - (left - 2 < 0 ? 0 : zeroes[left - 2])) * weight;
            result.Add(sum);
        }

        CollectionAssert.AreEqual(expected, result, "Subarray sum calculated incorrectly.");
    }
}