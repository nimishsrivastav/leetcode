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
    public int GetMinimumDifference(TreeNode root) {
        var sorted = new List<int>();

        InOrder(root, sorted);

        int minDiff = int.MaxValue;

        for (int i = 1; i < sorted.Count; i++) {
            minDiff = Math.Min(minDiff, Math.Abs(sorted[i - 1] - sorted[i]));
        }

        return minDiff;
    }

    private void InOrder(TreeNode node, List<int> sorted) {
        if (node == null) return;

        InOrder(node.left, sorted);
        sorted.Add(node.val);
        InOrder(node.right, sorted);
    }
}