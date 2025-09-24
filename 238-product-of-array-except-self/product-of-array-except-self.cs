public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;

        int[] result = new int[n];
        Array.Fill(result, 1);

        for (int i = 1; i < n; i++) {
            result[i] = result[i - 1] * nums[i - 1];
        }

        int postFix = 1;
        for(int i = n - 1; i >= 0; i--) {
            result[i] *= postFix;
            postFix *= nums[i];
        }

        return result;
    }
}