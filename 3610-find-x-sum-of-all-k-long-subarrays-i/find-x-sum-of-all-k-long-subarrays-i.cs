public class Solution {
    public int[] FindXSum(int[] nums, int k, int x) {
        int n = nums.Length;
        int[] result = new int[n - k + 1];

        // iterate through all k-length subarrays
        for (int i = 0; i <= n - k; i++) {
            // step 1: build frequency map fir current window
            var freqMap = new Dictionary<int, int>();

            for (int j = i; j < i + k; j++) {
                if (freqMap.ContainsKey(nums[j]))
                    freqMap[nums[j]]++;
                else
                    freqMap[nums[j]] = 1;
            }

            // step 2: convert to list for sorting
            List<(int value, int freq)> elements = new List<(int, int)>();

            foreach (var kvp in freqMap) {
                elements.Add((kvp.Key, kvp.Value));
            }

            // step 3: sort by frequency (descending), then by value (descending)
            elements.Sort((a, b) =>
            {
                if (a.freq != b.freq)
                    return b.freq.CompareTo(a.freq);    // higher frequency first

                return b.value.CompareTo(a.value);      // higher value first (tie-breaker)
            });

            // step 4: calculate x-sum by taking top x elements
            int xSum = 0;
            int count = Math.Min(x, elements.Count);    // handle case where x > unique elements

            for (int j = 0; j < count; j++)
                xSum += elements[j].value * elements[j].freq;

            result[i] = xSum;
        }

        return result;
    }
}

/*
Complexity Analysis
1. Time Complexity: O((n - k + 1) × (k + m log m))
    - (n - k + 1) subarrays to process
    - For each subarray:
        - O(k) to build frequency map
        - O(m) to convert to list, where m = unique elements (m ≤ k)
        - O(m log m) to sort
        - O(x) to calculate sum (x ≤ m)
    - Overall: O((n - k + 1) × (k + m log m))
    - In worst case where all elements are unique: O((n - k + 1) × k log k)

2. Space Complexity: O(k)
    - O(m) for frequency map, where m ≤ k
    - O(m) for elements list
    - O(n - k + 1) for result array (required output)
    - Auxiliary space (excluding output): O(k)
*/