class Solution:
    def compress(self, chars: List[str]) -> int:
        n = len(chars)
        write = 0           # pointer to place the compressed characters
        read = 0            # pointer to read through the array

        while read < n:
            curr_char = chars[read]
            count = 0

            # count the number of repeating characters
            while read < n and chars[read] == curr_char:
                read += 1
                count += 1

            # write the character
            chars[write] = curr_char
            write += 1

            # if count > 1, write each digit of the count
            if count > 1:
                for digit in str(count):
                    chars[write] = digit
                    write += 1

        # return the new length of the compressed array
        return write

##### ALGORITHM #####
# 1. Use a write pointer to indicate the position in the array to write compressed output.
# 2. Use a read pointer to iterate through chars.
# 3. For each group of consecutive repeating characters:
#     - Write the character.
#     - If the group size > 1, write each digit of the count as a separate character.
# 4. Return the final write position as the new length.
#####################

# Time Complexity: O(n); Each character is read and written at most once.
# Space Complexity: O(1); Uses constant extra space (in-place).