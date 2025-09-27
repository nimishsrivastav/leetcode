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
    // public int[] FindMode(TreeNode root) {
    //     if (root == null) return new int[0];

    //     var freq = new Dictionary<int, int>();

    //     CountFrequencies(root, freq);

    //     int maxFreq = 0;

    //     foreach (var f in freq.Values) {
    //         maxFreq = Math.Max(maxFreq, f);
    //     }

    //     var result = new List<int>();

    //     foreach (var f in freq) {
    //         if (f.Value == maxFreq) {
    //             result.Add(f.Key);
    //         }
    //     }

    //     return result.ToArray();
    // }

    // private void CountFrequencies(TreeNode node, Dictionary<int, int> freq) {
    //     if (node == null) return;

    //     freq[node.val] = freq.GetValueOrDefault(node.val, 0) + 1;
    //     CountFrequencies(node.left, freq);
    //     CountFrequencies(node.right, freq);
    // }

/*
Approach 1: Dictionary/HashMap Method

Initialize a dictionary to store frequency counts
Traverse the entire BST using any traversal method (DFS/BFS)
Count the frequency of each node value in the dictionary
Find the maximum frequency among all values
Collect all values that have the maximum frequency
Return the result as an array

Time Complexity: O(n) where n is the number of nodes
- O(n) for traversal + O(n) for finding max + O(n) for collecting results

Space Complexity: O(n)
- O(n) for dictionary storage + O(h) for recursion stack where h is tree height
*/

    private List<int> modes = new List<int>();
    private int currentVal = int.MinValue;
    private int currentCount = 0;
    private int maxCount = 0;

    public int[] FindMode(TreeNode root) {
        if (root == null) return new int[0];

        modes.Clear();
        currentVal = int.MinValue;
        currentCount = 0;
        maxCount = 0;

        InOrderTraversal(root);
        return modes.ToArray();
    }

    private void InOrderTraversal(TreeNode node) {
        if (node == null) return;

        InOrderTraversal(node.left);

        ProcessNode(node.val);

        InOrderTraversal(node.right);
    }

    private void ProcessNode(int val) {
        if (val == currentVal) {
            currentCount++;
        } else {
            currentVal = val;
            currentCount = 1;
        }

        if (currentCount > maxCount) {
            maxCount = currentCount;
            modes.Clear();
            modes.Add(val);
        } else if (currentCount == maxCount) {
            modes.Add(val);
        }
    }
}

/*
Approach 2: Optimized In-Order Traversal (BST Property)

Leverage BST property: In-order traversal gives sorted sequence
Track variables: previous node, current count, max count, and modes list
Perform in-order traversal recursively
Process each node: Compare with previous node to update count
Update modes: Add to result if count equals or exceeds max count
Return the collected modes

Time Complexity: O(n) where n is the number of nodes
- Single pass through all nodes

Space Complexity: O(h) where h is the height of the tree
- Only recursion stack space (excluding result array)
- In worst case (skewed tree): O(n)
- In best case (balanced tree): O(log n)
*/