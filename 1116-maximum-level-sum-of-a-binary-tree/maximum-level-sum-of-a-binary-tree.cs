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
    public int MaxLevelSum(TreeNode root) {
        if (root == null) return 0;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int currentLevel = 1;
        int maxSum = int.MinValue;
        int maxSumLevel = 1;

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            int currentLevelSum = 0;

            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                currentLevelSum += node.val;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            if (currentLevelSum > maxSum) {
                maxSum = currentLevelSum;
                maxSumLevel = currentLevel;
            }

            currentLevel++;
        }

        return maxSumLevel;
    }
}