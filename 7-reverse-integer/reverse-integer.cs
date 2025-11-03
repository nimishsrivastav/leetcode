public class Solution {
    public int Reverse(int x) {
        int result = 0;

        // process all digits
        while (x != 0) {
            int digit = x % 10;

            x = x / 10;

            // positive overflow
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7))
                return 0;
            
            // negative overflow
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8))
                return 0;
            
            // build the reversed number
            result = result * 10 + digit;
        }

        return result;
    }
}