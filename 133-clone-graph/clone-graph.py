"""
# Definition for a Node.
class Node:
    def __init__(self, val = 0, neighbors = None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []
"""

from typing import Optional
class Solution:
    def cloneGraph(self, node: Optional['Node']) -> Optional['Node']:
        # if graph is empty
        if not node:
            return None

        visited = {}            # dictionary to store original -> clone mapping

        def dfs(node):
            # if node already cloned, return the clone
            if node in visited:
                return visited[node]

            # create clone of current node
            clone = Node(node.val, [])
            visited[node] = clone

            # clone all neighbors recursively
            for neighbor in node.neighbors:
                clone.neighbors.append(dfs(neighbor))

            return clone

        return dfs(node)


##### ALGORITHM #####
# 1. Create a visited dictionary to store cloned nodes
# 2. Define recursive DFS helper function:
#     - If node already visited, return its clone
#     - Create clone of current node and mark as visited
#     - Recursively clone all neighbors and add to clone's neighbors list
# 3. Call DFS helper on input node and return result
#####################

# Time Complexity: O(V + E)
# Space Complexity: O(V) - visited dict + recursion stack depth O(V)