using System;
using System.Collections.Generic;

namespace HackerRankSolutions.LeetCodeProblems.Helpers.TreeNode;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int x)
    {
        val = x;
    }

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static TreeNode? FindNode(TreeNode? root, int target)
    {
        if (root == null)
            return null;
        if (root.val == target)
            return root;
        
        return FindNode(root.left, target) ?? FindNode(root.right, target);
    }

    public override string ToString()
    {
        return $"left: {(left is not null ? left.val : "null")}, right: {(right is not null ? right.val.ToString() : "null")}, val: {val}";
    }
    
    public void Print()
    {
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(this);
        var level = 0;

        while (queue.Count > 0)
        {
            var size = queue.Count;
            var currentLevel = new List<string>();

            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    currentLevel.Add(node.val.ToString());
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    currentLevel.Add("null");
                }
            }

            // Remove trailing "null" entries to match LeetCode formatting
            while (currentLevel.Count > 0 && currentLevel[currentLevel.Count - 1] == "null")
            {
                currentLevel.RemoveAt(currentLevel.Count - 1);
            }

            // Stop once we reach a level with no actual nodes
            if (currentLevel.Count == 0)
                break;

            Console.WriteLine($"level {level}: {string.Join(", ", currentLevel)}");
            level++;
        }
    }
}