public class Solution {
    public int LongestOnes(int[] nums, int k) {
        if (nums == null || nums.Length == 0) return 0;

        int left = 0;
        int zeroCount = 0;

        for (int right = 0; right < nums.Length; right++) {
            if (nums[right] == 0)
                zeroCount++;

            if (zeroCount > k) {
                if (nums[left] == 0)
                    zeroCount--;

                left++;
            }
        }

        return nums.Length - left;
    }
}