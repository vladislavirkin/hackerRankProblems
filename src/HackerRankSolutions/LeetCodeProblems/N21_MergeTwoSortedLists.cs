using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

[TestFixture(Description = "Easy"+"https://leetcode.com/problems/merge-two-sorted-lists/")]
public class N21_MergeTwoSortedLists
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1, 2, 4}, new [] {1, 3, 4},  new [] {1, 1, 2, 3, 4, 4});
        yield return new TestCaseData(Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>());
        yield return new TestCaseData(Array.Empty<int>(), new [] {0}, new [] {0});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] x, int[] y, int[] expected)
    {
        ListNode list1;
        ListNode list2;
        for (var i = 1; i < x.Length - 1; i++)
        {
            list1 = new ListNode(x[i-1], new ListNode(x[i]));
        }
            
        var ret = new List<int>();

        Assert.AreEqual(expected, ret, "Result calculated incorrectly.");
    }
    
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        if (list1 is null)
            return list2;
        
        if (list2 is null)
            return list1;

        ListNode start;
        do
        {
            if (list1.val >= list2.val)
            {
                start = list2;
                start.next = list1;
                list2 = list2.next;
            }
            else
            {
                start = list1;
                start.next = list2; 
                list1 = list1.next;
            }
        } while (list1.next is not null || list2.next is not null);

        if (list1.next is null && list2.next is null)
            return start;
        
        if (list1.next is not null)
        {
            start.next = list1.next;
            return start;
        }
        
        start.next = list2.next;
        return start;
    }
}

public class ListNode(int val = 0, ListNode? next = null)
{ 
    public int val = val; 
    public ListNode? next = next;
}