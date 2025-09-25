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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();

        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            int levelSize = queue.Count;

            var currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++) {
                TreeNode currentNode = queue.Dequeue();

                currentLevel.Add(currentNode.val);

                if (currentNode.left != null) queue.Enqueue(currentNode.left);

                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }

            result.Add(currentLevel);
        }

        return result;
    }
}