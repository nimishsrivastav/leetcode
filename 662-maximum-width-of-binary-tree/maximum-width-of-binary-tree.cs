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
    public int WidthOfBinaryTree(TreeNode root) {
        if (root == null) return 0;

        Queue<(TreeNode node, int index)> queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 0));

        int maxWidth = 0;

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            int firstIndex = queue.Peek().index;
            int lastIndex = firstIndex;

            for (int i = 0; i < levelSize; i++) {
                var (node, index) = queue.Dequeue();
                lastIndex = index;

                int normalizedIndex = index - firstIndex;

                if (node.left != null)
                    queue.Enqueue((node.left, 2 * normalizedIndex));

                if (node.right != null)
                    queue.Enqueue((node.right, 2 * normalizedIndex + 1));
            }
        
            int currentWidth = lastIndex - firstIndex + 1;
            maxWidth = Math.Max(maxWidth, currentWidth);
        }

        return maxWidth;
    }

}