public class Solution {
    public void MoveZeroes(int[] nums) {
        int nonZeroPos = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                if (i != nonZeroPos) {
                    int temp = nums[nonZeroPos];
                    nums[nonZeroPos] = nums[i];
                    nums[i] = temp;
                }

                nonZeroPos++;
            }
        }
    }
}