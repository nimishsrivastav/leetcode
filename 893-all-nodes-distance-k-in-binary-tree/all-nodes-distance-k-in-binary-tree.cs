/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        if (root == null || target == null || k < 0) return new List<int>();

        if (k == 0) return new List<int> { target.val };

        var parentMap = new Dictionary<TreeNode, TreeNode>();

        BuildParents(root, null, parentMap);

        var result = new List<int>();
        var queue = new Queue<TreeNode>();
        var visited = new HashSet<TreeNode>();

        queue.Enqueue(target);
        visited.Add(target);

        for (int level = 0; level < k; level++) {
            int size = queue.Count;

            for (int i = 0; i < size; i++) {
                var node = queue.Dequeue();

                var neighbors = new TreeNode[] { node.left, node.right, parentMap.ContainsKey(node) ? parentMap[node] : null };

                foreach (var n in neighbors) {
                    if (n != null && !visited.Contains(n)) {
                        visited.Add(n);
                        queue.Enqueue(n);
                    }
                }
            }
        }

        while (queue.Count > 0) {
            result.Add(queue.Dequeue().val);
        }

        return result;
    }

    private void BuildParents(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parentMap) {
        if (node == null) return;

        if (parent != null) parentMap[node] = parent;

        BuildParents(node.left, node, parentMap);
        BuildParents(node.right, node, parentMap);
    }
}

/*
    1. Convert binary tree to undirected graph using parent pointers
    2. Perform level-by-level BFS from target node for exactly K levels
    3. Collect all nodes reached after K levels

    Time: O(n), Space: O(n)
*/