public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1) return new List<int> { 0 };
        if (n == 2) return new List<int> { 0, 1 };

        List<int>[] graph = new List<int>[n];
        int[] inDegree = new int[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var edge in edges) {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);

            inDegree[edge[0]]++;
            inDegree[edge[1]]++;
        }

        Queue<int> leaves = new Queue<int>();

        for (int i = 0; i < n; i++) {
            if (inDegree[i] == 1)
                leaves.Enqueue(i);
        }

        int remainingNodes = n;

        while (remainingNodes > 2) {
            int leavesCount = leaves.Count;
            remainingNodes -= leavesCount;

            for (int i = 0; i < leavesCount; i++) {
                int leaf = leaves.Dequeue();

                foreach (int neighbor in graph[leaf]) {
                    inDegree[neighbor]--;

                    if (inDegree[neighbor] == 1)
                        leaves.Enqueue(neighbor);
                }
            }
        }

        List<int> result = new List<int>();

        while (leaves.Count > 0)
            result.Add(leaves.Dequeue());

        return result;
    }
}