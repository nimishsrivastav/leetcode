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
    public bool IsPalindrome(ListNode head) {
        // edge case
        if (head == null || head.next == null) return true;

        /*ListNode slow = head;
        ListNode fast = head;

        while (fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode secondHalf = ReverseList(slow.next);

        ListNode firstHalf = head;
        ListNode secondHalfCopy = secondHalf;

        bool isPalindrome = true;

        while (secondHalf != null) {
            if (firstHalf.val != secondHalf.val) {
                isPalindrome = false;
                break;
            }

            firstHalf = firstHalf.next;
            secondHalf = secondHalf.next;
        }

        slow.next = ReverseList(secondHalfCopy);

        return isPalindrome; */
        var nums = new List<int>();

        while (head != null) {
            nums.Add(head.val);
            head = head.next;
        }

        int l = 0, r = nums.Count - 1;

        while (l <= r) {
            if (nums[l] != nums[r]) return false;

            l++;
            r--;
        }

        return true;
    }

    private ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode current = head;

        while (current != null) {
            ListNode nextTemp = current.next;
            current.next = prev;
            prev = current;
            current = nextTemp;
        }

        return prev;
    }
}