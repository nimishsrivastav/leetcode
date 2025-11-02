public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        if (nums == null || nums.Length == 0) return 0;

        Array.Sort(nums);

        int left = 0;
        long total = 0;
        int maxFreq = 0;

        for (int right = 0; right < nums.Length; right++) {
            total += nums[right];

            long opsNeeded = (long)nums[right] * (right - left + 1) - total;

            while (opsNeeded > k) {
                total -= nums[left];
                left++;

                opsNeeded = (long)nums[right] * (right - left + 1) - total;
            }

            maxFreq = Math.Max(maxFreq, (int)(right - left + 1));
        }

        return maxFreq;
    }
}