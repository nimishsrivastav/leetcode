class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        # edge case: if amount=0, no coind needed
        if amount == 0:
            return 0

        # edge case: if no coins available, but amount >0
        if not coins:
            return -1

        # DP array: dp[i] represents minimum coins needed to make amount i
        dp = [amount + 1] * (amount + 1)

        # base case: 0 coins needed to make amount 0
        dp[0] = 0

        # fill dp table for each amount from 1 to target
        for curr_amount in range(1, amount + 1):
            # try each coin denomination
            for coin in coins:
                # if coin value is not greater than current amount
                if coin <= curr_amount:
                    # update minimum coins needed
                    dp[curr_amount] = min(dp[curr_amount], dp[curr_amount - coin] + 1)

        return dp[amount] if dp[amount] != amount + 1 else -1

##### ALGORITHM #####
# 1. Create a DP array where dp[i] represents the minimum coins needed for amount i
# 2. Initialize dp[0] = 0 (0 coins needed for amount 0)
# 3. Initialize all other dp values to infinity (impossible initially)
# 4. For each amount from 1 to target amount:
#    - For each coin denomination:
#      - If coin <= current amount, try using this coin
#      - Update dp[amount] = min(dp[amount], dp[amount - coin] + 1)
# 5. Return dp[amount] if it's not infinity, otherwise return -1
#####################

# Time Complexity: O(amount * len(coins)) - for each amount, we check each coin
# Space Complexity: O(amount) - DP array of size amount + 1