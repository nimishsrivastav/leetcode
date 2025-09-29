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
    public IList<string> BinaryTreePaths(TreeNode root) {
        var result = new List<string>();

        if (root == null) return result;

        DFS(root, "", result);

        return result;
    }

    private void DFS(TreeNode node, string path, List<string> result) {
        if (node == null) return;

        path += node.val;

        if (node.left == null && node.right == null) {
            result.Add(path);
            return;
        }

        path += "->";

        DFS(node.left, path, result);
        DFS(node.right, path, result);
    }
}