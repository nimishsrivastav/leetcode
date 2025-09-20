public class Solution {
    public bool IsMatch(string s, string p) {
        int m = s.Length;
        int n = p.Length;

        // dp[i][j] represents if s[0...i-1] matches p[0...j-1]
        bool[,] dp = new bool[m + 1, n + 1];

        // Base case: empty string matches empty pattern
        dp[0, 0] = true;

        // Handle patterns like a*, a*b*, a*b*c* which can match empty string
        for (int j = 1; j <= n; j++) {
            if (p[j - 1] == '*') {
                dp[0, j] = dp[0, j - 1];
            }
        }

        // Fill the DP table
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                char sChar = s[i - 1];
                char pChar = p[j - 1];

                if (pChar == '*') {
                    // '*' can match:
                    // 1. Empty sequence: dp[i][j-1]
                    // 2. One or more characters: dp[i-1][j]
                    // 3. Current character: dp[i-1][j-1]
                    dp[i, j] = dp[i, j - 1] || dp[i - 1, j] || dp[i - 1, j - 1];
                }
                else if (pChar == '?' || pChar == sChar) {
                    // '?' matches any single character, or exact character match
                    dp[i, j] = dp[i - 1, j - 1];
                }
                // If characters don't match and pattern is not wildcard, dp[i,j] remains false
            }
        }

        return dp[m, n];
    }
}