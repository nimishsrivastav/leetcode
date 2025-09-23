public class Solution {
    public string AddBinary(string a, string b) {
        int i = a.Length - 1, j = b.Length - 1, carry = 0;

        var result = new StringBuilder();

        while (i >= 0 || j >= 0 || carry > 0) {
            int digit1 = i >=0 ? a[i] - '0' : 0;
            int digit2 = j >=0 ? b[j] - '0' : 0;
            
            int sum = digit1 + digit2 + carry;

            result.Append(sum % 2);
            carry = sum / 2;

            i--;
            j--;
        }

        char[] resultArray = result.ToString().ToCharArray();
        Array.Reverse(resultArray);

        return new string(resultArray);
    }
}