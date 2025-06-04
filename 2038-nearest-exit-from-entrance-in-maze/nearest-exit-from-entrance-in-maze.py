class Solution:
    def nearestExit(self, maze: List[List[str]], entrance: List[int]) -> int:
        rows, cols = len(maze), len(maze[0])
        start_row, start_col = entrance

        # directions: up, down, left, right
        directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]

        # helper function to tell if (r, c) is on the boundary (possible exit)
        def is_border(r:int, c:int) -> bool:
            return r == 0 or r == rows - 1 or c == 0 or c == cols - 1

        # initialize BFS queue and mark the entrance as visited by converting it to a wall ("+")
        queue = deque()
        queue.append((start_row, start_col, 0))         # (row, col, distance covered)
        maze[start_row][start_col] = "+"                # prevent revisiting the entrance

        while queue:
            r, c, dist = queue.popleft()

            # try all 4 directions from (r, c)
            for dr, dc in directions:
                nr, nc = r + dr, c + dc

                # 1. check bounds
                if not (0 <= nr < rows and 0 <= nc < cols):
                    continue

                # 2. if it's a wall ("+"), skip it
                if maze[nr][nc] == "+":
                    continue

                # 3. at this point, (nr, nc) is an empty cell (".") that we haven't visited yet.
                # check if it is a BORDER exit (but not the entrance)
                if is_border(nr, nc):
                    # since we already marked the entrance as "+", any border "." we see here cannot 
                    # be the entrance itself. we have found the nearest exit.
                    return dist + 1

                # 4. otherwise, enqueue (nr, nc) for further BFS, marking it visited
                maze[nr][nc] = "+"              # mark visited by turning it into a wall
                queue.append((nr, nc, dist + 1))

        # if we exhaust the BFS without finding any border exit
        return -1

##### ALGORITHM #####
#1. Mark the Entrance Visited
#    - We immediately overwrite maze[start_r][start_c] with "+" so that we don’t revisit the entrance cell during BFS.
#2. BFS Initialization
#    - We push (start_r, start_c, 0) into our queue, where the third element 0 denotes the distance (number of steps) from the entrance to itself.
#3. Exploring Neighbors
#    - In each iteration of the BFS loop:
#    - We pop (r, c, dist) from the queue.
#    - We look in all four directions (up, down, left, right).
#    - For each neighbor (nr, nc):
#    - Bounds Check: If (nr, nc) is outside the grid, skip it.
#    - Wall Check: If maze[nr][nc] == "+", skip it (either originally a wall or we’ve visited it already).
#    - Border Check: If (nr, nc) is on the outer boundary of the grid and it is “.”, we have found an exit. We return dist + 1 immediately, because moving from (r, c) to (nr, nc) is one more step.
#    - Enqueue for Later: Otherwise, it’s an interior empty cell not yet visited. We mark it visited by setting maze[nr][nc] = "+", then enqueue (nr, nc, dist + 1).
#4. No Exit Found
#    - If the queue becomes empty and we never returned a distance, it means there was no reachable empty boundary cell. We return -1.
#####################

# Time Complexity: O(m x n); m=rows, n=columns; We visit each cell at most once, and for each cell, we try up to 4 directions
# Space Complexity: O(m x n); m=rows, n=columns; The queue can hold up to O(m x n) cells in the worst case (if the maze is all empty “.”). We also modify the input grid in-place to mark visited cells, so we do not use extra O(m x n) storage beyond the BFS queue. Thus, auxiliary space is O(m x n) in the worst case.