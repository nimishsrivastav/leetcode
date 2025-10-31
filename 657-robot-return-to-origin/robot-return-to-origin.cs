public class Solution {
    public bool JudgeCircle(string moves) {
        if (string.IsNullOrEmpty(moves)) return true;

        int vertical = 0, horizontal = 0;

        foreach (var move in moves) {
            switch (move) {
                case 'U':
                    vertical++;
                    break;
                case 'D':
                    vertical--;
                    break;
                case 'R':
                    horizontal++;
                    break;
                case 'L':
                    horizontal--;
                    break;
            }
        }

        return vertical == 0 && horizontal == 0;
    }
}