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