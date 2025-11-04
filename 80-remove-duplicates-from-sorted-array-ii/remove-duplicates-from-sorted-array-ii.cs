public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length <= 2)
            return nums.Length;

        int left = 2;

        for (int right = 2; right < nums.Length; right++) {
            if (nums[right] != nums[left - 2]) {
                nums[left] = nums[right];
                left++;
            }
        }

        return left;
    }
}