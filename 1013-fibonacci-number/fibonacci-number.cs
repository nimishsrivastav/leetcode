public class Solution {
    public int Fib(int n) {
        if (n <= 1) return n;

        int f0 = 0;
        int f1 = 1;
        int current = 0;

        for (int i = 2; i <= n; i++) {
            current = f1 + f0;

            f0 = f1;
            f1 = current;
        }

        return current;
    }
}