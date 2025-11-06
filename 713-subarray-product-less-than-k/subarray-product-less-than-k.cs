public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        // edge case: if k <= 1, no +ve product can be strictly less than k
        if (k <= 1) return 0;

        // edge case: empty array
        if (nums == null || nums.Length == 0) return 0;

        int count = 0;      // total count of valid subarrays
        int product = 1;    // current window product
        int left = 0;       // left pointer of sliding window

        // expand window with right pointer
        for (int right = 0; right < nums.Length; right++) {
            // include current element in the window
            product *= nums[right];

            // shrink window from left while product >= k
            while (product >= k) {
                product /= nums[left];      // remove leftmost element
                left++;                     // move left pointer
            }

            // all subarrays ending at 'right' with start from 'left' to 'right' are valid
            // total = right - left + 1
            count += (right - left + 1);
        }

        return count;
    }
}

// time: O(n), space: O(1)