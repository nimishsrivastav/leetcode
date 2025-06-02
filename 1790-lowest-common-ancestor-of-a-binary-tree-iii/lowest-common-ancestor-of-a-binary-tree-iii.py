"""
# Definition for a Node.
class Node:
    def __init__(self, val):
        self.val = val
        self.left = None
        self.right = None
        self.parent = None
"""

class Solution:
    def lowestCommonAncestor(self, p: 'Node', q: 'Node') -> 'Node':
        # two pointers starting at p and q
        a, b = p, q

        # traverse up until they meet
        while a != b:
            # if a reaches the root, restart from q
            a = a.parent if a else q
            # if b reaches the root, restart from p
            b = b.parent if b else p

        # while a == b, it is LCA
        return a

##### ALGORITHM #####
# 1. Start two pointers, one at p, one at q.
# 2. Move both up one step at a time (to their parent).
#     - If a pointer reaches the root (None), start it at the other node.
# 3. They will meet at the LCA (or both hit None if not in same tree).
#####################

# Time Complexity: O(h), where h = height of tree (worst case both nodes are leaves at deepest level).
# Space Complexity: O(1), no extra space, just pointers.