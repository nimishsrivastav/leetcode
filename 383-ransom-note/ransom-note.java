class Solution {
    public boolean canConstruct(String ransomNote, String magazine) {
        // Base Case 1: If ransomNote is empty, it can always be constructed.
        if (ransomNote.isEmpty()) return true;

        // Edge Case 1: If magazine is empty, and ransomNote is not empty, ransomNote cannot be constructed.
        if (magazine.isEmpty()) return false;

        // Edge Case 2: If ransomNote is longer than magazine, it's impossible to construct ransomNote.
        if (ransomNote.length() > magazine.length()) return false;

        // Create an array to store character counts (for 'a' through 'z')
        int[] charCount = new int[26];

        // Populate the frequency array for characters in magazine
        for (char c : magazine.toCharArray()) {
            charCount[c - 'a']++;
        }

        // Check if ransomNote can be constructed using the available characters
        for (char c : ransomNote.toCharArray()) {
            // Decrement the count for the current character
            charCount[c - 'a']--;

            // If the count becomes negative, it means we don't have enough of this character in the magazine to form the ransomNote.
            if (charCount[c - 'a'] < 0) {
                return false;
            }
        }

        // If we successfully processed all characters in ransomNote without any negative counts, it means ransomNote can be constructed.
        return true;
    }
}

/* 
    Time Complexity: O(m + n), where m = magazine.length; n = ransomNote.length
    Space Complexity: O(1), constant space as the size of the charCount array remains constant regardless of input size 
*/