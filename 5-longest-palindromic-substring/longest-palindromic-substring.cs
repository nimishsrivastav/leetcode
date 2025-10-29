public class Solution {
    public string LongestPalindrome(string s) {
        if (string.IsNullOrEmpty(s) || s.Length == 1) return s;
        // if (s.Length == 1) return s;

        int start = 0, maxLen = 0;

        for (int i = 0; i < s.Length; i++) {
            int odd = ExpandAroundCenter(s, i, i);
            int even = ExpandAroundCenter(s, i, i + 1);

            int len = Math.Max(odd, even);

            if (len > maxLen) {
                maxLen = len;
                start = i - (len - 1) / 2;
            }
        }

        return s.Substring(start, maxLen);
    }

    private int ExpandAroundCenter(string s, int left, int right) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }

        return right - left - 1;
    }
}