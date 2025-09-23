public class Solution {
    public string Multiply(string num1, string num2) {
        if (num1 == "0" || num2 == "0") return "0";

        int len1 = num1.Length, len2 = num2.Length;

        int[] result = new int[len1 + len2];

        for (int i = len1 - 1; i >= 0; i--) {
            for (int j = len2 - 1; j >= 0; j--) {
                int digit1 = num1[i] - '0';
                int digit2 = num2[j] - '0';

                int product = digit1 * digit2;
                int position = i + j + 1;

                int sum = product + result[position];

                result[position] = sum % 10;

                result[i + j] += sum / 10;
            }
        }

        var sb = new StringBuilder();

        bool leadingZero = true;

        for (int i = 0; i < result.Length; i++) {
            if (result[i] != 0) leadingZero = false;
            if (!leadingZero) sb.Append(result[i]);
        }

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}