public class Solution {

    private bool IsVowel(char c) {
        return c == 'a' || c == 'A' || c == 'e' || c == 'E' || c == 'i' || c == 'I' || c == 'o' || c == 'O' || c == 'u' || c == 'U';
    }

    public int MaxVowels(string s, int k) {
        if (string.IsNullOrEmpty(s)) return 0;

        int currentVowelCount = 0;

        for (int i = 0; i < k; i++) {
            if (IsVowel(s[i]))
                currentVowelCount++;
        }

        int maxVowelCount = currentVowelCount;

        for (int i = k; i < s.Length; i++) {
            if (IsVowel(s[i - k]))
                currentVowelCount--;

            if (IsVowel(s[i]))
                currentVowelCount++;

            maxVowelCount = Math.Max(maxVowelCount, currentVowelCount);
        }

        return maxVowelCount;
    }
}