public class Solution {
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        int n = s.Length;

        // base case: null or empty string
        if (n == 0 || pairs.Count == 0) return s;

        // step 1: build the adjacency list
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        // add all edges from pairs
        foreach (var pair in pairs) {
            graph[pair[0]].Add(pair[1]);
            graph[pair[1]].Add(pair[0]);
        }

        // initialize tracking variables
        bool[] visited = new bool[n];
        char[] result = new char[n];

        // find each connected component
        for (int i = 0; i < n; i++) {
            // if not yet processed
            if (!visited[i]) {
                // list to collect all indices and chars in this component
                var chars = new List<char>();
                var indices = new List<int>();

                // DFS to find all connected indices
                DFS(s, i, graph, visited, chars, indices);

                chars.Sort();       // sort characters lexicographically
                indices.Sort();     // sort indices numerically

                // place smallest char at smallest index
                for (int j = 0; j < chars.Count; j++)
                    result[indices[j]] = chars[j];
            }
        }

        // return the smallest string by converting char[] to string
        string smallestString = new string(result);

        return smallestString;
    }

    private void DFS(string s, int node, List<int>[] graph, bool[] visited, List<char> chars, List<int> indices) {
        // mark this node as visited
        visited[node] = true;

        // collect the characters and indices
        chars.Add(s[node]);
        indices.Add(node);

        // explore all neighbors
        foreach (int neighbor in graph[node]) {
            if (!visited[neighbor])
                DFS(s, neighbor, graph, visited, chars, indices);
        }
    }
}

// Time: O(E + VlogV), Space: O(E + V)