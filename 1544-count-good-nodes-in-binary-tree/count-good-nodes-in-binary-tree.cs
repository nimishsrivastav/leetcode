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
    public int GoodNodes(TreeNode root) {
        if (root == null) return 0;

        return DFS(root, root.val);
    }

    private int DFS(TreeNode node, int maxSoFar) {
        if (node == null) return 0;

        int goodCount = 0;

        if (node.val >= maxSoFar) goodCount = 1;

        int newMax = Math.Max(maxSoFar, node.val);
        int leftGoodNodes = DFS(node.left, newMax);
        int rightGoodNodes = DFS(node.right, newMax);

        return goodCount + leftGoodNodes + rightGoodNodes;
    }
}