public class Solution {
    public int UniquePaths(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        const int MOD = 1000000007;
        
        // Memoization: dp[row, col, direction]
        // direction: 0 = right, 1 = down
        // -1 = not computed, otherwise = number of paths
        int[,,] dp = new int[m, n, 2];
        
        // Initialize all values to -1 (not computed)
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                dp[i, j, 0] = -1;
                dp[i, j, 1] = -1;
            }
        }
        
        return DFS(grid, 0, 0, 0, dp, m, n, MOD);
    }

    private int DFS(int[][] grid, int row, int col, int direction, int[,,] dp, int m, int n, int MOD) {
        // Base case: reached destination
        if (row == m - 1 && col == n - 1) {
            return 1;
        }
        
        // Base case: out of bounds
        if (row >= m || col >= n) {
            return 0;
        }
        
        // Return memoized result if already computed
        if (dp[row, col, direction] != -1) {
            return dp[row, col, direction];
        }
        
        long paths = 0;
        
        // Check current cell value
        if (grid[row][col] == 1) {
            // Current cell is a mirror - robot is reflected
            if (direction == 0) {
                // Was moving right, now forced to go down
                paths = DFS(grid, row + 1, col, 1, dp, m, n, MOD);
            } else {
                // Was moving down, now forced to go right
                paths = DFS(grid, row, col + 1, 0, dp, m, n, MOD);
            }
        } else {
            // Current cell is empty - robot can go both directions
            // Try going down
            paths += DFS(grid, row + 1, col, 1, dp, m, n, MOD);
            // Try going right
            paths += DFS(grid, row, col + 1, 0, dp, m, n, MOD);
        }
        
        // Store result with modulo
        paths %= MOD;
        dp[row, col, direction] = (int)paths;
        
        return dp[row, col, direction];
    }
}