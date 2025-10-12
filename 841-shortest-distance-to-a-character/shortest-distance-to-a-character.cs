public class Solution {
    public int[] ShortestToChar(string s, char c) {
        int n = s.Length;
        int[] result = new int[n];

        int lastSeenPos = int.MinValue / 2;

        for (int i = 0; i < n; i++) {
            if (s[i] == c) lastSeenPos = i;

            result[i] = i - lastSeenPos;
        }

        lastSeenPos = int.MaxValue / 2;

        for (int i = n - 1; i >= 0; i--) {
            if (s[i] == c) lastSeenPos = i;

            result[i] = Math.Min(result[i], lastSeenPos - i);
        }

        return result;
    }
}