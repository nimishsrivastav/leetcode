public class Solution {
    public int RomanToInt(string s) {
        var romanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int result = 0;

        for (int i = 0; i < s.Length; i++) {
            int currentValue = romanMap[s[i]];

            if (i < s.Length - 1 && currentValue < romanMap[s[i + 1]]) {
                result -= currentValue;
            } else {
                result += currentValue;
            }
        }

        return result;
    }
}