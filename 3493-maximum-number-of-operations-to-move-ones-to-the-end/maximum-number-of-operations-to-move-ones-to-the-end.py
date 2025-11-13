class Solution:
    def maxOperations(self, s: str) -> int:
        if len(s) <= 1:
            return 0

        operations = 0
        ones_count = 0

        # Traverse from left to right
        for i in range(len(s)):
            if s[i] == '1':
                ones_count += 1
            else: # s[i] == '0'
                # If there's a '1' before this '0', we can do operations
                # Check if next character exists and is not '0'
                if ones_count > 0 and (i == len(s) - 1 or s[i + 1] !='0'):
                    operations += ones_count

        return operations