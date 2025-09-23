public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var map = new Dictionary<string, List<string>>();

        foreach (var str in strs) {
            var key = String.Concat(str.OrderBy(c => c));

            if (!map.ContainsKey(key)) map[key] = new List<string>();

            map[key].Add(str);
        }

        return map.Values.Cast<IList<string>>().ToList();
    }
}