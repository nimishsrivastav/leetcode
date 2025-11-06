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
    public int SumNumbers(TreeNode root) {
        return DFS(root, 0);
        // return DFS(root, "");
    }

    private int DFS(TreeNode node, int currentNumber) {
        if (node == null) return 0;

        currentNumber = currentNumber * 10 + node.val;

        if (node.left == null && node.right == null)
            return currentNumber;

        int leftSum = DFS(node.left, currentNumber);
        int rightSum = DFS(node.right, currentNumber);

        return leftSum + rightSum;
    }

    // private int DFS(TreeNode node, string currentPath) {
    //     if (node == null) return 0;

    //     currentPath += node.val.ToString();

    //     if (node.left == null && node.right == null)
    //         return int.Parse(currentPath);

    //     int leftSum = DFS(node.left, currentPath);
    //     int rightSum = DFS(node.right, currentPath);

    //     return leftSum + rightSum;
    // }
}