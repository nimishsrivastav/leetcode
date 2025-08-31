public class Solution {
    public long SmallestNumber(long num) {
        if (num == 0) return 0;

        bool isNegative = num < 0;
        string digits = Math.Abs(num).ToString();

        if (isNegative) {
            var sortedDesc = digits.OrderByDescending(c => c).ToArray();
            return -long.Parse(new string(sortedDesc));
        } else {
            var sortedAsc = digits.OrderBy(c => c).ToArray();

            if (sortedAsc[0] == '0') {
                int firstNonZeroIndex = 0;

                while (firstNonZeroIndex < sortedAsc.Length && sortedAsc[firstNonZeroIndex] == '0') {
                    firstNonZeroIndex++;
                }

                if (firstNonZeroIndex == sortedAsc.Length) return 0;

                char temp = sortedAsc[0];
                sortedAsc[0] = sortedAsc[firstNonZeroIndex];
                sortedAsc[firstNonZeroIndex] = temp;
            }

            return long.Parse(new string(sortedAsc));
        }
    }
}

/*
    Algorithm Steps:
     1. Handle the special case where num is 0
     2. Determine if the number is negative and store the sign
     3. Convert the absolute value to a string to work with digits
     4. Sort all digits in ascending order
     5. For positive numbers: handle leading zeros by moving the first non-zero digit to front
     6. For negative numbers: sort in descending order to get the largest absolute value (smallest negative)
     7. Convert back to long and apply the original sign
     
     Time Complexity: O(d log d) where d is the number of digits
     - Converting to string: O(d)
     - Sorting digits: O(d log d)
     - Rearranging and converting back: O(d)
     
     Space Complexity: O(d) where d is the number of digits
     - String representation of digits: O(d)
     - Array for sorting: O(d)
*/