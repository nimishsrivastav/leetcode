public class Solution {
    public int Compress(char[] chars) {
        if (chars.Length <= 1) return chars.Length;

        int write = 0, read = 0;

        while (read < chars.Length) {
            char currentChar = chars[read];
            int count = 0;

            while (read < chars.Length && chars[read] == currentChar) {
                read++;
                count++;
            }

            chars[write] = currentChar;
            write++;

            if (count > 1) {
                string countStr = count.ToString();

                foreach (char c in countStr) {
                    chars[write] = c;
                    write++;
                }
            }
        }

        return write;
    }
}