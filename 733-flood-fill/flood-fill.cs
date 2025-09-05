public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        int originalColor = image[sr][sc];

        if (originalColor == color) return image;

        DFS(image, sr, sc, originalColor, color);

        return image;
    }

    private void DFS(int[][] image, int row, int col, int originalColor, int newColor) {
        if (row < 0 || row >= image.Length || col < 0 || col >= image[0].Length || image[row][col] != originalColor) return;

        image[row][col] = newColor;

        int[,] directions = { {1, 0}, {0, 1}, {-1, 0}, {0, -1} };

        for (int i = 0; i < 4; i++) {
            int dr = row + directions[i, 0];
            int dc = col + directions[i, 1];

            DFS(image, dr, dc, originalColor, newColor);
        }
    }
}