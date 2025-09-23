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
    public ListNode RotateRight(ListNode head, int k) {
        // edge case
        if (head == null || head.next == null || k == 0) return head;

        // step 1: find the length of the list and get the tail
        ListNode tail = head;
        int length = 1;

        // traverse to find the length and tail node
        while (tail.next != null) {
            tail = tail.next;
            length++;
        }

        // step 2: make the list circular by connecting tail to head
        tail.next = head;

        // step 3: calculate effective rotations
        // if k > length, we only need k% length rotations
        k = k % length;

        // step 4: find the new tail
        // new tail is at position (length - k - 1) from original head
        ListNode newTail = head;

        // move to the new tail position
        for (int i = 0; i < (length - k - 1); i++) {
            newTail = newTail.next;
        }

        // step 5: set new head and break the circular connection
        ListNode newHead = newTail.next;
        newTail.next = null;

        return newHead;
    }
}

/*
    Algorithm Steps:
    1. Handle edge cases: empty list or k = 0
    2. Find the length of the list and make it circular
    3. Calculate effective rotations (k % length)
    4. Find the new tail (length - k - 1 steps from head)
    5. Set new head and break the circular connection
    
    Time Complexity: O(n) where n is the number of nodes
    Space Complexity: O(1) - only using constant extra space
*/