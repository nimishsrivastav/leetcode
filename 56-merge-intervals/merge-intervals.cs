public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals == null || intervals.Length <= 1) return intervals;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var merged = new List<int[]>();
        merged.Add(intervals[0]);

        for (int i = 1; i < intervals.Length; i++) {
            int[] lastInterval = merged[merged.Count - 1];
            int[] currentInterval = intervals[i];

            if (currentInterval[0] <= lastInterval[1]) {
                lastInterval[1] = Math.Max(lastInterval[1], currentInterval[1]);
            } else {
                merged.Add(currentInterval);
            }
        }

        return merged.ToArray();
    }
}