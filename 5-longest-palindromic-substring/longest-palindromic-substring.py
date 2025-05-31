class Solution:
    def longestPalindrome(self, s: str) -> str:
        # helper function to expand from the center and return the longest palindrome
        def expandAroundCenter(left: int, right: int) -> str:
            while left >= 0 and right < len(s) and s[left] == s[right]:
                left -= 1
                right += 1

            # substring after expanding (non-inclusive of the breaking indices)
            return s[left + 1:right]

        longest = ""            # store the longest palindrome

        for i in range(len(s)):
            # odd length palindrome (centered at i)
            odd_palindrome = expandAroundCenter(i, i)
            # even length palindrome (centered between i and i + 1)
            even_palindrome = expandAroundCenter(i, i + 1)

            # update longest if we find a longer palindrome
            if len(odd_palindrome) > len(longest):
                longest = odd_palindrome
            if len(even_palindrome) > len(longest):
                longest = even_palindrome

        return longest

##### ALGORITHM #####
# Expand Around Center (or two pointer technique)
# 1. For each character in the string, consider it as the center of a palindrome (odd length).
# 2. Also, consider the space between each pair of characters as the center (even length).
# 3. Expand outward from the center as long as the substring is a palindrome.
# 4. Keep track of the longest palindrome found during this process.
# 5. Return the longest palindromic substring.
#####################

# Time Complexity: O(n²); For each center (2n-1 centers), we expand outwards up to O(n) in the worst case.
# Space Complexity: O(1); Only a few variables for pointers and the result string (not counting output).