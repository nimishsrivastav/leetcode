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
    public ListNode Partition(ListNode head, int x) {
        // base case: empty list
        if (head == null) return null;

        // create two dummy nodes for two separate lists
        ListNode lessDummy = new ListNode(0);       // for nodes with val < x
        ListNode greaterDummy = new ListNode(0);    // for nodes with val > x

        // pointers to build the two lists
        ListNode less = lessDummy;
        ListNode greater = greaterDummy;

        // travers the original list
        ListNode current = head;

        while (current != null) {
            if (current.val < x) {
                // append to "less" list
                less.next = current;
                less = less.next;
            } else {
                // append to "greater" list
                greater.next = current;
                greater = greater.next;
            }

            current = current.next;
        }

        // set the last node's next to null to avoid cycle
        greater.next = null;

        // connect the two lists: less list -> greater list
        less.next = greaterDummy.next;

        // return the head of partitioned list (skip dummy node)
        return lessDummy.next;
    }
}

// time: O(n), space: O(1)