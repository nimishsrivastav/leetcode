class Solution:
    def trap(self, height: List[int]) -> int:
        # initialize two pointers and max heights
        left, right = 0, len(height) - 1
        left_max, right_max = 0, 0
        total_water = 0

        # traverse the array with two pointers
        while left < right:
            if height[left] < height[right]:
                # if current bar is higher than left_max, update left_max
                if height[left] >= left_max:
                    left_max = height[left]
                else:
                    # water trapped is left_max - height[left]
                    total_water += left_max - height[left]
                
                left += 1
            else:
                # if current bar is higher than right_max, update right_max
                if height[right] >= right_max:
                    right_max = height[right]
                else:
                    # water trapped is right_max - height[right]
                    total_water += right_max - height[right]
                
                right -= 1

        return total_water

##### ALGORITHM #####
# 1. Initialize two pointers left and right at the beginning and end of the array.
# 2. Track left_max and right_max, the highest bars seen so far from the left and right.
# 3. While left < right:
#     - If height[left] < height[right], process the left pointer:
#         - If height[left] >= left_max, update left_max.
#         - Else, water trapped at left is left_max - height[left].
#         - Move left pointer to the right.
#     - Else, process the right pointer:
#         - If height[right] >= right_max, update right_max.
#         - Else, water trapped at right is right_max - height[right].
#         - Move right pointer to the left.
# 4. Sum all water trapped and return the result.
#####################

# Time Complexity: O(n); Each pointer traverses the list at most once.
# Space Complexity: O(1); Only a few variables for pointers and maximums.