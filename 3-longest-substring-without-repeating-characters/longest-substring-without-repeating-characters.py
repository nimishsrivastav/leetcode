class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        last_seen = {}              # dictionary to store the last index of each character
        max_length = 0              # to keep track of the maximum window size
        left = 0                    # left pointer of the sliding window

        # iterate over the string with the right pointer
        for right, char in enumerate(s):
            # if the character was seen and is in the current window
            if char in last_seen and last_seen[char] >= left:
                # move left just after the last occurrence
                left = last_seen[char] + 1

            # update or insert the character's last seen index
            last_seen[char] = right
            # update the maximum length if this window is larger
            max_length = max(max_length, right - left + 1)

        return max_length

##### ALGORITHM #####
# 1. Use a dictionary to track the last index of each character seen.
# 2. Use two pointers:
#     - left (start of window)
#     - right (end of window, moves forward)
# 3. For each character at right:
#     - If it's already in the window (dict) and its index ≥ left, move left to dict[char] + 1 to skip the duplicate.
#     - Update or add the character's index in the dict.
#     - Update max_length if current window (right - left + 1) is larger.
# 4. Return max_length.
#####################

# Time Complexity: O(n) — Each character is visited at most twice.
# Space Complexity: O(k) — Where k is the charset size (at most 128 or 256).