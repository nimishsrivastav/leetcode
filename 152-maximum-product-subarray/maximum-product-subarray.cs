public class Solution {
    public int MaxProduct(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        int maxProduct = nums[0];
        int currentMax = nums[0];
        int currentMin = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            int num = nums[i];
            int tempMax = currentMax;

            currentMax = Math.Max(num, Math.Max(currentMax * num, currentMin * num));
            currentMin = Math.Min(num, Math.Min(tempMax * num, currentMin * num));

            maxProduct = Math.Max(maxProduct, currentMax);
        }

        return maxProduct;
    }
}