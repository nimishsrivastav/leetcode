public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        int[] result = new int[n];

        var stack = new Stack<int>();

        for (int currentDay = 0; currentDay < n; currentDay++) {
            while (stack.Count > 0 && temperatures[currentDay] > temperatures[stack.Peek()]) {
                int prevDay = stack.Pop();
                
                result[prevDay] = currentDay - prevDay;
            }

            stack.Push(currentDay);
        }

        return result;
    }
}