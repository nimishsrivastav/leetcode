public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        // base case: null and empty arrays
        if (gas == null || cost == null || gas.Length == 0 || cost.Length == 0 || gas.Length != cost.Length) return -1;

        // base case: single station
        if (gas.Length == 1) return gas[0] >= cost[0] ? 0 : -1;

        int n = gas.Length;
        int totalGas = 0;
        int totalCost = 0;
        int currentTank = 0;
        int startStation = 0;

        for (int i = 0; i < n; i++) {
            totalGas += gas[i];
            totalCost += cost[i];

            currentTank += gas[i] - cost[i];

            if (currentTank < 0) {
                startStation = i + 1;
                currentTank = 0;
            }
        }

        return totalGas >= totalCost ? startStation : -1;
    }
}