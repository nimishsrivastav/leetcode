public class Solution {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;

        // step 1: transpose the matrix
        // swap elements across the main diagonal
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                // swap matirx[i][j] with matrix[j][i]
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }

        // step 2: reverse the matrix
        for (int i = 0; i < n; i++) {
            int left = 0, right = n - 1;

            // use two-pointers to reverse the current row
            while (left < right) {
                int temp = matrix[i][left];
                matrix[i][left] = matrix[i][right];
                matrix[i][right] = temp;

                left++;
                right--;
            }
        }
    }
}