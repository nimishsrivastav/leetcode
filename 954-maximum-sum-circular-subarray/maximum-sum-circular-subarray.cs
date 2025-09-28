public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        if (nums.Length == 1) return nums[0];

        int maxKadane = KadaneMax(nums);

        int totalSum = 0;
        foreach (int num in nums) {
            totalSum += num;
        }

        int minKadane = KadaneMin(nums);
        int maxCircular = totalSum - minKadane;

        if (maxCircular == 0) return maxKadane;

        return Math.Max(maxKadane, maxCircular);
    }

    private int KadaneMax(int[] nums) {
        int maxEndingHere = nums[0];
        int maxSoFar = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }

    private int KadaneMin(int[] nums) {
        int minEndingHere = nums[0];
        int minSoFar = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            minEndingHere = Math.Min(nums[i], minEndingHere + nums[i]);
            minSoFar = Math.Min(minSoFar, minEndingHere);
        }

        return minSoFar;
    }
}