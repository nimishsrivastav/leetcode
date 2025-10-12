public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        Generate("", n, n, result);
        return result;
    }

    private void Generate(string current, int left, int right, List<string> result) {
        if (left == 0 && right == 0) {
            result.Add(current);
            return;
        }

        if (left > 0) {
            Generate(current + "(", left - 1, right, result);
        }

        if (right > left) {
            Generate(current + ")", left, right - 1, result);
        }
    }
}