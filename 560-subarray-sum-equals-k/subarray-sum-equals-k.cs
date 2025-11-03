public class Solution {
    public int SubarraySum(int[] nums, int k) {
        if (nums == null || nums.Length == 0) return 0;

        var prefixSumMap = new Dictionary<int, int>();

        prefixSumMap[0] = 1;

        int currentSum = 0;
        int count = 0;

        for (int i = 0; i < nums.Length; i++) {
            currentSum += nums[i];

            if (prefixSumMap.ContainsKey(currentSum - k))
                count += prefixSumMap[currentSum - k];

            if (prefixSumMap.ContainsKey(currentSum))
                prefixSumMap[currentSum]++;
            else
                prefixSumMap[currentSum] = 1;
        }

        return count;
    }
}