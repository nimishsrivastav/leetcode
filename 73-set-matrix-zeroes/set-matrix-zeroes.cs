public class Solution {
    public void SetZeroes(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return;

        int m = matrix.Length;
        int n = matrix[0].Length;

        bool firstRowZeros = false;
        bool firstColZeros = false;

        // check first row for zeros
        for (int j = 0; j < n; j++) {
            if (matrix[0][j] == 0) {
                firstRowZeros = true;
                break;
            }
        }

        // check first col for zeros
        for (int i = 0; i < m; i++) {
            if (matrix[i][0] == 0) {
                firstColZeros = true;
                break;
            }
        }

        // Scan the matrix (excluding first row/column) and mark zeros
        for (int i = 1; i < m; i++) 
        {
            for (int j = 1; j < n; j++) 
            {
                if (matrix[i][j] == 0) 
                {
                    matrix[i][0] = 0;  // Mark row i should be zero
                    matrix[0][j] = 0;  // Mark column j should be zero
                }
            }
        }

        // Set zeros based on markers (excluding first row/column)
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                if (matrix[i][0] == 0 || matrix[0][j] == 0) {
                    matrix[i][j] = 0;
                }
            }
        }

        // Handle first row if it originally contained zeros
        if (firstRowZeros) {
            for (int j = 0; j < n; j++) {
                matrix[0][j] = 0;
            }
        }

        // Handle first column if it originally contained zeros
        if (firstColZeros) {
            for (int i = 0; i < m; i++) {
                matrix[i][0] = 0;
            }
        }
    }
}

/*
Algorithmic Steps:
1. First pass: Identify which rows and columns contain zeros
2. Use the first row and first column as markers to store this information
3. Handle edge cases for first row and first column separately
4. Second pass: Set zeros based on the markers
5. Finally handle the first row and first column if they originally contained zeros

Time Complexity: O(m × n) - We need to visit each cell at least once
Space Complexity: O(1) - Using the matrix itself for storage instead of extra arrays
*/