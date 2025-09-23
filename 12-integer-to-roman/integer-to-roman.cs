public class Solution {
    public string IntToRoman(int num) {
        int[] values = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] symbols = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

        var result = new StringBuilder();

        for (int i = 0; i < values.Length; i++) {
            int count = num / values[i];

            for (int j = 0; j < count; j++) {
                result.Append(symbols[i]);
            }

            num %= values[i];

            if (num == 0) break;
        }

        return result.ToString();
    }
}