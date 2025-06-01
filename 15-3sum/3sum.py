class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        # n = len(nums)
        # result = set()                  # use a set to avoid duplicate triplets

        # for i in range(n):
        #     seen = set()                # set to find pairs (nums[j], nums[k]) such that nums[i] + nums[j] + nums[k] == 0

        #     for j in range(i + 1, n):
        #         complement = -nums[i] - nums[j]

        #         if complement in seen:
        #             triplet = tuple(sorted((nums[i], nums[j], complement)))
        #             result.add(triplet)
                
        #         seen.add(nums[j])

        # return [list(triplet) for triplet in result]

##### ALGORITHM #####
# Approach Without Sorting (Using HashSet for Two Sum)
# 1. Iterate over each element as the first number in the triplet.
# 2. For each i, use a set to find pairs (nums[j], nums[k]) such that nums[i] + nums[j] + nums[k] == 0.
# 3. Use another set to avoid duplicate triplets, since you can't rely on sorted order.
# 4. For every pair found, sort the triplet before adding to the result set to avoid duplicates with different orders.
#####################

# Time Complexity: O(n²); For each index i, the inner loop is O(n), checking for each possible j. The set operations are O(1) on average.
# Space Complexity: O(n²); The set may store up to O(n²) triplets in the worst case (though unique ones only).

## WITH SORTING ##

        nums.sort()                 # sort the array
        n = len(nums)
        result = []

        for i in range(n - 2):
            # skip duplicate number for i
            if i > 0 and nums[i] == nums[i - 1]:
                continue

            left, right = i + 1, n - 1

            while left < right:
                total = nums[i] + nums[left] + nums[right]

                if total == 0:
                    result.append([nums[i], nums[left], nums[right]])

                    # skip duplicate numbers for left and right
                    while left < right and nums[left] == nums[left + 1]:
                        left += 1
                    while left > right and nums[right] == nums[right - 1]:
                        right -= 1

                    left += 1
                    right -= 1
                elif total < 0:
                    left += 1
                else:
                    right -= 1
        
        return result

##### ALGORITHM #####
# 1. Sort the input array.
#     - This helps with both duplicate avoidance and the two-pointer approach.
# 2. Iterate with index i from 0 to n-3:
#     - If nums[i] is the same as the previous value, skip it (to avoid duplicate triplets).
#     - For each i, set two pointers: left = i + 1, right = n - 1.
#     - While left < right:
#         - Calculate total = nums[i] + nums[left] + nums[right].
#         - If total == 0, add [nums[i], nums[left], nums[right]] to the result.
#             - Move left and right to the next different values to avoid duplicates.
#         - If total < 0, increment left.
#         - If total > 0, decrement right.
# 3. Return all found triplets (no duplicates).
#####################

# Time Complexity: O(n²); Outer loop O(n), inner loop O(n) in the worst case. Sorting is O(n log n), but dominated by the double loop.
# Space Complexity: O(1) (ignoring the space for the output).