class Solution:
    def floodFill(self, image: List[List[int]], sr: int, sc: int, color: int) -> List[List[int]]:
        # early return if the starting pixel is already has the target color
        if image[sr][sc] == color:
            return image

        # store original color that we need to replace
        org_color = image[sr][sc]

        # get dimensions of the image
        rows, cols = len(image), len(image[0])

        directions = [(1, 0), (-1, 0), (0, 1), (0, -1)]

        def dfs(row, col):
            # base case: check bounds and color match
            if (row < 0 or row >= rows or 
                col < 0 or col >= cols or
                image[row][col] != org_color):
                return

            # change the color of current pixel
            image[row][col] = color

            # recursively fill all 4-directionally adjacent pixels
            for dr, dc in directions:
                dfs(row + dr, col + dc)

        # start DFS from the given starting position
        dfs(sr, sc)

        return image

"""
Algorithmic Steps:
1. Check if the starting pixel already has the target color (early return to avoid infinite loop)
2. Store the original color of the starting pixel
3. Use DFS (Depth-First Search) to traverse all connected pixels with the same original color
4. For each valid pixel, change its color and recursively process its 4-directional neighbors
5. Return the modified image

Time Complexity: O(m * n) where m = number of rows, n = number of columns
- In worst case, we might visit every pixel in the image once

Space Complexity: O(m * n) in worst case due to recursion stack
- The recursion depth can go up to m * n in case of a completely connected region
"""