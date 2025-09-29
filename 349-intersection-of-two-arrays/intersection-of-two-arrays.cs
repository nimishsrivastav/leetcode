public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        if (nums1.Length == 0 || nums2.Length == 0) return new int[0];

        var set = new HashSet<int>(nums1);
        var resultSet = new HashSet<int>();

        foreach (var num in nums2) {
            if(set.Contains(num)) resultSet.Add(num);
        }

        int[] result = new int[resultSet.Count];
        resultSet.CopyTo(result);
        
        return result;
    }
}