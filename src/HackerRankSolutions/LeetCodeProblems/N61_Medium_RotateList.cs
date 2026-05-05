using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// <see cref="RotateRight"/>
/// RT = 0 ms, beats 100%.
/// M = 42 MB, beats 75%.
/// <see cref="RotateRightM"/>
/// RT = 0 ms, beats 100%.
/// M = 41 MB, beats 100%.
/// </summary>
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/rotate-list/")]
public class N61_Medium_RotateList
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new [] {1,2,3,4,5}, 2 , new [] {4,5,1,2,3});
        yield return new TestCaseData(new [] {0,1,2}, 4 , new [] {2,0,1});
        yield return new TestCaseData(new [] {1,2}, 2 , new [] {1,2});
    }
    
    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int[] x, int k, int[] expected)
    {
        var ret = RotateRight(ListNode.FromArray(x), k);

        Assert.That(ret.ToArray(), Is.EqualTo(expected), "Result calculated incorrectly.");
    }

    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || k == 0 || head.next == null)
            return head;

        var list = new List<ListNode>();
        var tmp = head;
        var length = 0;
        do
        {
            length++;
            list.Add(tmp);
            tmp = tmp.next;
            
        } while (tmp != null);
        
        var rem = k % length;
        if (rem == 0)
            return head;
        
        list[length - 1].next = head;
        list[length - rem - 1].next = null;
        return list[length - rem];
    }
    
    public ListNode RotateRightM(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0)
            return head;

        // Step 1: count nodes
        int nodecount = 1;
        ListNode tail = head;
        while (tail.next != null)
        {
            tail = tail.next;
            nodecount++;
        }

        // Step 2: reduce k
        k %= nodecount;
        if (k == 0)
            return head;

        // Step 3: find new tail (nodecount - k - 1)
        int stepsToNewTail = nodecount - k - 1;
        ListNode newTail = head;

        for (int i = 0; i < stepsToNewTail; i++)
        {
            newTail = newTail.next;
        }

        // Step 4: rearrange pointers
        ListNode newHead = newTail.next;
        newTail.next = null;
        tail.next = head;

        return newHead;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public int[] ToArray()
        {
            var ret = new List<int>();
            var node = this;
            do
            {
                ret.Add(node.val);
                node = node.next;
            } while (node != null);
            
            return ret.ToArray();
        }
        
        public static ListNode? FromArray(int [] arr)
        {
            if (arr.Length == 0)
                return null;
            
            var ret = new ListNode(arr[0]);
            if (arr.Length == 1)
                return ret;
            
            var tmp = ret;

            for (int i = 1; i <= arr.Length - 1; i++)
            {
                
                tmp.next = new ListNode(arr[i]);
                tmp = tmp.next;
            }
            
            return ret;
        }
    }
}