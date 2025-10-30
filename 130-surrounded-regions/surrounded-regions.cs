public class Solution {
    public void Solve(char[][] board) {
        if (board == null || board.Length == 0 || board[0].Length == 0) return;

        int rows = board.Length;
        int cols = board[0].Length;

        for (int col = 0; col < cols; col++) {
            if (board[0][col] == 'O') DFS(board, 0, col);
            if (board[rows - 1][col] == 'O') DFS(board, rows - 1, col);
        }

        for (int row = 0; row < rows; row++) {
            if (board[row][0] == 'O') DFS(board, row, 0);
            if (board[row][cols - 1] == 'O') DFS(board, row, cols - 1);
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (board[i][j] == 'O') board[i][j] = 'X';
                else if (board[i][j] == 'T') board[i][j] = 'O';
            }
        }
    }

    private void DFS(char[][] board, int row, int col) {
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] != 'O') return;

        board[row][col] = 'T';

        int[,] directions = {{1, 0}, {0, 1}, {-1, 0}, {0, -1}};

        for (int d = 0; d < directions.GetLength(0); d++) {
            int dr = row + directions[d, 0];
            int dc = col + directions[d, 1];

            DFS(board, dr, dc);
        }
    }
}