public class Solution {
    public int[] GetNoZeroIntegers(int n) {
        int a = 1, b = n - 1;

        while (ContainsZero(a) || ContainsZero(b)) {
            a++;
            b--;
        }

        return new int[] { a, b };
    }

    private bool ContainsZero(int num) {
        while (num > 0) {
            if (num % 10 == 0)
                return true;

            num /= 10;
        }

        return false;
    }
}