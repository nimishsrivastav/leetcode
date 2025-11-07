public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int left = 0;
        int sumOfCurrentWindow = 0;
        int minLengthSubarray = int.MaxValue;

        for (int right = 0; right < nums.Length; right++) {
            // expand window by adding current element
            sumOfCurrentWindow += nums[right];

            // shrink window from left while sum >= target
            while (sumOfCurrentWindow >= target) {
                minLengthSubarray = Math.Min(minLengthSubarray, right - left + 1);
                sumOfCurrentWindow -= nums[left++];
            }
        }

        // if minLength was never updated, no valid subarray exists
        return minLengthSubarray == int.MaxValue ? 0 : minLengthSubarray;
    }
}