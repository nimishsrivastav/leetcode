public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        
        int count = 1, maxCount = 0;

        for (int i = 0; i < nums.Length - 1; i++) {
            if (nums[i] < nums[i + 1]) count++;
            else count = 1;

            maxCount = Math.Max(count, maxCount);
        }

        return maxCount;
    }
}