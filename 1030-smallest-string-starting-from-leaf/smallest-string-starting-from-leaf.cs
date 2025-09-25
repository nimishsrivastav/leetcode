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
    public string SmallestFromLeaf(TreeNode root) {
        return Dfs(root, "");
    }

    private string Dfs(TreeNode node, string path) {
        if (node == null) return "";

        char currentChar = (char)('a' + node.val);
        string currentPath = currentChar + path;

        if (node.left == null && node.right == null) return currentPath;

        string result = null;

        if (node.left != null) {
            string leftResult = Dfs(node.left, currentPath);

            result = (result == null) ? leftResult : (string.Compare(leftResult, result) < 0 ? leftResult : result);
        }

        if (node.right != null) {
            string rightResult = Dfs(node.right, currentPath);

            result = (result == null) ? rightResult : (string.Compare(rightResult, result) < 0 ? rightResult : result);
        }

        return result;
    }
}

/*
ALGORITHMIC STEPS:
1. Start DFS traversal from root with empty path
2. For each node:
   - Convert node value to character ('a' + val)
   - Prepend character to current path (building leaf-to-root string)
3. If current node is a leaf:
   - Return the complete path string
4. If current node has children:
   - Recursively get results from left and/or right subtrees
   - Return the lexicographically smallest result
5. Use string comparison to determine the smallest string

TIME COMPLEXITY: O(N * M)
- N = number of nodes in the tree
- M = average length of path from root to leaf (tree height)
- We visit each node once, and string operations take O(M) time
- In worst case (skewed tree), M can be N, making it O(N²)

SPACE COMPLEXITY: O(H * M)
- H = height of the tree (recursion stack depth)
- M = average string length stored at each recursive call
- In worst case (skewed tree), H = N, so O(N * M)
- In best case (balanced tree), H = log(N), so O(log(N) * M)
*/