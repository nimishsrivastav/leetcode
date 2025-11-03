public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        if (colors == null || colors.Length < 2) return 0;

        int totalCost = 0;
        int n = colors.Length;
        int i = 0;

        while (i < n) {
            int j = i;
            int groupSum = 0;
            int maxTime = 0;

            while (j < n && colors[j] == colors[i]) {
                groupSum += neededTime[j];
                maxTime = Math.Max(maxTime, neededTime[j]);
                j++;
            }

            if (j - i > 1)
                totalCost += groupSum - maxTime;

                i = j;
        }

        return totalCost;
    }
}