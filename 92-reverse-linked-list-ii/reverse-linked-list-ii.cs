/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        // edge case: if left == right, return the original list
        if (left == right) return head;

        // create a dummy node to handle edge case where left = 1
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        // step 1: find the node before the reversal start position
        ListNode prevLeft = dummy;

        for (int i = 0; i < left - 1; i++) {
            prevLeft = prevLeft.next;
        }

        // step 2: identify the start of reversal section
        ListNode current = prevLeft.next;

        // step 3: reverse the nodes between left and right positions
        for (int i = 0; i < (right - left); i++) {
            // store the next node to be moved
            ListNode nodeToMove = current.next;

            // remove nodeToMove right after prevLeft
            current.next = nodeToMove.next;

            // insert nodeToMove right after prevLeft
            nodeToMove.next = prevLeft.next;
            prevLeft.next = nodeToMove;
        }

        // return the head (skip dummy node)
        return dummy.next;
    }
}

/*
ALGORITHMIC STEPS:
1. Handle edge case: if left == right, return original list
2. Create dummy node pointing to head to handle left = 1 case
3. Find the node just before the left position (prevLeft)
4. Start from the left position node (current)
5. For each position from left to right-1:
   - Take the next node after current (nodeToMove)
   - Remove nodeToMove from its position
   - Insert nodeToMove right after prevLeft
   - This effectively moves nodes one by one to the front of the section
6. Return dummy.next as the new head

TIME COMPLEXITY: O(n)
- We traverse the list once to find the left position: O(left)
- We perform (right - left) reversals: O(right - left)
- Total: O(left + right - left) = O(right) ≤ O(n)

SPACE COMPLEXITY: O(1)
- Only using a constant number of pointers (dummy, prevLeft, current, nodeToMove)
- No additional data structures or recursion used
*/