public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];

        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int scenario1 = RobLinear(nums, 0, nums.Length - 2);
        int scenario2 = RobLinear(nums, 1, nums.Length - 1);

        return Math.Max(scenario1, scenario2);
    }

    private int RobLinear(int[] nums, int start, int end) {
        int prev2 = 0, prev1 = 0;

        for (int i = start; i <= end; i++) {
            int current = Math.Max(nums[i] + prev2, prev1);

            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}