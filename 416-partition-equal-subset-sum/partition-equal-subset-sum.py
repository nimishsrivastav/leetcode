class Solution:
    def canPartition(self, nums: List[int]) -> bool:
        # calculate total sum
        total_sum = sum(nums)

        # if sum is odd, we can't partition into two equal subsets
        if total_sum % 2 == 1:
            return False

        # target sum for each subset
        target = total_sum // 2

        # dp array to track achieveable sums
        # dp[i] = True if sum i can be achieved using subset of numbers
        dp = [False] * (target + 1)
        # base case: sum 0 is always achieveable
        dp[0] = True

        # process each number in the array
        for num in nums:
            # traverse backwards to avoid using same number multiple times
            # we go backwards because we're updating dp based on previous state
            for j in range(target, num - 1, -1):
                # if we can make sum (j - num), then we can make sum j by adding num
                dp[j] = dp[j] or dp[j - num]

        # return whether target sum is achieveable
        return dp[target]

##### ALGORITHM #####
# 1. Calculate total sum of array
# 2. If total sum is odd, return False (can't partition into equal halves)
# 3. Set target = total_sum // 2
# 4. Use DP to check if we can achieve target sum using subset of numbers
# 5. Create boolean DP array where dp[i] represents if sum i is achievable
# 6. Initialize dp[0] = True (sum 0 is always achievable with empty subset)
# 7. For each number, update DP array backwards to avoid using same number twice
# 8. Return dp[target]
#####################

# Time Complexity: O(n * sum) where n is length of nums and sum is total sum
# Space Complexity: O(sum) for the DP array
