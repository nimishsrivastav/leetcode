class Solution:
    def maxArea(self, height: List[int]) -> int:
        # initialize pointers and max_area
        left = 0
        right = len(height) - 1
        max_area = 0

        # loop until the two pointers meet
        while left < right:
            width = right - left                                # the width is the distance between the two pointers
            min_height = min(height[left], height[right])       # the height is the shorter of the two lines
            curr_area = width * min_height                      # calculate area and update max_area if needed

            if curr_area > max_area:
                max_area = curr_area

            # move the pointer pointing to the shorter line inward
            if height[left] < height[right]:
                left += 1
            else:
                right -= 1

        return max_area

##### ALGORITHM #####
# 1. Start pointers at both ends of the array.
# 2. Compute the area between the two pointers.
# 3. Update the maximum area.
# 4. Move the pointer that points to the shorter bar inward.
# 5. Repeat until the pointers meet.
#####################

# Time Complexity: O(n) — Each pointer moves at most n times.
# Space Complexity: O(1) — Only variables for pointers and max area.