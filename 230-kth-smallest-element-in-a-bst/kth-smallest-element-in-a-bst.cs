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
    private int count = 0;
    private int result = 0;
    
    public int KthSmallest(TreeNode root, int k) {
        count = 0;
        result = 0;

        InOrderTraversal(root, k);

        return result;
    }

    private void InOrderTraversal(TreeNode node, int k) {
        if (node == null || count >= k) return;

        InOrderTraversal(node.left, k);

        count++;
        if (count == k) {
            result = node.val;
            return;
        }

        InOrderTraversal(node.right, k);
    }
}

/* 
ALGORITHMIC STEPS:
    1. Use in-order traversal (left -> root -> right) which gives elements in sorted order for BST
    2. Keep a counter to track how many nodes we've visited
    3. When counter reaches k, we've found our kth smallest element
    4. Use early termination to stop traversal once we find the answer
    
APPROACH: Recursive In-Order Traversal with Counter

TIME COMPLEXITY: 
- Best Case: O(k) - when kth element is found early in traversal
- Worst Case: O(n) - when k = n (need to visit all nodes)
- Average Case: O(k + log n) for balanced BST

SPACE COMPLEXITY:
- Recursive Approach: O(h) where h is height of tree (call stack)
  - Best Case: O(log n) for balanced BST
  - Worst Case: O(n) for skewed BST
- Iterative Approach: O(h) for the stack
*/