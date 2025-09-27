public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int islandCount = 0;

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (grid[row][col] == '1') {
                    islandCount++;
                    DFS(grid, row, col);
                }
            }
        }

        return islandCount;
    }

    private void DFS(char[][] grid, int row, int col) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == '0') return;

        grid[row][col] = '0';

        int[,] directions = {{-1, 0}, {1, 0}, {0, -1}, {0, 1}};

        for (int d = 0; d < directions.GetLength(0); d++) {
            int dr = row + directions[d, 0];
            int dc = col + directions[d, 1];

            DFS(grid, dr, dc);
        }
    }
}