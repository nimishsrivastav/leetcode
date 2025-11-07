public class Solution {
    public int Trap(int[] height) {
        if (height == null || height.Length < 3) return 0;
        
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int totalWater = 0;

        while (left < right) {
            if (height[left] < height[right]) {
                if (height[left] >= leftMax)
                    leftMax = height[left];
                else
                    totalWater += leftMax - height[left];

                left += 1;
            } else {
                if (height[right] >= rightMax)
                    rightMax = height[right];
                else
                    totalWater += rightMax - height[right];

                right -= 1;
            }
        }

        return totalWater;
    }
}