public class Solution {
    public string LargestNumber(int[] nums) {
        if (nums.All(x => x == 0)) return "0";

        string[] strNums = nums.Select(x => x.ToString()).ToArray();

        Array.Sort(strNums, (a, b) => {
            return string.Compare(b + a, a + b, StringComparison.Ordinal);
        });

        string result = string.Join("", strNums);

        return result[0] == '0' ? "0" : result;
    }
}

/*
    Algorithmic Steps:
    1. Handle edge case: if all numbers are 0, return "0"
    2. Convert all integers to strings for easier manipulation
    3. Sort the string array using custom comparator:
       - For two strings a and b, compare (a+b) vs (b+a)
       - If (a+b) > (b+a), then a should come before b
    4. Concatenate all sorted strings to form the result
    5. Handle edge case: if result starts with "0", return "0"
    
    Time Complexity: O(n log n * k) where n is number of elements, k is average length of numbers
    - Sorting takes O(n log n) comparisons
    - Each comparison takes O(k) time for string concatenation and comparison
    
    Space Complexity: O(n * k) where n is number of elements, k is average length of numbers
    - Creating string array takes O(n * k) space
    - Sorting is typically O(log n) additional space
*/