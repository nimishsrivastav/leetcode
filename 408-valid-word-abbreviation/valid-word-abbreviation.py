class Solution:
    def validWordAbbreviation(self, word: str, abbr: str) -> bool:
        # pointers for word and abbrevation
        word_ptr, abbr_ptr = 0, 0

        while word_ptr < len(word) and abbr_ptr < len(abbr):
            # if characters match, move both pointers
            if word[word_ptr] == abbr[abbr_ptr]:
                word_ptr += 1
                abbr_ptr += 1
            # if current character in abbrevation is a digit
            elif abbr[abbr_ptr].isdigit():
                # check for leading zero (invalid abbrevation)
                if abbr[abbr_ptr] == '0':
                    return False

                # parse the complete number (could be multi-digit)
                num = 0

                while abbr_ptr < len(abbr) and abbr[abbr_ptr].isdigit():
                    num = num * 10 + int(abbr[abbr_ptr])
                    abbr_ptr += 1

                # skip 'num' characters in the word
                word_ptr += num
            else:
                # characters don't match and abbr[j] is not a digit
                return False

        # both pointers should reach the end of their strings
        return word_ptr == len(word) and abbr_ptr == len(abbr)

##### ALGORITHM #####
# 1. Use two pointers: one for word (word_ptr) and one for abbreviation (abbr_ptr)
# 2. Iterate through both strings simultaneously
# 3. If characters match, move both pointers forward
# 4. If current char in abbr is a digit:
#    - Parse the complete number (handle multi-digit numbers)
#    - Check for leading zeros (invalid)
#    - Skip corresponding characters in word based on the number
# 5. If characters don't match and current abbr char is not a digit, return False
# 6. Return True if both pointers reach the end of their respective strings
#####################

# Time Complexity: O(n + m) where n = len(word), m = len(abbr) - We traverse each string once
# Space Complexity: O(1) - Only using constant extra space for pointers and variables