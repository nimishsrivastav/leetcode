class Solution:
    def countSubstrings(self, s: str) -> int:
        n = len(s)
        count = 0

        # helper function to expand while valid and matching
        def expandAroundCenter(left: int, right: int):
            nonlocal count          # to update the count variable with our helper function

            while left >= 0 and right < len(s) and s[left] == s[right]:
                count += 1          # palindrome found
                left -= 1
                right += 1

        for i in range(n):
            expandAroundCenter(i, i)            # odd-length palindromes (centered at i)
            expandAroundCenter(i, i + 1)        # even-lemgth palindromes (centered between i and i+1)

        return count

##### ALGORITHM #####
# 1. For each character in s, treat it as the center of a palindrome and expand outwards for both odd and even length palindromes.
# 2. For each expansion, count a palindrome if the substring is valid (characters match).
# 3. Return the total count.
#####################

# Time Complexity: O(n^2) — For each center, expand up to n.
# Space Complexity: O(1) — No extra space, just counters and pointers.