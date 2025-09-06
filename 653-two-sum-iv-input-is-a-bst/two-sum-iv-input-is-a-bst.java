/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    public boolean findTarget(TreeNode root, int k) {
        HashSet<Integer> res = new HashSet<>();

        return recursiveCall(root, k, res);
    }

    private boolean recursiveCall(TreeNode root, int k, HashSet<Integer> res) {
        if (root == null) return false;

        if (res.contains(k - root.val)) return true;

        res.add(root.val);

        return recursiveCall(root.left, k, res) || recursiveCall(root.right, k, res);
    }
}