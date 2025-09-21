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
        if (root == null) return null;

        TreeNode curr = root;

        while (curr != null) {
            if (p.val > curr.val && q.val > curr.val) curr = curr.right;
            else if (p.val < curr.val && q.val < curr.val) curr = curr.left;
            else return curr;
        }

        return null;
    }
}