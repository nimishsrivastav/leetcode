public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) return 0;
        if (coins == null || coins.Length == 0) return -1;

        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);

        dp[0] = 0;

        for (int i = 1; i <= amount; i++) {
            foreach (int coin in coins) {
                if (coin <= i) {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }
}