class TimeMap:

    def __init__(self):
        self.store = defaultdict(list)             # dictionary to store key: list of (timestamp, value) pairs

    def set(self, key: str, value: str, timestamp: int) -> None:
        # append (timestamp, value) pair
        # since timestamps are strictly increasing, we can just append
        self.store[key].append((timestamp, value))

    def get(self, key: str, timestamp: int) -> str:
        # if key doesn't exist, return an empty list
        if key not in self.store:
            return ""

        # get the list of (timestamp, value) pairs for this key
        pairs = self.store[key]

        # binary search for the rightmost timestamp <= given timestamp
        left, right = 0, len(pairs) - 1
        result_value = ""

        while left <= right:
            mid = (left + right) // 2

            if pairs[mid][0] <= timestamp:
                # this timestamp is valid, store the value and search right
                result_value = pairs[mid][1]
                left = mid + 1
            else:
                # this timestamp is too large, search left
                right = mid - 1

        return result_value


# Your TimeMap object will be instantiated and called as such:
# obj = TimeMap()
# obj.set(key,value,timestamp)
# param_2 = obj.get(key,timestamp)

##### ALGORITHM #####
# 1. Use a dictionary where each key maps to a list of (timestamp, value) tuples
# 2. Set Operation:
#     - Append (timestamp, value) to the list
#     - Keep list sorted by timestamp (insert in correct position or sort periodically)
# 3. Get Operation:
#     - If key doesn't exist, return empty string
#     - Use binary search to find the rightmost timestamp ≤ query timestamp
#     - Return the corresponding value, or empty string if no valid timestamp found
#####################

##### TIME/SPACE COMPLEXITIES #####
# 1. Time Complexity:
#     - For set function, O(1) - since timestamps are strictly increasing, we can simply append to the list
#     - For get function, O(nlogn) - binary search on the list of timestamps for the given key, where n is the number of values stored for that key
# 2. Space Complexity:
#     - O(M), where M is the total number of set operations performed
#     - In worst case, if we have K unique keys and each key has N values, O(K x N) = O(M)
###################################