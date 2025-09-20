public class Solution {
    // Arrays to map numbers to their English word representations
    private readonly string[] ones = {
        "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", 
        "Seventeen", "Eighteen", "Nineteen"
    };
    
    private readonly string[] tens = {
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    };
    
    private readonly string[] thousands = {
        "", "Thousand", "Million", "Billion"
    };

    public string NumberToWords(int num) {
        // special case: if number is 0, return "zero"
        if (num == 0) return "Zero";

        string result = "";
        int thousandIndex = 0;

        // Process the number in groups of 1000
        // Start from the least significant digits
        while (num > 0) {
            // Extract the last 3 digits
            int currentGroup = num % 1000;

            // If current group is not zero, convert to words
            if (currentGroup != 0) {
                string groupWords = ConvertHundreds(currentGroup);

                // Add thousands suffix if needed (except for the ones place)
                if (thousandIndex > 0) {
                    groupWords += " " + thousands[thousandIndex];
                }

                // Prepend to result (since we're processing from right to left)
                result = groupWords + (result.Length > 0 ? " " + result : "");
            }

            // Move to the next group of 1000
            num /= 1000;
            thousandIndex++;
        }

        return result;
    }

    // Helper method to convert numbers less than 1000 to English words
    private string ConvertHundreds(int num) {
        string result = "";

        // Handle hundreds place (100-999)
        if (num >= 100) {
            result += ones[num / 100] + " Hundred";
            num %= 100;
            if (num > 0) result += " ";
        }

        // Handle tens and ones place (1-99)
        if (num >= 20) {
            result += tens[num / 10];
            num %= 10;
            if (num > 0) result += " ";
        }

        // Handle numbers 1-19 (including teens which have special names)
        if (num > 0) {
            result += ones[num];
        }

        return result;
    }
}

/*
Algorithmic Steps:
1. Handle the special case of zero
2. Create mapping arrays for ones, tens, and thousands
3. Create a helper function to convert numbers less than 1000 to words
4. Process the number in groups of thousands (ones, thousands, millions, billions)
5. For each group, convert to words and append the appropriate suffix
6. Join all parts with spaces and trim extra spaces

Time Complexity: O(1) - The number of operations is bounded by the maximum integer value
Space Complexity: O(1) - We use constant extra space for our arrays and variables

Example walkthrough for 1234567:
- Process billions: 1 -> "One Billion"
- Process millions: 234 -> "Two Hundred Thirty Four Million" 
- Process thousands: 567 -> "Five Hundred Sixty Seven Thousand"
- Final result: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand"
*/