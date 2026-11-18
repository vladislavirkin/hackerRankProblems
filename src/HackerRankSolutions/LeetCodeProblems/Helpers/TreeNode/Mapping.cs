using System.Collections.Generic;

namespace HackerRankSolutions.LeetCodeProblems.Helpers.TreeNode;

public static class Mapping
{
    public static TreeNode? BuildTree(this int?[] arr)
    {
        if (arr == null || arr.Length == 0 || arr[0] == null)
            return null;

        var root = new TreeNode(arr[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while (queue.Count > 0 && i < arr.Length)
        {
            var curr = queue.Dequeue();

            if (i < arr.Length && arr[i] != null)
            {
                curr.left = new TreeNode(arr[i].Value);
                queue.Enqueue(curr.left);
            }

            i++;

            if (i < arr.Length && arr[i] != null)
            {
                curr.right = new TreeNode(arr[i].Value);
                queue.Enqueue(curr.right);
            }

            i++;
        }

        return root;
    }
}