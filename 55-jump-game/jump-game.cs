public class Solution {
    public bool CanJump(int[] nums) {
        if (nums.Length == 1) return true;

        int maxReach = 0;
        int lastIndex = nums.Length - 1;

        for (int i = 0; i < nums.Length - 1; i++) {
            if (i > maxReach) return false;

            maxReach = Math.Max(maxReach, i + nums[i]);

            if (maxReach >= lastIndex) return true;
        }

        return maxReach >= lastIndex;
    }
}