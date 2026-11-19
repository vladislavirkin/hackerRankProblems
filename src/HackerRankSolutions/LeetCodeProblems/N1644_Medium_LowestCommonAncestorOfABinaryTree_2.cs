using System;
using System.Collections.Generic;
using HackerRankSolutions.LeetCodeProblems.Helpers.TreeNode;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Dfs + saving path || DFS with marking found nodes.
/// <see cref="LowestCommonAncestor_First"/>
/// Save path to both nodes to 2 stacks, while finding them.
/// Then find first common node in both sets.
/// ---
/// Updated!
/// Stack:
/// RT = 175 ms, beats 97.37%.
/// M = 63.25 MB, beats 65.79%.
/// HashSet:
/// RT = 202 ms, beats 63.16%.
/// M = 63.78 MB, beats 50.00%.
/// ---
/// Complexity Analysis:
/// O(n), O(n) space.
/// <see cref="LCA"/>
/// Save path to both nodes to 2 stacks, while finding them.
/// Then find first common node in both sets.
/// ---
/// RT = 198 ms, beats 76.32%.
/// M = 63.84 MB, beats 47.37%.
/// ---
/// Complexity Analysis:
/// O(n), O(n) space.
/// Let n be the number of nodes in the binary tree.
/// Time complexity: O(n).
///     The algorithm performs a depth-first search (DFS) traversal of the entire tree.
///     In the worst case, each node is visited once.
///     Therefore, the time complexity is linear with respect to the number of nodes in the tree, which is O(n).
/// Space complexity: O(n).
///     The space complexity is determined by the recursion stack used during the DFS traversal.
///     In the worst case, the tree can be a skewed tree (e.g., all nodes in a single branch),
///     leading to a recursion depth of n.
///     Additionally, the lambda function and other local variables contribute constant space,
///     which is negligible compared to the recursion stack.
///     Therefore, the space complexity is O(n).
/// </summary>
/// Tree:
///             3
///          /     \
///         5       1
///       /  \     /  \
///      6    2   0    8
///         /  \
///        7    4
[TestFixture(Description = "Medium" + "https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-ii/")]
public class N1644_Medium_LowestCommonAncestorOfABinaryTree_2
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 1, 3);
        yield return new TestCaseData(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 4, 5);
        yield return new TestCaseData(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 }, 5, 10, null);
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(int?[] array, int pValue, int qValue, int? expectedValue)
    {
        var root = array.BuildTree() ?? throw new ArgumentException("Root is null. Tree wa not built.");
        var p = TreeNode.FindNode(root, pValue);
        if (p is null)
        {
            Console.WriteLine($"Node p {pValue} was not wound in the tree.");
            p = new TreeNode(pValue);
        }
        var q = TreeNode.FindNode(root, qValue);
        if (q is null)
        {
            Console.WriteLine($"Node q {qValue} was not wound in the tree.");
            q = new TreeNode(qValue);
        }
        
        var expected = expectedValue is not null ? TreeNode.FindNode(root, expectedValue.Value) : null;
        if (expected is null)
        {
            Console.WriteLine($"Node expected {expectedValue} was not wound in the tree.");
        }
        
        // var ret = LowestCommonAncestor_First(root, p, q);
        var ret = LCA(root, p, q);
        Assert.That(ret, Is.EqualTo(expected), $"Result calculated incorrectly.");
    }
    
    public TreeNode? LowestCommonAncestor_First(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode? ret = null;
        
        var pPath = new Stack<TreeNode>();

        var qPath = new Stack<TreeNode>();
        
        var pres = FindNode(root, p.val, pPath);
        var qres = FindNode(root, q.val, qPath);
        
        if (pres == null || qres == null)
            return ret;

        while (pPath.Count > 0 && qPath.Count > 0 && pPath.Peek() == qPath.Peek())
        {
            ret = pPath.Pop();
            qPath.Pop();
        }
        
        return ret;
    }
    
    private static TreeNode? FindNode(TreeNode? root, int target, Stack<TreeNode> set)
    {
        if (root == null)
            return null;

        if (root.val == target)
        {
            set.Push(root);
            return root;
        }
        
        var cur =  FindNode(root.left, target, set) ?? FindNode(root.right, target, set);
        
        if (cur != null)
            set.Push(root);

        return cur;
    }
    
    public TreeNode? LCA(TreeNode root, TreeNode p, TreeNode q)
    {
        var nodesFound = false;
        
        // Start DFS traversal to find the lowest common ancestor
        TreeNode? ret = DFS(root, p, q, ref nodesFound);
        // Return the result only if both nodes are found
        return nodesFound ? ret : null;
    }

    private TreeNode? DFS(TreeNode? node, TreeNode p, TreeNode q, ref bool nodesFound)
    {
        // Base case: If the node is null, return null
        if (node == null)
            return null;

        // Recursively search the left and right subtrees
        TreeNode? left = DFS(node.left, p, q, ref nodesFound);
        TreeNode? right = DFS(node.right, p, q, ref nodesFound);

        // Check conditions for current node being part of the solution
        int conditions = 0;
        if (node == p || node == q)
            conditions++;
        if (left != null)
            conditions++;
        if (right != null)
            conditions++;
        if (conditions == 2)
            nodesFound = true; // Mark that both nodes are found

        // Determine if current node is the lowest common ancestor
        if ((left != null && right != null) || node == p || node == q)
            return node;

        // Return the non-null child, if any
        return left != null ? left : right;
    }
}