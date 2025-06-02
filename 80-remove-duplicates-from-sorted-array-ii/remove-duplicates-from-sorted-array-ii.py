class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        write = 0                   # write pointer for where to place next valid element

        # iterate through the array
        for num in nums:
            # if less than 2 elements written, always write
            # if num > nums[write -2], it means this is at most the second occurrence
            if write < 2 or num > nums[write - 2]:
                nums[write] = num               # write valid value
                write += 1                      # increment write pointer

        # the first 'write' elements are the answer
        return write

##### ALGORITHM #####
# 1. Use a write pointer to track where to write the next value.
# 2. Iterate through the nums array with a read pointer.
# 3. Only write the current value if it's:
#     - Among the first two elements,
#     - Or greater than the element nums[write - 2] (ensuring at most two of each value).
# 4. Return the new length (write).
#####################

# Time Complexity: O(n) — Each element is visited once.
# Space Complexity: O(1) — In-place, only pointers used.
