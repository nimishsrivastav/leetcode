public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;

        // step 1: place each number at its correct position
        // number x should be at index x - 1
        for (int i = 0; i < n; i++) {
            // keep swapping until current position has correct number or the number is out of valid range[1, n]
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i]) {
                // swap nums[i] with nums[nums[i] - 1]
                int correctIndex = nums[i] - 1;
                int temp = nums[i];

                nums[i] = nums[correctIndex];
                nums[correctIndex] = temp;
            }
        }

        // step 2: find the first position where number doesn't match index + 1
        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1)
                return i + 1;       // return the missing positive
        }

        // step 3: if all positions 1 to n are filled, return n + 1
        return n + 1;
    }
}

// time: O(n), space: O(1)