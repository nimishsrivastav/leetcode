public class Solution {
    public bool IsPalindrome(string s) {
        /* Two-Pass */
        // var chars = s.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray();

        // int left = 0, right = chars.Length - 1;

        // while (left < right) {
        //     if (chars[left] != chars[right]) return false;
        //     left++;
        //     right--;
        // }

        // return true;
        /* Two-Pass */

        /* Two Pointers */
        int left = 0, right = s.Length - 1;

        while (left < right) {
            while (left < right && !char.IsLetterOrDigit(s[left])) left++;

            while (left < right && !char.IsLetterOrDigit(s[right])) right--;

            if (char.ToLower(s[left]) != char.ToLower(s[right])) return false;

            left++;
            right--;
        }

        return true;
        /* Two Pointers */
    }
}