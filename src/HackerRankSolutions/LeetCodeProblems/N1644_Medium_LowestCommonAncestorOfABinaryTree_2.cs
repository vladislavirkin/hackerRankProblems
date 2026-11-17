using System.Collections.Generic;
using NUnit.Framework;

namespace HackerRankSolutions.LeetCodeProblems;

/// <summary>
/// # Main idea:
/// Bruteforce.
/// <see cref="DigitSum"/>
/// Complexity | O(n) Proof.
/// O(n) Time and O(n) Space.
/// A round costs about as much as the current length.
/// At worst, the length stays the same for one round and then halves,
/// so all the rounds together cost: n + n + n/2 + n/2 + n/4 + ... = 2(n + n/2 + n/4 + ...) < 4n.
/// ---
/// O(n), O(n) space.
/// ---
/// RT = 0 ms, beats 100%.
/// M = 39.01 MB, beats 82.76%.
/// </summary>
[TestFixture(Description = "Easy" + "https://leetcode.com/problems/calculate-digit-sum-of-a-string/")]
public class N1644_Medium_LowestCommonAncestorOfABinaryTree_2
{
    public static IEnumerable<TestCaseData> TestSource()
    {
        yield return new TestCaseData("11111222223", 3, "135");
        yield return new TestCaseData("00000000", 3, "000");
    }

    [Test]
    [TestCaseSource(nameof(TestSource))]
    public void Solve(TreeNode root, TreeNode p, TreeNode q, TreeNode expected)
    {
        var ret = LowestCommonAncestor(root, p, q);
        Assert.That(ret, Is.EqualTo(expected), "Result calculated incorrectly.");
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        return root;
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
    }
}