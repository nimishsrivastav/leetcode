public class Solution {
    public int MaxSum(int[] nums) {
        // return nums.Distinct().Where(x => x > 0).Sum();

        var uniqueValues = new HashSet<int>(nums);

        int maxSum = 0;
        foreach (int value in uniqueValues) {
            if (value > 0) maxSum += value;
        }

        if (maxSum == 0) return uniqueValues.Max();

        return maxSum;
    }
}