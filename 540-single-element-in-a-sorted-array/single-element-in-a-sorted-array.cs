public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        // Binary search on pair indices instead of array indices
        // left and right represent pair numbers (0, 1, 2, ...)
        // Pair i contains elements at indices [2*i, 2*i+1]
        int left = 0;
        int right = nums.Length / 2;        // Total number of complete pairs

        // Continue until we find the disrupted pair
        while (left < right) {
            // mid represents the pair index we're checking
            var mid = (left + right) / 2;

            // Check if pair 'mid' is intact by comparing elements at:
            // - Index 2*mid (first element of the pair)
            // - Index 2*mid+1 (second element of the pair)
            if (nums[mid * 2] == nums[mid * 2 + 1]) 
                // Pair is intact - this means all pairs from 0 to mid are complete
                // The single element must be in pairs after 'mid'
                // So search in the right half
                left = mid + 1;
            else 
                // Pair is disrupted - this means the single element has shifted
                // all subsequent pairs, so it must be at or before this position
                // The single element is either:
                // 1. The first element of this disrupted pair (nums[mid*2])
                // 2. Somewhere in pairs before this one
                right = mid;
        }

        // At this point, left == right and points to the pair index 
        // where the disruption starts. The single element is the first
        // element of this disrupted pair
        return nums[left * 2];
    }
}