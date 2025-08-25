public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        // edge case handling - return empty array for null/empty input
        if (mat == null || mat.Length == 0) {
            return new int[0];
        }

        int N = mat.Length;         // number of rows
        int M = mat[0].Length;      // number of cols
        
        int row = 0, col = 0;       // current position
        int direction = 1;          // 1 = up-right; 0 = down-left

        int[] result = new int[N * M];          // result array
        int r = 0;                              // result index counter

        // continue until we're processed all elements
        while (row < N && col < M) {
            // add current element to result
            result[r++] = mat[row][col];

            // calculate next diagonal position
            int new_row = row + (direction == 1 ? -1 : 1);          // up-right: row-- ; down-left: row++
            int new_col = col + (direction == 1 ? 1 : -1);          // up-right: col++ ; down-left: col--

            // check if next position is out of bounds
            if (new_row < 0 || new_row == N || new_col < 0 || new_col == M) {
                // hit boundary - need to find next diagonal start

                if (direction == 1) {       // if going up-right
                    // if at rightmost column (col == M-1): move down (row++)
                    // otherwise: move right (col++)
                    row += (col == M - 1 ? 1 : 0);
                    col += (col < M - 1 ? 1 : 0);
                } else {        // if going down-left
                    // if at bottom row (row == N-1): move right (col++)
                    // otherwise: move down (row++)
                    col += (row == N - 1 ? 1 : 0);
                    row += (row < N - 1 ? 1 : 0);
                }

                direction = 1 - direction;      // direction toggle: 1 - direction flips between 1 and 0
            } else {
                // continue in same direction
                row = new_row;
                col = new_col;
            }
        }

        return result;
    }
}


/* 
* Algorithm:
* 1. Use while loop instead of for loop for more natural boundary handling
* 2. Calculate next position and check bounds in one step
* 3. Use clever ternary operators for boundary transitions
* 4. Toggle direction using arithmetic instead of multiplication
* 
* Time Complexity: O(N * M) - visits each element exactly once
* Space Complexity: O(1) - constant extra space (excluding output array)
*/