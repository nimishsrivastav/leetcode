public class Solution {
    public int MaxArea(int[] height) {
        int left = 0, right = height.Length - 1, maxArea = 0;

        while (left < right) {
            int width = right - left;        
            int minHeight = Math.Min(height[left], height[right]);
            int currentArea = width * minHeight;

            if (currentArea > maxArea) maxArea = currentArea;

            if (height[left] < height[right]) left++;
            else right--;
        }
            return maxArea;
    }
}