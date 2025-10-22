public class Solution 
{
    public int MinOperations(int n) 
    {
        // Base case: if n is 0, no operations needed
        if (n <= 0) return 0;
        
        int operations = 0;
        
        // Process the binary representation of n
        while (n > 0) 
        {
            // If the last bit is 0, just shift right (no operation needed)
            if ((n & 1) == 0) 
            {
                n >>= 1;
            }
            // If the last bit is 1, we found a group of 1s
            else 
            {
                // Check if there are consecutive 1s
                // If next bit is also 1, we have consecutive 1s
                if ((n & 2) == 2) 
                {
                    // Keep removing consecutive 1s by adding 1
                    // This converts 111...1 to 1000...0
                    while ((n & 1) == 1) 
                    {
                        n >>= 1;
                    }
                    // Add 1 to handle the carry from consecutive 1s
                    n++;
                    operations++; // This is the "add" operation
                }
                else 
                {
                    // Single 1 bit, just subtract it
                    n >>= 1;
                    operations++; // This is the "subtract" operation
                }
            }
        }
        
        return operations;
    }
}

/*
1. Initialize operations counter to 0
2. While n > 0:
    - Check the least significant bit (LSB)
    - If LSB is 0: Shift right (divide by 2), no operation needed
    - If LSB is 1:
        - Check if next bit is also 1 (consecutive 1s)
        - If consecutive 1s exist:
            - Keep shifting right while LSB is 1
            - Increment n (this represents adding to round up)
            - Increment operations count
        - Else (isolated 1):
            - Shift right (subtract this power of 2)
            - Increment operations count
3. Return total operations

Time: O(log n), Space: O(1)
*/