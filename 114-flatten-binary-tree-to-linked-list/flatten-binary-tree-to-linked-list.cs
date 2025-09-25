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
    public void Flatten(TreeNode root) {
        if (root == null) return;

        Flatten(root.left);
        Flatten(root.right);

        TreeNode rightSubTree = root.right;

        root.right = root.left;
        root.left = null;

        TreeNode current = root;

        while (current.right != null) current = current.right;

        current.right = rightSubTree;
    }
}