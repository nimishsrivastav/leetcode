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
public class BSTIterator {
    private Stack<TreeNode> stack;

    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        PushAllLeft(root);
    }

    private void PushAllLeft(TreeNode node) {
        while (node != null) {
            stack.Push(node);
            node = node.left;
        }
    }
    
    public int Next() {
        TreeNode nextNode = stack.Pop();

        if (nextNode.right != null) PushAllLeft(nextNode.right);

        return nextNode.val;
    }
    
    public bool HasNext() {
        return stack.Count > 0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */

/*
ALGORITHMIC STEPS:
1. Use a stack to simulate the in-order traversal of BST
2. In constructor: Push all leftmost nodes starting from root onto stack
3. For Next(): 
   - Pop the top node from stack (this is the next smallest)
   - If popped node has right child, push all leftmost nodes of right subtree
   - Return the value of popped node
4. For HasNext(): Simply check if stack is not empty

KEY INSIGHT: In-order traversal of BST gives nodes in sorted order

TIME COMPLEXITY ANALYSIS:
- Constructor: O(h) where h is height of tree
  * We push at most h nodes (all leftmost nodes from root to leaf)
  * In worst case (skewed tree): O(n), Best case (balanced): O(log n)

- Next(): Amortized O(1)
  * Each node is pushed and popped exactly once during entire iteration
  * Total operations across all Next() calls = O(n)
  * Per call amortized = O(n)/n = O(1)
  * Individual call can be O(h) in worst case, but amortized is O(1)

- HasNext(): O(1)
  * Simple stack size check

SPACE COMPLEXITY ANALYSIS:
- O(h) where h is height of tree
- Stack stores at most h nodes at any time
- In worst case (skewed tree): O(n)
- In best case (balanced tree): O(log n)
*/