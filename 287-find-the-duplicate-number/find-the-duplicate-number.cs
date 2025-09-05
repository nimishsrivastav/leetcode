public class Solution {
    public int FindDuplicate(int[] nums) {
        // define two pointers. 'slow' pointer moves one step, 'fast' pointer moves 2 steps
        int slow = nums[0];
        int fast = nums[0];

        // cycle detection
        do {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        // reset slow pointer once cycle is detected
        slow = nums[0];

        // find cycle entrance
        while (slow != fast) {
            slow = nums[slow];
            fast = nums[fast];
        }

        // return the duplicate found
        return slow;
    }
}