# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def findBottomLeftValue(self, root: Optional[TreeNode]) -> int:
        # edge case: if the root is None, return None
        if not root:
            return None

        # initialize a queue for BFS and start with the root node
        queue = deque([root])
        
        # variable to store the leftmost value of the last level
        leftmost_value = None

        # perform level-order traversal (BFS)
        while queue:
            # pop a node from the left of the queue
            node = queue.popleft()

            # update the leftmost_value with the current node's value
            # since we add right before left, the last node visited will be the leftmost node in the last level
            leftmost_value = node.val

            # add right child first so left child stays at the end of the queue
            # this ensures the leftmost node at the last level is processed last
            if node.right:
                queue.append(node.right)
            if node.left:
                queue.append(node.left)

        # return the leftmost value found at the last level
        return leftmost_value

# Time Complexity: O(n) where n is the number of nodes in the tree (each node visited once).
# Space Complexity: O(w) where w is the maximum width of the tree (worst case, for a full binary tree, w ≈ n/2).