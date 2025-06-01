class Solution:
    def reorganizeString(self, s: str) -> str:
        # count the frequency of each character
        freq = Counter(s)
        n = len(s)

        # if any character occurs more than (n+1) // 2 times, it's impossible
        if any(count > (n + 1) // 2 for count in freq.values()):
            return ""

        # sorted characters by frequency (most frequent first)
        sorted_chars = sorted(freq.items(), key=lambda x: -x[1])

        result = [''] * n
        index = 0
        
        # place characters in result array
        for char, count in sorted_chars:
            for _ in range(count):
                result[index] = char
                index += 2

                if index >= n:
                    index = 1               # switch to odd indices after filling even

        return ''.join(result)

##### ALGORITHM #####
# 1. Count frequency of each character.
# 2. Check feasibility: If any character occurs more than (n + 1) // 2 times, return "".
# 3. Sort characters by frequency.
# 4. Fill the result array:
#     - Place the most frequent character at even indices (0, 2, 4, ...).
#     - When even indices run out, fill odd indices (1, 3, 5, ...).
# 5. Return the joined array as a string.
#####################

# Time Complexity: O(n)
#    - Counting: O(n)
#    - Sorting: O(k log k) where k ≤ 26 (effectively constant for lowercase letters)
#    - Filling array: O(n)
# Space Complexity: O(n) (for result array and frequency table)