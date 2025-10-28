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
    public bool IsCompleteTree(TreeNode root) {
        if (root == null) return true;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        bool foundNullNode = false;

        while (queue.Count > 0) {
            TreeNode current = queue.Dequeue();

            if (current == null) {
                foundNullNode = true;
            }
            else {
                if (foundNullNode) return false;

                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
        }

        return true;
    }
}