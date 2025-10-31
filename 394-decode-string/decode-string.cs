public class Solution {
    public string DecodeString(string s) {
        Stack<int> countStack = new Stack<int>();
        Stack<string> stringStack = new Stack<string>();

        string currentString = "";
        int currentNum = 0;

        foreach (char c in s) {
            if (char.IsDigit(c)) {
                currentNum = currentNum * 10 + (c - '0');
            } else if (c == '[') {
                countStack.Push(currentNum);
                stringStack.Push(currentString);

                currentNum = 0;
                currentString = "";
            } else if (c == ']') {
                int repeatCount = countStack.Pop();
                string previousString = stringStack.Pop();

                var decoded = new StringBuilder(previousString);

                for (int i = 0; i < repeatCount; i++)
                    decoded.Append(currentString);

                currentString = decoded.ToString();
            } else {
                currentString += c;
            }
        }

        return currentString;
    }
}