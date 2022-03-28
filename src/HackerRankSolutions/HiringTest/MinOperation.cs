using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.HiringTest;

[TestFixture]
public class MinOperation
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new List<long> { 1, 2, 3, 8, 2, 8, 9, 10 }, new List<int> { 1, 2, 3, 4, 2, 4, 5, 5 });
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(List<long> kValues, List<int> expected)
    {
        var tmp = new List<long>(kValues);
        tmp.Sort();
        var k = tmp.Last();
        
        var table = new int[k + 1];
 
        for(var i = 1; i <= k; i++)
        {
            table[i] = table[i - 1] + 1;
            
            if (i % 2 == 0)
                table[i] = Math.Min(table[i], table[i / 2] + 1);
        }

        var ret = kValues.Select(item => table[item]).ToList();
        CollectionAssert.AreEqual(expected, ret, "Incorrectly calculated result.");
    }
}