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
    private int index = 0;

    public TreeNode BstFromPreorder(int[] preorder) {
        if (preorder == null || preorder.Length == 0) return null;

        index = 0;

        return BuildBST(preorder, int.MinValue, int.MaxValue);
    }

    private TreeNode BuildBST(int[] preorder, int min, int max) {
        if (index >= preorder.Length) return null;

        int currentValue = preorder[index];

        if (currentValue < min || currentValue > max) return null;

        TreeNode root = new TreeNode(currentValue);
        index++;

        root.left = BuildBST(preorder, min, currentValue);
        root.right = BuildBST(preorder, currentValue, max);

        return root;
    }
}