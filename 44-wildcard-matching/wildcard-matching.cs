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

/*
ALGORITHMIC STEPS:
1. Use dynamic programming with 2D array dp[i][j] representing if s[0...i-1] matches p[0...j-1]
2. Initialize base cases:
   - dp[0][0] = true (empty string matches empty pattern)
   - dp[i][0] = false for i > 0 (non-empty string cannot match empty pattern)
   - dp[0][j] = dp[0][j-1] if p[j-1] == '*' (empty string can match pattern with only '*')
3. For each character in string and pattern:
   - If pattern char is '?' or matches string char: dp[i][j] = dp[i-1][j-1]
   - If pattern char is '*': dp[i][j] = dp[i-1][j] || dp[i][j-1] || dp[i-1][j-1]
     - dp[i-1][j]: '*' matches current char in string
     - dp[i][j-1]: '*' matches empty sequence
     - dp[i-1][j-1]: '*' matches current char and we move both pointers
4. Return dp[s.Length][p.Length]

TIME COMPLEXITY: O(m * n) where m = length of string s, n = length of pattern p
SPACE COMPLEXITY: O(m * n) for the 2D DP array
*/