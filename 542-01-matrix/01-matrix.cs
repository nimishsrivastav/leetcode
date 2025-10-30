public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        if (mat == null || mat.Length == 0 || mat[0].Length == 0) return mat;

        int m = mat.Length;
        int n = mat[0].Length;

        int[][] result = new int[m][];

        // for (int i = 0; i < m; i++) {
        //     result[i] = new int[n];
        // }

        Queue<(int row, int col)> queue = new Queue<(int, int)>();

        for (int i = 0; i < m; i++) {
            result[i] = new int[n];

            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 0) {
                    result[i][j] = 0;
                    queue.Enqueue((i, j));
                } else {
                    result[i][j] = int.MaxValue;
                }
            }
        }

        int[,] directions = {{1, 0}, {0, 1}, {-1, 0}, {0, -1}};

        while (queue.Count > 0) {
            var (row, col) = queue.Dequeue();

            for (int i = 0; i < 4; i++) {
                int dr = row + directions[i, 0];
                int dc = col + directions[i, 1];

                if (dr >= 0 && dr < m && dc >= 0 && dc < n) {
                    if (result[dr][dc] > result[row][col] + 1) {
                        result[dr][dc] = result[row][col] + 1;
                        queue.Enqueue((dr, dc));
                    }
                }
            }
        }

        return result;
    }
}