public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int row, int col, int time)> queue = new Queue<(int, int, int)>();
        int freshCount = 0;
        
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 2) queue.Enqueue((i, j, 0));
                else if (grid[i][j] == 1) freshCount++;
            }
        }
        
        if (freshCount == 0) return 0;

        int[,] directions = {{1, 0}, {0, 1}, {-1, 0}, {0, -1}};
        
        int maxTime = 0;
        
        while (queue.Count > 0) {
            var (row, col, time) = queue.Dequeue();
            maxTime = Math.Max(maxTime, time);
            
            for (int d = 0; d < directions.GetLength(0); d++) {
                int dr = row + directions[d, 0];
                int dc = col + directions[d, 1];
                
                if (dr >= 0 && dr < rows && dc >= 0 && dc < cols && grid[dr][dc] == 1) {
                    grid[dr][dc] = 2;
                    freshCount--;
                    queue.Enqueue((dr, dc, time + 1));
                }
            }
        }
        
        return freshCount == 0 ? maxTime : -1;
    }
}