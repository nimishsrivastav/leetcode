public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length) return -1;

        for (int i = 0; i <= haystack.Length - needle.Length; i++) {
            int j = 0;

            while (j < needle.Length && haystack[i + j] == needle[j]) j++;

            if (j == needle.Length) return i;
        }

        return -1;
    }
}

/*
ALGORITHMIC STEPS:
1. Check if needle is longer than haystack - return -1
2. Iterate through haystack positions where needle could fit
3. For each position, compare needle with substring
4. Return index if match found, otherwise -1

TIME COMPLEXITY: O(n * m) - n = haystack length, m = needle length
SPACE COMPLEXITY: O(1) - constant extra space
*/