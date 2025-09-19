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
    private TreeNode BuildTree(int[] nums, int start, int end) {
        if (start > end) return null;

        int maxIndex = start;
        for (int i = start + 1; i <= end; i++) {
            if (nums[i] > nums[maxIndex]) maxIndex = i;
        }

        TreeNode root = new TreeNode(nums[maxIndex]);
        root.left = BuildTree(nums, start, maxIndex - 1);
        root.right = BuildTree(nums, maxIndex + 1, end);

        return root;
    }
    
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        if (nums == null || nums.Length == 0) return null;

        return BuildTree(nums, 0, nums.Length - 1);
    }
}

/*
    * Algorithm Steps:
    * 1. Base case: If array is empty, return null
    * 2. Find the maximum value and its index in the current array
    * 3. Create root node with the maximum value
    * 4. Recursively build left subtree from elements to the left of max
    * 5. Recursively build right subtree from elements to the right of max
    * 6. Return the root node
    * 
    * Time Complexity: O(n²) worst case, O(n log n) average case
    * - In worst case (sorted array), we scan entire array for each recursive call
    * - In average case, the array is roughly divided in half each time
    * 
    * Space Complexity: O(n) for recursion stack in worst case, O(log n) average case
    * - The recursion depth depends on the tree height
    * - Additional O(n) space for creating new arrays in each recursive call
*/