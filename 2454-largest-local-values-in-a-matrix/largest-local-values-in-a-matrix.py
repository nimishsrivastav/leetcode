class Solution:
    def largestLocal(self, grid: List[List[int]]) -> List[List[int]]:
        n = len(grid)
        result = []

        # for each possible 3x3 submatrix position
        for i in range(n - 2):
            row = []

            for j in range(n - 2):
                # extract all values from the 3x3 submatrix and find max
                submatrix_values = []

                for r in range(i, i + 3):
                    for c in range(j, j + 3):
                        submatrix_values.append(grid[r][c])

                row.append(max(submatrix_values))
            result.append(row)

        return result