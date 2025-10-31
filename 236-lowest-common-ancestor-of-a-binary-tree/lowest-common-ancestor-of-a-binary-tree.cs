/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q) return root;

        TreeNode leftSubtree = LowestCommonAncestor(root.left, p, q);
        TreeNode rightSubtree = LowestCommonAncestor(root.right, p, q);

        if (leftSubtree != null && rightSubtree != null) return root;

        if (leftSubtree != null) return leftSubtree;

        return rightSubtree;
    }
}