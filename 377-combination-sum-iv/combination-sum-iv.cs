public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        if (nums == null || nums.Length == 0) return 0;

        int[] dp = new int[target + 1];

        dp[0] = 1;

        for (int i = 1; i <= target; i++) {
            foreach (int num in nums) {
                if (num <= i) {
                    dp[i] += dp[i - num];
                }
            }
        }

        return dp[target];
    }
}