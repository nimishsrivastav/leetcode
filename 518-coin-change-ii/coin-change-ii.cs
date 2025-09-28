public class Solution {
    public int Change(int amount, int[] coins) {
        if (amount == 0) return 1;
        if (coins == null || coins.Length == 0) return 0;

        int[] dp = new int[amount + 1];
        dp[0] = 1;

        foreach (int coin in coins) {
            for (int i = coin; i <= amount; i++) {
                dp[i] += dp[i - coin];
            }
        }

        return dp[amount];
    }
}