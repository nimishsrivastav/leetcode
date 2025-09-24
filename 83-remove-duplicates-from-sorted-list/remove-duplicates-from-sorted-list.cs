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
    public ListNode DeleteDuplicates(ListNode head) {
        // edge case: empty list
        if (head == null) return null;

        ListNode current = head;

        // compare each node with its next node
        while (current != null && current.next != null) {
            if (current.val == current.next.val) {
                // skip the duplicate node
                current.next = current.next.next;
            } else {
                // move to next unique node
                current = current.next;
            }
        }

        return head;
    }
}

/*
Approach 1: Two-Pass with Extra Space
    - Collect all values → Remove duplicates → Rebuild list
    - Time: O(n), Space: O(n)

public ListNode DeleteDuplicates(ListNode head) {
        if (head == null) {
            return null;
        }

        var values = new List<int>();
        var current = head;

        while (current != null) {
            values.Add(current.val);
            current = current.next;
        }

        var distinctValues = values.Distinct().ToList();

        ListNode dummy = new ListNode(0);
        current = dummy;

        foreach (int val in distinctValues) {
            current.next = new ListNode(val);
            current = current.next;
        }

        return dummy.next;
    }


Approach 2: Single-Pass In-Place (Used here)
    - Compare current node with next node
    - If same value → skip the duplicate
    - If different → move to next
    - Time: O(n), Space: O(1)
*/