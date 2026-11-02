using System;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy"+"https://leetcode.com/problems/palindrome-number/")]
public class Test
{
    [Test]
    public void Solve()
    {
    
        var h = new Holder();
        h.Counter.Inc();

        Console.WriteLine(h.Counter.Value);
    }
	
    struct Counter
    {
        public int Value;
        public void Inc() => Value = Value + 1;
    }

    class Holder
    {
        public Counter Counter { get; set; } = new Counter();
    }
}