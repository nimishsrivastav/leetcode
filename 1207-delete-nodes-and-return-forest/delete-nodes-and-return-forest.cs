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
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        var toDeleteSet = new HashSet<int>(to_delete);
        var result = new List<TreeNode>();

        TreeNode remainingRoot = DeleteNodesHelper(root, toDeleteSet, result, true);

        return result;
    }

    private TreeNode DeleteNodesHelper(TreeNode node, HashSet<int> toDeleteSet, List<TreeNode> result, bool isRoot) {
        if (node == null) return null;

        bool shouldDelete = toDeleteSet.Contains(node.val);

        if (isRoot && !shouldDelete) {
            result.Add(node);
        }

        node.left = DeleteNodesHelper(node.left, toDeleteSet, result, shouldDelete);
        node.right = DeleteNodesHelper(node.right, toDeleteSet, result, shouldDelete);

        return shouldDelete ? null : node;
    }
}

/**
     * Deletes nodes with values in to_delete array and returns forest of remaining trees
     * 
     * Algorithm Steps:
     * 1. Convert to_delete array to HashSet for O(1) lookup
     * 2. Use DFS to traverse the tree
     * 3. For each node, check if it should be deleted
     * 4. If a node is deleted, its children (if not deleted) become new roots
     * 5. If a node is not deleted and has no parent, it's a root of a tree in forest
     * 
     * Time Complexity: O(n) where n is number of nodes in tree
     * - We visit each node exactly once
     * - HashSet lookup is O(1)
     * 
     * Space Complexity: O(n + m) where n is tree height and m is size of to_delete
     * - O(n) for recursion stack (worst case for skewed tree)
     * - O(m) for HashSet to store values to delete
     * - O(k) for result list where k is number of trees in forest
     */