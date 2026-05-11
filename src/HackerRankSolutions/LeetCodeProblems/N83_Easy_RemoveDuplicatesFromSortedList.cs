using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="DeleteDuplicates"/>
/// RT = 0 ms, beats 100%.
/// M = 43 MB, beats 14%.
/// <see cref="DeleteDuplicatesBestM"/>
/// RT = 20 ms, beats 2%.
/// M = 41 MB, beats 99%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/remove-duplicates-from-sorted-list")]
public class N83_Easy_RemoveDuplicatesFromSortedList
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 1, 2}, new [] {1,2});
        yield return new TestCaseData(new [] {1, 1, 2, 3, 3}, new [] {1,2,3});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] x, int[] expected)
    {
        var list = new List<ListNode>();
        list.Add(new ListNode(x[x.Length - 1], null));
        var k = 0;
        for (int i = x.Length - 2; i >= 0; i--)
        {
            list.Add(new ListNode(x[i], list[k]));
            k++;
        }
            
        var ret = DeleteDuplicates(list.Last());

        Assert.That(ret.ToArray(), Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public ListNode DeleteDuplicates(ListNode head)
    {
        var current = head;

        while (current?.next != null)
        {
            if (current.val == current.next.val)
                current.next = current.next.next;
            else
                current = current.next;
        }

        return head;
    }
    
    public ListNode DeleteDuplicatesBestM(ListNode head)
    {
        var current = head;
        
        while (current?.next is not null)
        {
            if (current.val == current.next.val)
                current.next = current.next.next;
            else
                current = current.next;
        }
        
        GC.Collect();
        
        return head;
    }
    
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public int[] ToArray()
        {
            var ret = new List<int>();
            ret.Add(val);
            var cur = next;
            while (cur != null)
            {
                ret.Add(cur.val);
                cur = cur.next;
            }
            
            return ret.ToArray();
        }
    }
}