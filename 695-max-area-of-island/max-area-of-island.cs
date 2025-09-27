public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int maxArea = 0;

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (grid[row][col] == 1) {
                    int currentArea = DFS(grid, row, col);
                    maxArea = Math.Max(currentArea, maxArea);
                }
            }
        }

        return maxArea;
    }

    private int DFS(int[][] grid, int row, int col) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == 0) return 0;

        grid[row][col] = 0;
        int area = 1;

        int[,] directions = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};

        for (int d = 0; d < directions.GetLength(0); d++) {
            int dr = row + directions[d, 0];
            int dc = col + directions[d, 1];

            area += DFS(grid, dr, dc);
        }

        return area;
    }
}