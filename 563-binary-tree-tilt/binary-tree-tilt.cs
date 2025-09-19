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
    public int FindTilt(TreeNode root) {
        int count = 0, value = 0;
        Helper(root);
        return count;

        void Helper(TreeNode node) {
            if (node == null) return;

            int temp = value + node.val;
            value = 0;
            Helper(node.left);

            int left = value;
            value = 0;
            Helper(node.right);

            count += Math.Abs(value - left);
            value += temp + left;
        }
    }
}