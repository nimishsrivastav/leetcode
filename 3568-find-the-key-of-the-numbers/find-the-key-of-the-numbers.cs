public class Solution {
    public int GenerateKey(int num1, int num2, int num3) {
        String s1 = num1.ToString("D4");
        String s2 = num2.ToString("D4");
        String s3 = num3.ToString("D4");

        StringBuilder key = new StringBuilder();

        for (int i = 0; i < 4; i++) {
            int digit1 = s1[i] - '0';
            int digit2 = s2[i] - '0';
            int digit3 = s3[i] - '0';

            int minDigit = Math.Min(digit1, Math.Min(digit2, digit3));
            key.Append(minDigit);
        }

        return int.Parse(key.ToString());
    }
}

/*
    Algorithmic Steps:
    1. Convert each number to a 4-digit string by padding with leading zeros if necessary
    2. For each position (0 to 3), find the minimum digit among all three numbers at that position
    3. Concatenate these minimum digits to form the key
    4. Convert the key back to integer and return (this removes leading zeros automatically)

    Time Complexity: O(1) - We always process exactly 4 digits for 3 numbers, so it's constant time
    Space Complexity: O(1) - We use constant extra space for string conversions and variables
*/