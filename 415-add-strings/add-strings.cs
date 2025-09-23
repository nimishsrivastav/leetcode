public class Solution {
    public string AddStrings(string num1, string num2) {
        int i = num1.Length - 1, j = num2.Length - 1, carry = 0;

        var result = new StringBuilder();

        while (i >= 0 || j >= 0 || carry > 0) {
            int digit1 = i >=0 ? num1[i] - '0' : 0;
            int digit2 = j >=0 ? num2[j] - '0' : 0;
            
            int sum = digit1 + digit2 + carry;

            result.Append(sum % 10);
            carry = sum / 10;

            i--;
            j--;
        }

        char[] resultArray = result.ToString().ToCharArray();
        Array.Reverse(resultArray);

        return new string(resultArray);
    }
}