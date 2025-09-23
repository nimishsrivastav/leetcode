public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        string doubleString = s + s;
        string modifiedString = doubleString.Substring(1, doubleString.Length - 2);

        return modifiedString.Contains(s);
    }
}