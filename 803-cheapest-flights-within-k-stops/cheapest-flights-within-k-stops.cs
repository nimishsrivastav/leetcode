public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        int[] distances = new int[n];
        Array.Fill(distances, int.MaxValue);
        distances[src] = 0;
    
        for (int i = 0; i <= k; i++) {
            int[] temp = new int[n];

            Array.Copy(distances, temp, n);

            foreach (var flight in flights) {
                int from = flight[0];
                int to = flight[1];
                int price = flight[2];

                if (distances[from] != int.MaxValue) {
                    temp[to] = Math.Min(temp[to], distances[from] + price);
                }
            }

            distances = temp;
        }

        return distances[dst] == int.MaxValue ? -1 : distances[dst];
    }
}