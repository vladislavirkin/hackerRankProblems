using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="NumUniqueEmails_First"/>
/// RT = 11 ms, beats 38%.
/// M = 47 MB, beats 56%.
/// <see cref="NumUniqueEmails_Best"/>
/// RT = 3 ms, beats 100%.
/// M = 44 MB, beats 96%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/unique-email-addresses/")]
public class N929_Easy_UniqueEmailAddresses
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }, 2);
        yield return new TestCaseData(new [] { "a@leetcode.com", "b@leetcode.com", "c@leetcode.com" }, 3);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(string[] emails, int expected)
    {
        // var ret = NumUniqueEmails_First(emails);
        var ret = NumUniqueEmails_Best(emails);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public int NumUniqueEmails_Best(string[] emails)
    {
        var seen = new HashSet<string>();

        foreach (var email in emails) {
            ReadOnlySpan<char> span = email.AsSpan();
        
            // Allocate a temporary buffer on the stack (zero heap allocation)
            Span<char> buffer = stackalloc char[span.Length];
            int written = 0;
            int i = 0;
            bool ignoreLocal = false;

            // 1. Process local name up to '@'
            while (i < span.Length && span[i] != '@') {
                char c = span[i];
                if (c == '+') {
                    ignoreLocal = true;
                }
                else if (!ignoreLocal && c != '.') {
                    buffer[written++] = c;
                }
                i++;
            }

            // 2. Process domain name (if '@' was found)
            while (i < span.Length) {
                buffer[written++] = span[i++];
            }

            // Convert only the final normalized slice into a string for the HashSet
            seen.Add(new string(buffer.Slice(0, written)));
        }

        return seen.Count;
    }
    
    public int NumUniqueEmails_First(string[] emails)
    {
        var store = new HashSet<string>();
        for (int i = 0; i < emails.Length; i++)
        {
            var parts = emails[i].Split("@");
            emails[i] = parts[0].Replace(".", "").Split("+")[0] + "@" + parts[1];
            store.Add(emails[i]);
        }
        
        return store.Count;
    }
}