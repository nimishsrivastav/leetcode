public class Solution {
    public int CharacterReplacement(string s, int k) {
        if (string.IsNullOrEmpty(s)) return 0;

        int[] charCount = new int[26];

        int left = 0;
        int maxFreq = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++) {
            charCount[s[right] - 'A']++;

            maxFreq = Math.Max(maxFreq, charCount[s[right] - 'A']);

            int windowSize = right - left + 1;

            if (windowSize - maxFreq > k) {
                charCount[s[left] - 'A']--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}