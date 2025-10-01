public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int totalDrinkableBottles = numBottles;

        while (numBottles >= numExchange) {
            numBottles = numBottles - numExchange + 1;
            totalDrinkableBottles += 1;
        }

        return totalDrinkableBottles;
    }
}