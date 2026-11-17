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
    
    public static IEnumerable<TestCaseData> TestSource___GridInt()
    {
        yield return new TestCaseData(new [] {new [] {2,4}, new [] {6,8}}, 4);
        yield return new TestCaseData(new [] {new [] {1,5}, new [] {2,3}}, 5);
        yield return new TestCaseData(new [] {new [] {1,2}, new [] {3,4}}, -1);
        yield return new TestCaseData(new [] {new [] {146}}, 0);
        yield return new TestCaseData(new [] {new [] {1,1,10000}}, 1);
    }
    
    public static IEnumerable<TestCaseData> TestSource___StringBool()
    {
        yield return new TestCaseData("()", true);
        yield return new TestCaseData("()[]{}", true);
        yield return new TestCaseData("(}", false);
        yield return new TestCaseData("([])", true);
        yield return new TestCaseData("([)]", false);
    }
    
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
        
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        
        public static TreeNode ArrayToTreeNode(int?[] arr)
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

                if (i < arr.Length && arr[i] != null) {
                    curr.right = new TreeNode(arr[i].Value);
                    queue.Enqueue(curr.right);
                }
                i++;
            }

            return root;
        }
        
        public static void Print(TreeNode root)
        {
            if (root == null)
                return;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
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
                    } else
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
}