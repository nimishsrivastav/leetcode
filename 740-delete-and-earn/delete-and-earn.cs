public class Solution {
    public int DeleteAndEarn(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;

        if (nums.Length == 1) return nums[0];

        var pointsMap = new Dictionary<int, int>();

        foreach (var num in nums) {
            if (pointsMap.ContainsKey(num)) pointsMap[num] += num;
            else pointsMap[num] = num;
        }

        var uniqueNums = new List<int>(pointsMap.Keys);
        uniqueNums.Sort();

        if (uniqueNums.Count == 1) return pointsMap[uniqueNums[0]];

        int prev2 = 0;
        int prev1 = pointsMap[uniqueNums[0]];

        for (int i = 1; i < uniqueNums.Count; i++) {
            int currentNum = uniqueNums[i];
            int prevNum = uniqueNums[i - 1];
            int current;

            if (currentNum == prevNum + 1) current = Math.Max(prev2 + pointsMap[currentNum], prev1);
            else current = prev1 + pointsMap[currentNum];

            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}