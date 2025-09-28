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
    public int Rob(TreeNode root) {
        if (root == null) return 0;

        int[] result = RobHelper(root);

        return Math.Max(result[0], result[1]);
    }

    private int[] RobHelper(TreeNode node) {
        if (node == null) return new int[] { 0, 0 };

        int[] leftResult = RobHelper(node.left);
        int[] rightResult = RobHelper(node.right);

        int excludeCurrent = Math.Max(leftResult[0], leftResult[1]) + Math.Max(rightResult[0], rightResult[1]);

        int robCurrent = node.val + leftResult[0] + rightResult[0];

        return new int[] { excludeCurrent, robCurrent };
    }
}