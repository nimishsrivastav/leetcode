class Solution:
    def snakesAndLadders(self, board: List[List[int]]) -> int:
        n = len(board)

        # convert the 2D board into a 1D array in Boutstrophedon (zig-zag) order
        def get_board_index():
            arr = [-1] * (n * n)                    # 1D representation of the board
            index = 0
            left_to_right = True                    # direction toggle for each row

            for row in range(n - 1, -1, -1):        # start from the bottom row
                cols = range(n) if left_to_right else range(n - 1, -1, -1)

                for col in cols:
                    arr[index] = board[row][col]
                    index += 1
                
                left_to_right = not left_to_right   # alternate direction

            return arr

        flat_board = get_board_index()              # get 1D version of board
        visited = [False] * (n * n)                 # to avoid revisiting squares

        # start BFS from square 1 (index=0 in 1D array)
        queue = deque([(0, 0)])                     # (curr_position, number_of_moves)
        visited[0] = True

        while queue:
            pos, moves = queue.popleft()            # current position and moves taken

            # try all dice roll outcomes (1 through 6)
            for dice in range(1, 7):
                next_pos = pos + dice               # candidate next position

                if next_pos >= n * n:
                    continue                        # skip if it goes beyond board

                # if there's a snake or ladder, go to its destination
                dest = flat_board[next_pos] - 1 if flat_board[next_pos] != -1 else next_pos

                # if we've reached the last square, return move count + 1
                if dest == n * n - 1:
                    return moves + 1

                # enqueue if not visited
                if not visited[dest]:
                    visited[dest] = True
                    queue.append((dest, moves + 1))

        # if end is not reachable
        return -1

##### ALGORITHM STEPS #####
# 1. Flatten the 2D board into 1D, left-to-right for one row and then right-to-left for another, etc.
# 2. BFS traversal:
#       - Treat each square as a node in a graph
#       - Use BFS to find the shortest number of moves (minimum doce rolls)
# 3. Edge case handling:
#       - If it is not posible to reach the final square, return -1
###########################

# Time Complexity: O(n^2); Each cell is visited at most once, and for each cell, we consider up to 6 neighbors.
# Space Complexity: O(n^2); Due to the visited array and queue storing up to n^2 elements.