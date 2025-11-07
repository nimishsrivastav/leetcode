public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;

        // step 1: replace negative numbers and zeros with n+1
        // (values > n are irrelevant since answer is at most n+1)
        for (int i = 0; i < n; i++) {
            if (nums[i] <= 0)
                nums[i] = n + 1;
        }

        // step 2: mark presence of numbers by making value at index negative
        for (int i = 0; i < n; i++) {
            int num = Math.Abs(nums[i]);

            // if num is in range [1,n], mark index num-1
            if (num <= n)
                nums[num - 1] = -Math.Abs(nums[num - 1]);
        }

        // step 3: find first positive value (unmarked index)
        for (int i = 0; i < n; i++) {
            if (nums[i] > 0)
                return i + 1;
        }

        // if all positions are marked, answer is n+1
        return n + 1;
    }
}