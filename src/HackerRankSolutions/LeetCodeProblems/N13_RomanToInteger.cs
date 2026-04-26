using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy"+"https://leetcode.com/problems/roman-to-integer/")]
public class N13_RomanToInteger
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("III", 3);
        yield return new TestCaseData("IV", 4);
        yield return new TestCaseData("XCIX", 99);
        yield return new TestCaseData("LVIII", 58);
        yield return new TestCaseData("MCMXCIV", 1994);
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string roman, int expected)
    {
        var ret = RomanToInt(roman);
        // var ret = RomanToIntBest(roman);
        
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    public int RomanToInt(string s)
    {
        var ret = 0;
        var last = s.Length - 1;
        var previous = 'n';
        
        
        for (var i = 0; i <= last; i++)
        {
            switch (s[i])
            {
                case 'I':
                {
                    ret += 1;
                    break;
                }
                case 'V':
                {
                    if (previous == 'I')
                    {
                        ret += 3; // already added 1 => 4 - 1 = 3
                        break;
                    }

                    ret += 5;
                    break;
                }
                case 'X':
                {
                    if (previous == 'I')
                    {
                        ret += 8; // already added 1 => 9 - 1 = 8
                        break;
                        
                    }

                    ret += 10;
                    break;
                }
                case 'L':
                {
                    if (previous == 'X')
                    {
                        ret += 30; // already added 10 => 40 - 10 = 30
                        break;
                        
                    }
                    
                    ret += 50;
                    break;
                }
                case 'C':
                {
                    if (previous == 'X')
                    {
                        ret += 80; // already added 10 => 90 - 10 = 80
                        break;
                        
                    }

                    ret += 100;
                    break;
                }
                case 'D':
                {
                    if (previous == 'C')
                    {
                        ret += 300; // already added 100 => 400 - 100 = 300
                        break;
                        
                    }
                    
                    ret += 500;
                    break;
                }
                case 'M':
                {
                    if (previous == 'C')
                    {
                        ret += 800; // already added 100 => 900 - 100 = 800
                        break;
                        
                    }
                    
                    ret += 1000;
                    break;
                }
            }
            
            previous = s[i];
        }
        
        return ret;
    }

    public int RomanToIntBest(string s)
    {
        var result = 0;
        var prev = int.MaxValue;
        foreach (var c in s)
        {
            var val = c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            // Already added previous.
            result += prev < val ? val - prev * 2 : val;
            prev = val;
        }

        return result;
    }
}