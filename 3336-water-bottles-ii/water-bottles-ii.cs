public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int totalDrunk = 0;

        int fullBottles = numBottles;
        int emptyBottles = 0;

        while (fullBottles > 0 || emptyBottles >= numExchange) {
            totalDrunk += fullBottles;
            emptyBottles += fullBottles;
            fullBottles = 0;

            while (emptyBottles >= numExchange) {
                emptyBottles -= numExchange;
                fullBottles += 1;
                numExchange += 1;
            }
        }

        return totalDrunk;
    }
}