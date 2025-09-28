public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        int maxSum = nums[0];
        int curr_sum = 0;

        for (int i = 0; i < nums.Length; i++) {
            curr_sum += nums[i];
            maxSum = Math.Max(maxSum, curr_sum);

            if (curr_sum < 0) curr_sum = 0;
        }

        return maxSum;
    }
}