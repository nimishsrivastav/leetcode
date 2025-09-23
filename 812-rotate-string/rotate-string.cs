public class Solution {
    public bool RotateString(string s, string goal) {
        if (s.Length != goal.Length) return false;
        
        if (s.Length == 0) return true;

        string join = s + s;

        return join.Contains(goal);
    }
}