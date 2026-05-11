using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

public static class Helper
{
    public static IEnumerable<TestCaseData> TestSource___ArrayInt()
    {
        yield return new TestCaseData(new [] {7,1,5,3,6,4}, 5);
        yield return new TestCaseData(new [] {7,6,4,3,1}, 0);
    }
    
    public static IEnumerable<TestCaseData> TestSource___ArrayArray()
    {
        yield return new TestCaseData(new [] {1, 2, 4},  new [] {1, 1, 2, 3, 4, 4});
        yield return new TestCaseData(Array.Empty<int>(), Array.Empty<int>());
        yield return new TestCaseData(Array.Empty<int>(), new [] {0});
    }
}