using System.Collections.Generic;

namespace HackerRankSolutions.LeetCodeProblems.Helpers.ListNode;

public static class ListNodeExt
{
    public static ListNode? ToListNode(this int[] arr)
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
    
    public static int[]? ToArray(this ListNode? node)
    {
        if (node is null)
            return null;

        var ret = new List<int>();
        do
        {
            ret.Add(node.val);
            node = node.next;
        } while (node != null);
            
        return ret.ToArray();
    }
}