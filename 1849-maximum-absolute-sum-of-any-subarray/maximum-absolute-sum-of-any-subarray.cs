public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        int maxSum = FindMaxSubarraySum(nums);
        int minSum = FindMinSubarraySum(nums);

        return Math.Max(Math.Abs(maxSum), Math.Abs(minSum));
    }

    private int FindMaxSubarraySum(int[] nums) {
        int currentSum = 0;
        int maxSum = int.MinValue;

        foreach (int num in nums) {
            currentSum = Math.Max(num, currentSum + num);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }

    private int FindMinSubarraySum(int[] nums) {
        int currentSum = 0;
        int minSum = int.MaxValue;

        foreach (int num in nums) {
            currentSum = Math.Min(num, currentSum + num);
            minSum = Math.Min(minSum, currentSum);
        }

        return minSum;
    }
}