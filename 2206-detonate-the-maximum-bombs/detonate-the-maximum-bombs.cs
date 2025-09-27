public class Solution {
    public int MaximumDetonation(int[][] bombs) {
        if (bombs == null || bombs.Length == 0) return 0;

        int n = bombs.Length;

        var graph = new List<int>[n];

        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < n; i++) {
            long x1 = bombs[i][0], y1 = bombs[i][1], r1 = bombs[i][2];

            for (int j = 0; j < n; j++) {
                if (i == j) continue;

                long x2 = bombs[j][0], y2 = bombs[j][1];

                long distSquared = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
                long radiusSquared = r1 * r1;

                if (distSquared <= radiusSquared) {
                    graph[i].Add(j);
                }
            }
        }

        int maxBombs = 0;

        for (int i = 0; i < n; i++) {
            bool[] visited = new bool[n];
            int count = DFS(i, graph, visited);
            maxBombs = Math.Max(maxBombs, count);
        }

        return maxBombs;
    }

    private int DFS(int bomb, List<int>[] graph, bool[] visited) {
        visited[bomb] = true;
        int count = 1;

        foreach (int nextBomb in graph[bomb]) {
            if (!visited[nextBomb]) {
                count += DFS(nextBomb, graph, visited);
            }
        }
        
            return count;
    }
}