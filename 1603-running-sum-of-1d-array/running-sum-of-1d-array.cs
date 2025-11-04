public class Solution {
    public int[] RunningSum(int[] nums) {
        if (nums.Length == 1)
            return nums;

        for (int i = 1; i < nums.Length; i++)
            nums[i] += nums[i - 1];

        return nums;
    }
}