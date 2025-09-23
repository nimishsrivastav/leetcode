public class Solution {
    public int[][] Transpose(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int[][] transposedMatrix = new int[n][];

        for (int i = 0; i < n; i++) {
            transposedMatrix[i] = new int[m];

            for (int j = 0; j < m; j++) {
                transposedMatrix[i][j] = matrix[j][i];
            }
        }

        return transposedMatrix;
    }
}