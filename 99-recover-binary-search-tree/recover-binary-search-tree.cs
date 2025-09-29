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
    private TreeNode first = null;
    private TreeNode second = null;
    private TreeNode prev = null;

    public void RecoverTree(TreeNode root) {
        InOrderTraversal(root);

        if (first != null && second != null) {
            int temp = first.val;
            first.val = second.val;
            second.val = temp;
        }
    }

    private void InOrderTraversal(TreeNode node) {
        if (node == null) return;

        InOrderTraversal(node.left);

        if (prev != null && prev.val > node.val) {
            if (first == null) first = prev;

            second = node;
        }

        prev = node;

        InOrderTraversal(node.right);
    }
}