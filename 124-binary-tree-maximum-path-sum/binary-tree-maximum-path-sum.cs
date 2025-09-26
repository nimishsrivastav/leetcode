/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private int maxSum;

    public int MaxPathSum(TreeNode root) {
        maxSum = int.MinValue;

        MaxPathSumHelper(root);

        return maxSum;
    }

    private int MaxPathSumHelper(TreeNode node) {
        if (node == null) return 0;

        int leftMax = Math.Max(0, MaxPathSumHelper(node.left));
        int rightMax = Math.Max(0, MaxPathSumHelper(node.right));

        int currentPathSum = leftMax + node.val + rightMax;

        maxSum = Math.Max(maxSum, currentPathSum);

        return node.val + Math.Max(leftMax, rightMax);
    }
}

/*
ALGORITHMIC STEPS:
1. Initialize a global variable to track the maximum path sum found so far
2. Start a DFS traversal from the root node
3. For each node:
   a. Recursively calculate max path sum from left subtree (ignore if negative)
   b. Recursively calculate max path sum from right subtree (ignore if negative)
   c. Calculate the path sum that passes through current node (left + node + right)
   d. Update global maximum with this path sum
   e. Return the maximum single-direction path from current node upwards
4. Return the global maximum after traversal completes

KEY INSIGHTS:
- At each node, we consider two things:
  1. The maximum path that passes through this node (for updating global max)
  2. The maximum path that starts from this node and goes in one direction (for parent nodes)
- We ignore negative contributions by using Math.Max(0, subtreeSum)
- The path that passes through a node includes both left and right subtrees
- The path that can be extended upwards can only go in one direction

TIME COMPLEXITY: O(N)
- We visit each node exactly once in the tree
- At each node, we perform constant time operations
- N is the number of nodes in the tree

SPACE COMPLEXITY: O(H) 
- The space is used by the recursion call stack
- H is the height of the tree
- In worst case (skewed tree): O(N)
- In best case (balanced tree): O(log N)
*/